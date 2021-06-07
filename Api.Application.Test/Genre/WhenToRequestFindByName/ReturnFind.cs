using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Genre;
using Api.Domain.Services.Genre;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Genre.WhenToRequestFindByName
{
    public class ReturnFind
    {
        private GenresController _controller;

        [Fact(DisplayName = "É possivel realizar o Find")]
        public async Task It_is_possible_Find()
        {
            var serviceMock = new Mock<IGenreService>();

            serviceMock.Setup(m => m.FindByName("a")).ReturnsAsync(
                new List<GenreDtoResult>
                {
                    new GenreDtoResult
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        CreateAt = DateTime.UtcNow,
                        UpdateAt = DateTime.UtcNow
                    },
                    new GenreDtoResult
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        CreateAt = DateTime.UtcNow,
                        UpdateAt = DateTime.UtcNow
                    },
                    new GenreDtoResult
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        CreateAt = DateTime.UtcNow,
                        UpdateAt = DateTime.UtcNow
                    }
                }
            );

            _controller = new GenresController(serviceMock.Object);

            var result = await _controller.FindByName("a");
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult) result).Value as IEnumerable<GenreDtoResult>; 
            Assert.NotNull(resultValue);
            Assert.True(resultValue.Count() == 3);
        }
        
    }
}