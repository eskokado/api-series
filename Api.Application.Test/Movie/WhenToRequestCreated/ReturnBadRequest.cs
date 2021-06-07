using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Movie;
using Api.Domain.Services.Movie;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Movie.WhenToRequestCreated
{
    public class ReturnBadRequest
    {
        private MoviesController _controller;

        [Fact(DisplayName = "É possivel realizar o Created")]
        public async Task It_is_possible_to_create_Created()
        {
            var serviceMock = new Mock<IMovieService>();
            var id = Guid.NewGuid();
            var name = Faker.Name.FullName();
            var description = Faker.Lorem.Sentence(100);
            var genreId = Guid.NewGuid();

            serviceMock
                .Setup(m => m.Post(It.IsAny<MovieDtoCreate>()))
                .ReturnsAsync(new MovieDtoCreateResult {
                    Id = id,
                    Name = name,
                    Description = description,
                    GenreId = genreId,
                    CreateAt = DateTime.UtcNow
                });

            _controller = new MoviesController(serviceMock.Object);
            _controller
                .ModelState
                .AddModelError("Name", "É um campo obrigatório");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url
                .Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>()))
                .Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var movieDtoCreate =
                new MovieDtoCreate 
                { 
                    Name = name,
                    Description = description,
                    GenreId = genreId,
                };

            var result = await _controller.Post(movieDtoCreate);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
