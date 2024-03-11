using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetosAPI.Models;
using ProjetosAPI.Repositories.Interfaces;

namespace ProjetosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuariosController(IUsuarioRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Lista todos os usuários cadastrados na base de dados
        /// </summary>
        /// <returns>Todos os usuários</returns>
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            var listaUsuarios = _repository.Get();

            return Ok(listaUsuarios);
        }

        /// <summary>
        /// Busca um usuário através de seu Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            var usuario = _repository.GetById(id);
            if (usuario == null)
                return NotFound("Não encontrado!");

            return Ok(usuario);
        }

        /// <summary>
        /// Adicionar um novo Usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddUsuario")]
        public IActionResult Add([FromBody] Usuario usuario)
        {
            _repository.Add(usuario);
            return Ok(usuario);
        }

        /// <summary>
        /// Atualizar dados do Usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateUsuario")]
        public IActionResult Update([FromBody] Usuario usuario)
        {
            _repository.Update(usuario);

            return Ok(usuario);
        }

        /// <summary>
        /// Inativar um Usuário (Exclusão lógica)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteUsuario")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok();
        }
    }
}
