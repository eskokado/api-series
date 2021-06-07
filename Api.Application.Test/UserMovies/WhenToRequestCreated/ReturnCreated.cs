using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.UserMovies;
using Api.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.UserMovies.WhenToRequestCreated
{
    public class ReturnCreated
    {
        private UserMoviesController _controller;

        [Fact(DisplayName = "É possivel realizar o Created")]
        public async Task It_is_possible_to_create_Created()
        {
            var serviceMock = new Mock<IUserMoviesService>();
            var id = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var movieId = Guid.NewGuid();

            serviceMock.Setup(m => m.Post(It.IsAny<UserMoviesDtoCreate>())).ReturnsAsync(
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

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var userMoviesDtoCreate = new UserMoviesDtoCreate
            {
                UserId = userId,
                MovieId = movieId,
            };

            var result = await _controller.Post(userMoviesDtoCreate);
            Assert.True(result is CreatedResult);

            var resultValue = ((CreatedResult) result).Value as UserMoviesDtoResult; 
            Assert.NotNull(resultValue);
            Assert.Equal(userMoviesDtoCreate.UserId, resultValue.UserId);
            Assert.Equal(userMoviesDtoCreate.MovieId, resultValue.MovieId);
        }
    }
}