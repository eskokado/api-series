using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Genre;
using Api.Domain.Services.Genre;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Genre.WhenToRequestUpdate
{
    public class ReturnUpdated
    {
        private GenresController _controller;

        [Fact(DisplayName = "É possivel realizar o Updated")]
        public async Task It_is_possible_to_create_Updated()
        {
            var serviceMock = new Mock<IGenreService>();
            var id = Guid.NewGuid();
            var name = Faker.Name.FullName();

            serviceMock.Setup(m => m.Put(It.IsAny<GenreDtoUpdate>())).ReturnsAsync(
                new GenreDtoUpdateResult 
                { 
                    Id = id,
                    Name = name,
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new GenresController(serviceMock.Object);


            var genreDtoUpdate = new GenreDtoUpdate
            {
                Id = id,
                Name = name,
            };

            var result = await _controller.Put(genreDtoUpdate);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult) result).Value as GenreDtoUpdateResult; 
            Assert.NotNull(resultValue);
            Assert.Equal(genreDtoUpdate.Id, resultValue.Id);
            Assert.Equal(genreDtoUpdate.Name, resultValue.Name);
 
        }
        
    }
}