using Microsoft.EntityFrameworkCore;
using ProjetosAPI.Database;
using ProjetosAPI.Models;
using ProjetosAPI.Repositories.Interfaces;

namespace ProjetosAPI.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly ProjetosAPIContext _db;

        public ComentarioRepository(ProjetosAPIContext db)
        {
            _db = db;
        }

        public List<Comentario> Get()
        {
            return _db.Comentarios.ToList();
        }

        public Comentario GetById(int id)
        {
            return _db.Comentarios.Find(id)!;
        }

        public List<Comentario> GetByTarefa(int idTarefa)
        {
            return _db.Comentarios.Where(c => c.IdTarefa == idTarefa).ToList();
        }

        public bool Add(Comentario comentario)
        {
            Tarefa tarefa = _db.Tarefas.FirstOrDefault(t => t.Id == comentario.IdTarefa)!;

            if(tarefa != null)
            {
                _db.Comentarios.Add(comentario);
                _db.SaveChanges();

                gravarLogComentario(string.Empty, comentario.Texto!, comentario.Id, comentario.IdUsuario);
                return true;
            }
            return false;
        }

        public bool Update(Comentario comentario)
        {
            var comentarioOriginal = _db.Comentarios.AsNoTracking().FirstOrDefault(t => t.Id == comentario.Id);

            if(comentarioOriginal != null)
            {
                _db.Comentarios.Update(comentario);
                _db.SaveChanges();

                if (comentarioOriginal!.Texto != comentario.Texto)
                    gravarLogComentario(comentarioOriginal.Texto!, comentario.Texto!, comentario.Id, comentario.IdUsuario);
                return true;
            }
            return false;
        }

        public void Delete(int id)
        {
            _db.Comentarios.Remove(GetById(id));
            _db.SaveChanges();
        }

        private void gravarLogComentario(string valorOriginal, string novoValor, int comentarioId, int usuarioId)
        {
            LogComentario novoLog = new LogComentario();
            novoLog.IdComentario = comentarioId;
            novoLog.DataAlteracao = DateTimeOffset.Now;
            novoLog.ValorAnterior = valorOriginal;
            novoLog.NovoValor = novoValor;
            novoLog.IdUsuario = usuarioId;

            _db.LogComentarios.Add(novoLog);
            _db.SaveChanges();
        }
    }
}
