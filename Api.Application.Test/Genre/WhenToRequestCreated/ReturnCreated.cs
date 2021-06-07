using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Genre;
using Api.Domain.Services.Genre;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Genre.WhenToRequestCreated
{
    public class ReturnCreated
    {
        private GenresController _controller;

        [Fact(DisplayName = "É possivel realizar o Created")]
        public async Task It_is_possible_to_create_Created()
        {
            var serviceMock = new Mock<IGenreService>();
            var name = Faker.Name.FullName();

            serviceMock.Setup(m => m.Post(It.IsAny<GenreDtoCreate>())).ReturnsAsync(
                new GenreDtoCreateResult 
                { 
                    Id = Guid.NewGuid(),
                    Name = name,
                    CreateAt = DateTime.UtcNow
                }
            );

            _controller = new GenresController(serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var genreDtoCreate = new GenreDtoCreate
            {
                Name = name,
            };

            var result = await _controller.Post(genreDtoCreate);
            Assert.True(result is CreatedResult);

            var resultValue = ((CreatedResult) result).Value as GenreDtoCreateResult; 
            Assert.NotNull(resultValue);
            Assert.Equal(genreDtoCreate.Name, resultValue.Name);
        }
    }
}