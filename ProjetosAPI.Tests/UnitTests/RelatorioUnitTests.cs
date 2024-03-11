using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProjetosAPI.Controllers;
using ProjetosAPI.Database;
using ProjetosAPI.Models;
using ProjetosAPI.Repositories;
using ProjetosAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjetosAPI.Tests.UnitTests
{
    public class RelatorioUnitTests
    {
        public RelatorioUnitTests()
        {
            
        }

        [Theory(DisplayName = "Não deve permitir que o usuário gere o relatório")]
        [InlineData(-1, 2, 30)]
        public void GerarRelatorio(int idUsuarioSolicitante, int idUsuarioMedido, int qtdeDiasCalculo)
        {
            #region Arrange
            var _relatorioRepositoryMock = new Mock<IRelatorioRepository>();
            var _usuarioRepositorioMock = new Mock<IUsuarioRepository>();

            var _relatorioControle = new RelatorioController(_relatorioRepositoryMock.Object, _usuarioRepositorioMock.Object);
            #endregion Arrange

            #region Act
            IActionResult actionResult = _relatorioControle.DesempenhoPorUsuario(idUsuarioSolicitante, idUsuarioMedido, qtdeDiasCalculo);
            ObjectResult? result = actionResult as ObjectResult;
            #endregion Act

            #region Assert
            Assert.Equal(400, result!.StatusCode);
            Assert.Equal(result!.Value, "Usuário solicitante não encontrado.");
            #endregion Assert
        }
    }
}
