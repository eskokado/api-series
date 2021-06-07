using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Genre;
using Api.Domain.Services.Genre;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Genre.WhenToRequestGet
{
    public class ReturnBadRequest
    {
        private GenresController _controller;

        [Fact(DisplayName = "É possivel realizar o Get")]
        public async Task It_is_possible_Get
        ()
        {
            var serviceMock = new Mock<IGenreService>();
            var id = Guid.NewGuid();
            var name = Faker.Name.FullName();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new GenreDtoResult 
                { 
                    Id = id,
                    Name = name,
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new GenresController(serviceMock.Object);
            _controller
                .ModelState
                .AddModelError("Id", "Registro inexistente");


            var result = await _controller.Get(id);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }   
        
    }
}