using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Services.Genre;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Genre.WhenToRequestDelete
{
    public class ReturnBadRequest
    {
        private GenresController _controller;

        [Fact(DisplayName = "É possivel realizar o Deleted")]
        public async Task It_is_possible_Deleted()
        {
            var serviceMock = new Mock<IGenreService>();
            var id = Guid.NewGuid();

            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);

            _controller = new GenresController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato inválido");

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);

            var resultValue = ((BadRequestObjectResult) result).Value; 
            Assert.NotNull(resultValue);
            Assert.False(_controller.ModelState.IsValid);
        }   
        
    }
}