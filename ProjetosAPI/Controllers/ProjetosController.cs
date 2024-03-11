using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetosAPI.Repositories.Interfaces;
using ProjetosAPI.Enums;
using ProjetosAPI.Models;
using System.Net;

namespace ProjetosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IComentarioRepository _comentarioRepository;

        public ProjetosController(IProjetoRepository repository, ITarefaRepository tarefaRepository, IComentarioRepository comentarioRepository)
        {
            this._projetoRepository = repository;
            this._tarefaRepository = tarefaRepository;
            this._comentarioRepository = comentarioRepository;
        }

        /// <summary>
        /// Retorna uma lista com todos os projetos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            var listaProjetos = _projetoRepository.Get();

            return Ok(listaProjetos);
        }

        /// <summary>
        /// Retorna um projeto específico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            var usuario = _projetoRepository.GetById(id);
            if (usuario == null)
                return NotFound("Projeto não encontrado!");

            return Ok(usuario);
        }

        /// <summary>
        /// Busca todos os projetos assinados para um determinado usuário
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetByUsuario")]
        public IActionResult GetByUsuario(int usuarioId)
        {
            var listaProjetos = _projetoRepository.GetByUsuario(usuarioId);
            if (listaProjetos == null)
                return NotFound("Nenhum projeto encontrado para este usuário!");

            return Ok(listaProjetos);
        }

        /// <summary>
        /// Incluir um novo Projeto
        /// </summary>
        /// <param name="projeto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddProjeto")]
        public IActionResult Add([FromBody] Projeto projeto)
        {
            _projetoRepository.Add(projeto);
            return Ok(projeto);
        }

        /// <summary>
        /// Atualizar dados de um Projeto
        /// </summary>
        /// <param name="projeto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateProjeto")]
        public IActionResult Update([FromBody] Projeto projeto)
        {
            _projetoRepository.Update(projeto);

            return Ok(projeto);
        }

        /// <summary>
        /// Remover um Projeto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteProjeto")]
        public IActionResult Delete(int id)
        {
            //Verifica se existem Tarefas pendentes
            List<Tarefa> listaTarefas = _tarefaRepository.GetByProjeto(id);
            if (verificaTarefasPendentes(id, listaTarefas))
                return StatusCode(400, "Existem tarefas pendentes ou em andamento neste Projeto. Conclua as tarefas as remova antes de excluir o Projeto.");

            //Exclusão em cascata, primeiro os comentários, depois as tarefas e por último o projeto
            List<Comentario> listaComentarios = new List<Comentario>();

            if (listaTarefas != null)
            {
                foreach (var tarefa in listaTarefas)
                {
                    listaComentarios = _comentarioRepository.GetByTarefa(tarefa.Id);
                    foreach (var comentario in listaComentarios)
                    {
                        _comentarioRepository.Delete(comentario.Id);
                    }
                    _tarefaRepository.Delete(tarefa.Id);
                }
            }

            _projetoRepository.Delete(id);
            return Ok(HttpStatusCode.OK);
        }

        private bool verificaTarefasPendentes(int idProjeto, List<Tarefa> listaTarefas)
        {
            if (listaTarefas != null)
            {
                foreach (var tarefa in listaTarefas)
                {
                    if (tarefa.Status.Equals((int)Enumerators.StatusTarefa.Pendente) || tarefa.Status.Equals((int)Enumerators.StatusTarefa.Andamento))
                        return true;
                }
            }
            return false;
        }
    }
}
