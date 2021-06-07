using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.UserMovies;
using Api.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.UserMovies.WhenToRequestGet
{
    public class ReturnBadRequest
    {
        private UserMoviesController _controller;

        [Fact(DisplayName = "É possivel realizar o Get")]
        public async Task It_is_possible_Get
        ()
        {
            var serviceMock = new Mock<IUserMoviesService>();
            var id = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var movieId = Guid.NewGuid();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new UserMoviesDtoResult 
                { 
                    Id = id,
                    UserId = userId,
                    MovieId = movieId,
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new UserMoviesController(serviceMock.Object);
            _controller
                .ModelState
                .AddModelError("Id", "Registro inexistente");


            var result = await _controller.Get(id);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }   
        
    }
}