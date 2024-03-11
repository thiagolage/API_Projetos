using Microsoft.EntityFrameworkCore;
using ProjetosAPI.Database;
using ProjetosAPI.Enums;
using ProjetosAPI.Models;
using ProjetosAPI.Repositories.Interfaces;
using System;

namespace ProjetosAPI.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly ProjetosAPIContext _db;

        public TarefaRepository(ProjetosAPIContext db)
        {
            _db = db;
        }

        public List<Tarefa> Get()
        {
            return _db.Tarefas.ToList();
        }

        public Tarefa GetById(int id)
        {
            return _db.Tarefas.Find(id)!;
        }

        public List<Tarefa> GetByProjeto(int projetoId)
        {
            return _db.Tarefas.Where(t => t.IdProjeto == projetoId).ToList();
        }

        public void Add(Tarefa tarefa)
        {
            _db.Tarefas.Add(tarefa);
            _db.SaveChanges();
        }

        public string Update(Tarefa tarefa)
        {
            string msgRetorno = string.Empty;

            var tarefaOriginal = _db.Tarefas.AsNoTracking().FirstOrDefault(t => t.Id == tarefa.Id);

            bool prioridadeAlterada = tarefaOriginal!.Prioridade! != tarefa.Prioridade;

            bool projetoAlterado = tarefaOriginal!.IdProjeto! != tarefa.IdProjeto;

            bool tarefaFinalizada = tarefaOriginal.Status == (int)Enumerators.StatusTarefa.Concluído;

            if (!prioridadeAlterada)
            {
                if (!projetoAlterado)
                {
                    if (!tarefaFinalizada)
                    {
                        if (tarefa.Status.Equals((int)Enumerators.StatusTarefa.Concluído))
                            tarefa.DataConclusao = DateTimeOffset.Now;

                        _db.Tarefas.Update(tarefa);
                        _db.SaveChanges();

                        if (tarefaOriginal.Titulo != tarefa.Titulo)
                            gravarLogTarefa("Titulo", tarefaOriginal!.Titulo!, tarefa!.Titulo!, tarefa.Id, 1);
                        if (tarefaOriginal.Descricao != tarefa.Descricao)
                            gravarLogTarefa("Descricao", tarefaOriginal!.Descricao!, tarefa!.Descricao!, tarefa.Id, 1);
                        if (tarefaOriginal.DataVencimento != tarefa.DataVencimento)
                            gravarLogTarefa("DataVencimento", tarefaOriginal!.DataVencimento!.ToString(), tarefa!.DataVencimento!.ToString(), tarefa.Id, 1);
                        if (tarefaOriginal.DataConclusao != tarefa.DataConclusao)
                            gravarLogTarefa("DataConclusao", "", tarefa.DataConclusao.ToString()!, tarefa.Id, 1);
                        if (tarefaOriginal.Status != tarefa.Status)
                            gravarLogTarefa("Status", tarefaOriginal!.Status!.ToString(), tarefa!.Status!.ToString(), tarefa.Id, 1);
                        if (tarefaOriginal.Prioridade != tarefa.Prioridade)
                            gravarLogTarefa("Prioridade", tarefaOriginal!.Prioridade!.ToString(), tarefa!.Prioridade!.ToString(), tarefa.Id, 1);
                        if (tarefaOriginal.IdUsuarioAssignee != tarefa.IdUsuarioAssignee)
                            gravarLogTarefa("IdUsuarioAssignee", tarefaOriginal!.IdUsuarioAssignee!.ToString(), tarefa!.IdUsuarioAssignee!.ToString(), tarefa.Id, 1);

                        return msgRetorno;
                    }
                    else
                        msgRetorno = "Esta tarefa já está finalizada, não pode mais ser alterada.";
                }
                else
                    msgRetorno = "O Projeto não pode ser alterado.";
            }
            else
                msgRetorno = "A Prioridade não pode ser alterada.";

            return msgRetorno;
        }

        public void Delete(int id)
        {
            _db.Tarefas.Remove(GetById(id));
            _db.SaveChanges();
        }

        private void gravarLogTarefa(string campoAlterado, string valorOriginal, string novoValor, int tarefaId, int usuarioId)
        {
            LogTarefa novoLog = new LogTarefa();
            novoLog.IdTarefa = tarefaId;
            novoLog.DataAlteracao = DateTimeOffset.Now;
            novoLog.CampoModificado = campoAlterado;
            novoLog.ValorAnterior = valorOriginal;
            novoLog.NovoValor = novoValor;
            novoLog.IdUsuario = usuarioId;

            _db.LogTarefas.Add(novoLog);
            _db.SaveChanges();
        }
    }
}
