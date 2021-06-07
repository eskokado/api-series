using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Movie;
using Api.Domain.Services.Movie;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Movie.WhenToRequestFindCompleteByDescription
{
    public class ReturnFind
    {
        private MoviesController _controller;

        [Fact(DisplayName = "É possivel realizar o Find")]
        public async Task It_is_possible_Find()
        {
            var serviceMock = new Mock<IMovieService>();

            serviceMock.Setup(m => m.FindCompleteByDescription("a")).ReturnsAsync(
                new List<MovieDtoResult>
                {
                    new MovieDtoResult
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Description = Faker.Lorem.Sentence(100),
                        GenreId = Guid.NewGuid(),
                        CreateAt = DateTime.UtcNow,
                        UpdateAt = DateTime.UtcNow
                    },
                    new MovieDtoResult
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Description = Faker.Lorem.Sentence(100),
                        GenreId = Guid.NewGuid(),
                        CreateAt = DateTime.UtcNow,
                        UpdateAt = DateTime.UtcNow
                    },
                    new MovieDtoResult
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Description = Faker.Lorem.Sentence(100),
                        GenreId = Guid.NewGuid(),
                        CreateAt = DateTime.UtcNow,
                        UpdateAt = DateTime.UtcNow
                    }
                }
            );

            _controller = new MoviesController(serviceMock.Object);

            var result = await _controller.FindCompleteByDescription("a");
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult) result).Value as IEnumerable<MovieDtoResult>; 
            Assert.NotNull(resultValue);
            Assert.True(resultValue.Count() == 3);
        }
        
    }
}