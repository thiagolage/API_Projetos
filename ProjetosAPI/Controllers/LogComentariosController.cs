using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetosAPI.Repositories.Interfaces;

namespace ProjetosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogComentariosController : ControllerBase
    {
        private readonly ILogComentarioRepository _repository;

        public LogComentariosController(ILogComentarioRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Busca todos os logs de um determinado Comentário
        /// </summary>
        /// <param name="comentarioId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetByComentario")]
        public IActionResult GetByComentario(int comentarioId)
        {
            return Ok(_repository.GetByComentario(comentarioId));
        }
    }
}
