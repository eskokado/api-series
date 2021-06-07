using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Movie;
using Api.Domain.Dtos.UserMovies;
using Api.Domain.Services;
using Api.Domain.Services.Movie;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.UserMovies.WhenToRequestUpdate
{
    public class ReturnBadRequest
    {
        private UserMoviesController _controller;

        [Fact(DisplayName = "É possivel realizar o Updated")]
        public async Task It_is_possible_to_create_Updated()
        {
            var serviceMock = new Mock<IUserMoviesService>();
            var id = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var movieId = Guid.NewGuid();

            serviceMock.Setup(m => m.Put(It.IsAny<UserMoviesDtoUpdate>())).ReturnsAsync(
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
                .AddModelError("Name", "É um campo obrigatório");


            var usermoviesDtoUpdate = new UserMoviesDtoUpdate
            {
                Id = id,
                UserId = userId,
                MovieId = movieId,
            };

            var result = await _controller.Put(usermoviesDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }   
        
    }
}