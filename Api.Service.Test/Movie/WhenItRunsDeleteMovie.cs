using System;
using System.Threading.Tasks;
using Api.Domain.Services.Movie;
using Moq;
using Xunit;

namespace Api.Service.Test.Movie
{
    public class WhenItRunsDeleteMovie : MovieTest
    {
        private IMovieService _service;
        private Mock<IMovieService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Delete (Movie).")]
        public async Task ItIsPossibleToRunDeleteMovie() 
        {
            _serviceMock = new Mock<IMovieService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deleted = await _service.Delete(MovieId);
            Assert.True(deleted);

            _serviceMock = new Mock<IMovieService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            deleted = await _service.Delete(MovieId);
            Assert.False(deleted);
        }       
    }
}