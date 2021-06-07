using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Movie;
using Api.Domain.Services.Movie;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Movie.WhenToRequestUpdate
{
    public class ReturnBadRequest
    {
        private MoviesController _controller;

        [Fact(DisplayName = "É possivel realizar o Updated")]
        public async Task It_is_possible_to_create_Updated()
        {
            var serviceMock = new Mock<IMovieService>();
            var id = Guid.NewGuid();
            var name = Faker.Name.FullName();
            var description = Faker.Lorem.Sentence(100);
            var genreId = Guid.NewGuid();

            serviceMock.Setup(m => m.Put(It.IsAny<MovieDtoUpdate>())).ReturnsAsync(
                new MovieDtoUpdateResult 
                { 
                    Id = id,
                    Name = name,
                    Description = description,
                    GenreId = genreId,
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new MoviesController(serviceMock.Object);
            _controller
                .ModelState
                .AddModelError("Name", "É um campo obrigatório");


            var movieDtoUpdate = new MovieDtoUpdate
            {
                Id = id,
                Name = name,
                Description = description,
                GenreId = genreId,
            };

            var result = await _controller.Put(movieDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }   
        
    }
}