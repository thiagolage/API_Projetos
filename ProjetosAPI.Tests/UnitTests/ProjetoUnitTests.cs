using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjetosAPI.Controllers;
using ProjetosAPI.Models;
using ProjetosAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetosAPI.Tests.UnitTests
{
    public class ProjetoUnitTests
    {
        public ProjetoUnitTests()
        {

        }

        [Theory(DisplayName = "Deve adicionar um projeto com sucesso")]
        [InlineData(1, 1)]
        public void TesteAddProjeto(int idCriador, int idAssignee)
        {
            #region Arrange
            var objProjeto = new Fixture().Create<Projeto>();
            objProjeto.DataCriacao = DateTime.Now;
            objProjeto.IdUsuarioCriador = idCriador;
            objProjeto.IdUsuarioAssignee = idAssignee;

            var _projetoRepositorioMock = new Mock<IProjetoRepository>();
            var _tarefaRepositoryMock = new Mock<ITarefaRepository>();
            var _comentarioRepositoryMock = new Mock<IComentarioRepository>();

            var _projetoControle = new ProjetosController(_projetoRepositorioMock.Object, _tarefaRepositoryMock.Object, _comentarioRepositoryMock.Object);
            #endregion Arrange

            #region Act
            IActionResult actionResult = _projetoControle.Add(objProjeto);
            OkObjectResult? okResult = actionResult as OkObjectResult;
            #endregion Act

            #region Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(objProjeto, okResult.Value);
            #endregion Assert
        }

        [Theory(DisplayName = "Deve atualizar um projeto com sucesso")]
        [InlineData(1, 1)]
        public void TesteUpdateProjeto(int idCriador, int idAssignee)
        {
            #region Arrange
            var objProjeto = new Fixture().Create<Projeto>();
            objProjeto.DataCriacao = DateTime.Now;
            objProjeto.IdUsuarioCriador = idCriador;
            objProjeto.IdUsuarioAssignee = idAssignee;

            var _projetoRepositorioMock = new Mock<IProjetoRepository>();
            var _tarefaRepositoryMock = new Mock<ITarefaRepository>();
            var _comentarioRepositoryMock = new Mock<IComentarioRepository>();

            var _projetoControle = new ProjetosController(_projetoRepositorioMock.Object, _tarefaRepositoryMock.Object, _comentarioRepositoryMock.Object);
            #endregion Arrange

            #region Act
            IActionResult actionResult = _projetoControle.Update(objProjeto);
            OkObjectResult? okResult = actionResult as OkObjectResult;
            #endregion Act

            #region Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(objProjeto, okResult.Value);
            #endregion Assert
        }

        [Fact(DisplayName = "Deve remover um projeto com sucesso")]
        public void TesteRemoveProjeto()
        {
            #region Arrange
            var _projetoRepositorioMock = new Mock<IProjetoRepository>();
            var _tarefaRepositoryMock = new Mock<ITarefaRepository>();
            var _comentarioRepositoryMock = new Mock<IComentarioRepository>();

            var _projetoControle = new ProjetosController(_projetoRepositorioMock.Object, _tarefaRepositoryMock.Object, _comentarioRepositoryMock.Object);
            #endregion Arrange

            #region Act
            IActionResult actionResult = _projetoControle.Delete(1);
            OkObjectResult? okResult = actionResult as OkObjectResult;
            #endregion Act

            #region Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            #endregion Assert
        }
    }
}
