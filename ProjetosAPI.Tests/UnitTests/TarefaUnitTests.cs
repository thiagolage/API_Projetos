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
    public class TarefaUnitTests
    {
        public TarefaUnitTests()
        {
            
        }

        [Theory(DisplayName = "Deve adicionar uma tarefa com sucesso")]
        [InlineData(1, 1, 1, 1)]
        public void TesteAddTarefa(int codStatus, int codPrioridade, int codUsuarioAssignee, int codProjeto)
        {
            #region Arrange
            var objTarefa = new Fixture().Create<Tarefa>();
            objTarefa.DataCriacao = DateTime.Now;
            objTarefa.DataVencimento = DateTime.Now.AddDays(7);
            objTarefa.DataConclusao = null;
            objTarefa.Status = codStatus;
            objTarefa.Prioridade = codPrioridade;
            objTarefa.IdUsuarioAssignee = codUsuarioAssignee;
            objTarefa.IdProjeto = codProjeto;

            var _tarefaRepositoryMock = new Mock<ITarefaRepository>();
            var _comentarioRepositoryMock = new Mock<IComentarioRepository>();

            var _tarefaControle = new TarefasController(_tarefaRepositoryMock.Object, _comentarioRepositoryMock.Object);
            #endregion Arrange

            #region Act
            IActionResult actionResult = _tarefaControle.Add(objTarefa);
            OkObjectResult? okResult = actionResult as OkObjectResult;
            #endregion Act

            #region Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(objTarefa, okResult.Value);
            #endregion Assert
        }

        [Theory(DisplayName = "Deve atualizar uma tarefa com sucesso")]
        [InlineData(1, 1, 1, 1)]
        public void TesteUpdateTarefa(int codStatus, int codPrioridade, int codUsuarioAssignee, int codProjeto)
        {
            #region Arrange
            var objTarefa = new Fixture().Create<Tarefa>();
            objTarefa.DataCriacao = DateTime.Now;
            objTarefa.DataVencimento = DateTime.Now.AddDays(7);
            objTarefa.DataConclusao = null;
            objTarefa.Status = codStatus;
            objTarefa.Prioridade = codPrioridade;
            objTarefa.IdUsuarioAssignee = codUsuarioAssignee;
            objTarefa.IdProjeto = codProjeto;

            var _tarefaRepositoryMock = new Mock<ITarefaRepository>();
            var _comentarioRepositoryMock = new Mock<IComentarioRepository>();

            var _tarefaControle = new TarefasController(_tarefaRepositoryMock.Object, _comentarioRepositoryMock.Object);
            #endregion Arrange

            #region Act
            IActionResult actionResult = _tarefaControle.Update(objTarefa);
            OkObjectResult? okResult = actionResult as OkObjectResult;
            #endregion Act

            #region Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(objTarefa, okResult.Value);
            #endregion Assert
        }

        [Fact(DisplayName = "Deve remover uma tarefa com sucesso")]
        public void TesteRemoveTarefa()
        {
            #region Arrange
            var _tarefaRepositoryMock = new Mock<ITarefaRepository>();
            var _comentarioRepositoryMock = new Mock<IComentarioRepository>();

            var _tarefaControle = new TarefasController(_tarefaRepositoryMock.Object, _comentarioRepositoryMock.Object);
            #endregion Arrange

            #region Act
            IActionResult actionResult = _tarefaControle.Delete(1);
            OkObjectResult? okResult = actionResult as OkObjectResult;
            #endregion Act

            #region Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            #endregion Assert
        }
    }
}
