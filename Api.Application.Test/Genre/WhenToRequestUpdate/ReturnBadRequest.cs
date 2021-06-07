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
    public class ReturnBadRequest
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
            _controller
                .ModelState
                .AddModelError("Name", "É um campo obrigatório");


            var genreDtoUpdate = new GenreDtoUpdate
            {
                Id = id,
                Name = name,
            };

            var result = await _controller.Put(genreDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }   
        
    }
}