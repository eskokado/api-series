using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Services.Movie;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Movie.WhenToRequestDelete
{
    public class ReturnBadRequest
    {
        private MoviesController _controller;

        [Fact(DisplayName = "É possivel realizar o Deleted")]
        public async Task It_is_possible_Deleted()
        {
            var serviceMock = new Mock<IMovieService>();
            var id = Guid.NewGuid();

            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);

            _controller = new MoviesController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato inválido");

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);

            var resultValue = ((BadRequestObjectResult) result).Value; 
            Assert.NotNull(resultValue);
            Assert.False(_controller.ModelState.IsValid);
        }   
        
    }
}