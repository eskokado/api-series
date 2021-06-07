using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.UserMovies;
using Api.Domain.Services;
using Api.Application.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.UserMovies.WhenToRequestGetAll
{
    public class ReturnBadRequest
    {
        private UserMoviesController _controller;

        [Fact(DisplayName = "É possivel realizar o GetAll")]
        public async Task It_is_possible_GetAll()
        {
            var serviceMock = new Mock<IUserMoviesService>();

            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                new List<UserMoviesDtoResult>
                {
                    new UserMoviesDtoResult
                    {
                        Id = Guid.NewGuid(),
                        UserId = Guid.NewGuid(),
                        MovieId = Guid.NewGuid(),
                        CreateAt = DateTime.UtcNow,
                        UpdateAt = DateTime.UtcNow
                    }
                }
            );

            _controller = new UserMoviesController(serviceMock.Object);
            _controller
                .ModelState
                .AddModelError("Root", "Rota Inválida");


            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }   
        
    }
}