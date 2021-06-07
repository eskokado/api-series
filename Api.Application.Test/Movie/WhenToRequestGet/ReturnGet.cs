using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Movie;
using Api.Domain.Services.Movie;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Movie.WhenToRequestGet
{
    public class ReturnGet
    {
        private MoviesController _controller;

        [Fact(DisplayName = "É possivel realizar o Get")]
        public async Task It_is_possible_Get()
        {
            var serviceMock = new Mock<IMovieService>();
            var id = Guid.NewGuid();
            var name = Faker.Name.FullName();
            var description = Faker.Lorem.Sentence(100);
            var genreId = Guid.NewGuid();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new MovieDtoResult 
                { 
                    Id = id,
                    Name = name,
                    Description = description,
                    GenreId = genreId,
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new MoviesController(serviceMock.Object);

            var result = await _controller.Get(id);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult) result).Value as MovieDtoResult; 
            Assert.NotNull(resultValue);
            Assert.Equal(id, resultValue.Id);
            Assert.Equal(name, resultValue.Name);
            Assert.Equal(description, resultValue.Description);
            Assert.Equal(genreId, resultValue.GenreId);
 
        }
        
    }
}