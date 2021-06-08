using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Movie;
using Api.Domain.Services.Movie;
using Moq;
using Xunit;

namespace Api.Service.Test.Movie
{
    public class WhenItRunsGetMovie : MovieTest     
    {
        private IMovieService _service;
        private Mock<IMovieService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método GET (Movie).")]
        public async Task ItIsPossibleToRunGetMovie() 
        {
            _serviceMock = new Mock<IMovieService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(movieDtoResult);
            _service = _serviceMock.Object;

            var result = await _service.Get(MovieId);
            Assert.NotNull(result);
            Assert.True(result.Id == MovieId);
            Assert.Equal(MovieName, result.Name);
            Assert.Equal(MovieDescription, result.Description);
            Assert.Equal(MovieGenreId, result.GenreId);

            _serviceMock = new Mock<IMovieService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((MovieDtoResult) null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(MovieId);
            Assert.Null(_record);
        }
    }
}