using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Movie;
using Api.Domain.Dtos.UserMovies;
using Api.Domain.Services;
using Api.Domain.Services.Movie;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.UserMovies.WhenToRequestGetAll
{
    public class ReturnGetAll
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
                    },
                    new UserMoviesDtoResult
                    {
                        Id = Guid.NewGuid(),
                        UserId = Guid.NewGuid(),
                        MovieId = Guid.NewGuid(),
                        CreateAt = DateTime.UtcNow,
                        UpdateAt = DateTime.UtcNow
                    },
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

            var result = await _controller.GetAll();
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult) result).Value as IEnumerable<UserMoviesDtoResult>; 
            Assert.NotNull(resultValue);
            Assert.True(resultValue.Count() == 3);
        }
        
    }
}