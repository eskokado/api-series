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
    public class ReturnUpdated
    {
        private MoviesController _controller;

        [Fact(DisplayName = "É possivel realizar o Updated")]
        public async Task It_is_possible_to_create_Updated()
        {
            var serviceMock = new Mock<IMovieService>();
            var id = Guid.NewGuid();
            var name = Faker.Name.FullName();
            var description = Faker.Lorem.Sentence(25);
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


            var movieDtoUpdate = new MovieDtoUpdate
            {
                Id = id,
                Name = name,
                Description = description,
                GenreId = genreId,
            };

            var result = await _controller.Put(movieDtoUpdate);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult) result).Value as MovieDtoUpdateResult; 
            Assert.NotNull(resultValue);
            Assert.Equal(movieDtoUpdate.Id, resultValue.Id);
            Assert.Equal(movieDtoUpdate.Name, resultValue.Name);
            Assert.Equal(movieDtoUpdate.Description, resultValue.Description);
            Assert.Equal(movieDtoUpdate.GenreId, resultValue.GenreId);
 
        }
        
    }
}