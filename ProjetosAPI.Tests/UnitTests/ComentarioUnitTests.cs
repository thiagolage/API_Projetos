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
    public class ComentarioUnitTests
    {
        public ComentarioUnitTests()
        {
            
        }

        [Fact(DisplayName = "Deve adicionar um comentario com sucesso")]
        public void TesteAddComentario()
        {
            #region Arrange
            var objComentario = new Fixture().Create<Comentario>();

            var _comentarioRepositoryMock = new Mock<IComentarioRepository>();

            var _ComentarioControle = new ComentariosController(_comentarioRepositoryMock.Object);
            #endregion Arrange

            #region Act
            IActionResult actionResult = _ComentarioControle.Add(objComentario);
            OkObjectResult? okResult = actionResult as OkObjectResult;
            #endregion Act

            #region Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(objComentario, okResult.Value);
            #endregion Assert
        }

        [Fact(DisplayName = "Deve atualizar um comentario com sucesso")]
        public void TesteUpdateComentario()
        {
            #region Arrange
            var objComentario = new Fixture().Create<Comentario>();

            var _comentarioRepositoryMock = new Mock<IComentarioRepository>();

            var _ComentarioControle = new ComentariosController(_comentarioRepositoryMock.Object);
            #endregion Arrange

            #region Act
            IActionResult actionResult = _ComentarioControle.Update(objComentario);
            OkObjectResult? okResult = actionResult as OkObjectResult;
            #endregion Act

            #region Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(objComentario, okResult.Value);
            #endregion Assert
        }

        [Fact(DisplayName = "Deve remover um comentario com sucesso")]
        public void TesteRemoveComentario()
        {
            #region Arrange
            var _comentarioRepositoryMock = new Mock<IComentarioRepository>();

            var _ComentarioControle = new ComentariosController(_comentarioRepositoryMock.Object);
            #endregion Arrange

            #region Act
            IActionResult actionResult = _ComentarioControle.Delete(1);
            OkObjectResult? okResult = actionResult as OkObjectResult;
            #endregion Act

            #region Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            #endregion Assert
        }
    }
}
