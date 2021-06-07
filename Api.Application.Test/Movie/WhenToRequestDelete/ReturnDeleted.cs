using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Services.Movie;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Movie.WhenToRequestDelete
{
    public class ReturnDeleted
    {
        private MoviesController _controller;

        [Fact(DisplayName = "É possivel realizar o Deleted")]
        public async Task It_is_possible_Deleted()
        {
            var serviceMock = new Mock<IMovieService>();

            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _controller = new MoviesController(serviceMock.Object);

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult) result).Value; 
            Assert.NotNull(resultValue);
            Assert.True((Boolean)resultValue);
 
        }
        
    }
}