using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetosAPI.Models;
using ProjetosAPI.Repositories.Interfaces;
using ProjetosAPI.Enums;
using ProjetosAPI.Database;
using System.Net;

namespace ProjetosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;

        private readonly IComentarioRepository _comentarioRepository;

        public TarefasController(ITarefaRepository tarefaRepository, IComentarioRepository comentarioRepository)
        {
            this._tarefaRepository = tarefaRepository;
            this._comentarioRepository = comentarioRepository;
        }

        /// <summary>
        /// Lista todos as Tarefas de todos os Projetos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            var listaTarefas = _tarefaRepository.Get();

            return Ok(listaTarefas);
        }

        /// <summary>
        /// Busca uma Tarefa através do seu Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            var usuario = _tarefaRepository.GetById(id);
            if (usuario == null)
                return NotFound("Tarefa não encontrada!");

            return Ok(usuario);
        }

        /// <summary>
        /// Busca todas as Tarefas de um determinado Projeto
        /// </summary>
        /// <param name="projetoId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetByProjeto")]
        public IActionResult GetByProjeto(int projetoId)
        {
            var listaTarefas = _tarefaRepository.GetByProjeto(projetoId);
            if (listaTarefas == null)
                return NotFound("Nenhuma Tarefa encontrada para este Projeto!");

            return Ok(listaTarefas);
        }

        /// <summary>
        /// Adicionar uma nova Tarefa
        /// </summary>
        /// <param name="tarefa"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddTarefa")]
        public IActionResult Add([FromBody] Tarefa tarefa)
        {
            if (!verificaPrioridade(tarefa))
                return StatusCode(400, "O campo Prioridade está incorreto!");

            List<Tarefa> listaTarefas = _tarefaRepository.GetByProjeto(tarefa.IdProjeto);

            if (listaTarefas != null)
            {
                if (listaTarefas.Count >= 20)
                    return StatusCode(400, "Limites de tarefas atingido (20)");
            }

            _tarefaRepository.Add(tarefa);
            return Ok(tarefa);
        }

        /// <summary>
        /// Atualizar os dados de uma Tarefa
        /// </summary>
        /// <param name="tarefa"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateTarefa")]
        public IActionResult Update([FromBody] Tarefa tarefa)
        {
            string retornoUpdate = _tarefaRepository.Update(tarefa);
            if (retornoUpdate == string.Empty || retornoUpdate == null)
                return Ok(tarefa);
            else
                return StatusCode(400, retornoUpdate);
        }

        /// <summary>
        /// Excluir uma Tarefa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteTarefa")]
        public IActionResult Delete(int id)
        {
            //Se deletar uma tarefa, preciso deletar todos os comentários dela para não deixar inconsistência no banco
            List<Comentario> listaComentarios = _comentarioRepository.GetByTarefa(id);

            if (listaComentarios != null)
            {
                foreach (var comentario in listaComentarios)
                    _comentarioRepository.Delete(comentario.Id);
            }

            _tarefaRepository.Delete(id);
            return Ok(HttpStatusCode.OK);
        }

        private bool verificaPrioridade(Tarefa tarefa)
        {
            bool resposta = true;

            if (!tarefa.Prioridade.Equals((int)Enumerators.PrioridadeTarefa.Baixa)
                    && !tarefa.Prioridade.Equals((int)Enumerators.PrioridadeTarefa.Media)
                    && !tarefa.Prioridade.Equals((int)Enumerators.PrioridadeTarefa.Alta))
                resposta = false;

            return resposta;
        }
    }
}
