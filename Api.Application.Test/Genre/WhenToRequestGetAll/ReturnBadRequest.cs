using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Genre;
using Api.Domain.Services.Genre;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Genre.WhenToRequestGetAll
{
    public class ReturnBadRequest
    {
        private GenresController _controller;

        [Fact(DisplayName = "É possivel realizar o GetAll")]
        public async Task It_is_possible_GetAll
        ()
        {
            var serviceMock = new Mock<IGenreService>();

            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                new List<GenreDtoResult>
                {
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
            _controller
                .ModelState
                .AddModelError("Root", "Rota Inválida");


            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }   
        
    }
}