using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetosAPI.Enums;
using ProjetosAPI.Models;
using ProjetosAPI.Repositories.Interfaces;

namespace ProjetosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioRepository _relatoriorepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public RelatorioController(IRelatorioRepository relatorioRepository, IUsuarioRepository usuarioRepository)
        {
            this._relatoriorepository = relatorioRepository;
            this._usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Relatório de desempenho por usuário, pode-se escolher o número de dias para análise (últimos X dias)
        /// </summary>
        /// <param name="idUsuarioSolicitante"></param>
        /// <param name="idUsuarioMedido"></param>
        /// <param name="qtdeDiasCalculo"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("DesempenhoPorUsuario")]
        public IActionResult DesempenhoPorUsuario(int idUsuarioSolicitante, int idUsuarioMedido, int qtdeDiasCalculo)
        {
            Usuario usuario = _usuarioRepository.GetById(idUsuarioSolicitante);

            if (usuario != null)
            {
                if (usuario.Funcao.Equals((int)Enumerators.Funcao.Gerente))
                {
                    var relatorio = _relatoriorepository.DesempenhoPorUsuario(idUsuarioSolicitante, idUsuarioMedido, qtdeDiasCalculo);
                    return Ok(relatorio);
                }
                else
                    return StatusCode(400, "Somente usuários com perfil Gerente podem solicitar relatórios.");
            }
            else
                return StatusCode(400, "Usuário solicitante não encontrado.");
        }
    }
}
