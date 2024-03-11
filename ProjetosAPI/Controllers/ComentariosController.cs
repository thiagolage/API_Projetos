using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetosAPI.Repositories.Interfaces;
using System.Net;

namespace ProjetosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly IComentarioRepository _repository;

        public ComentariosController(IComentarioRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Lista todos os Comentários de todas as Tarefas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            var listaComentarios = _repository.Get();

            return Ok(listaComentarios);
        }

        /// <summary>
        /// Busca um Comentário através de um Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            var usuario = _repository.GetById(id);
            if (usuario == null)
                return NotFound("Comentário não encontrado!");

            return Ok(usuario);
        }

        [HttpGet]
        [Route("GetByTarefa")]
        public IActionResult GetByTarefa(int idTarefa)
        {
            var listaComentarios = _repository.GetByTarefa(idTarefa);

            return Ok(listaComentarios);
        }

        /// <summary>
        /// Adiciona um novo Comentário
        /// </summary>
        /// <param name="comentario"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddComentario")]
        public IActionResult Add([FromBody] Comentario comentario)
        {
            _repository.Add(comentario);
            return Ok(comentario);
        }

        /// <summary>
        /// Atualiza os dados de um Comentário
        /// </summary>
        /// <param name="comentario"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateComentario")]
        public IActionResult Update([FromBody] Comentario comentario)
        {
            _repository.Update(comentario);

            return Ok(comentario);
        }

        /// <summary>
        /// Exclui um Comentário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteComentario")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok(HttpStatusCode.OK);
        }
    }
}
