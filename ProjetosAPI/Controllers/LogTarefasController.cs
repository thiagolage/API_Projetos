using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetosAPI.Repositories.Interfaces;

namespace ProjetosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogTarefasController : ControllerBase
    {
        private readonly ILogTarefaRepository _repository;

        public LogTarefasController(ILogTarefaRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Busca todos os logs de uma determinada Tarefa
        /// </summary>
        /// <param name="tarefaId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetByTarefa")]
        public IActionResult GetByTarefa(int tarefaId)
        {
            return Ok(_repository.GetByTarefa(tarefaId));
        }
    }
}
