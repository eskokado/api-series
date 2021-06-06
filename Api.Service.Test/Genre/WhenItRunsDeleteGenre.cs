using System;
using System.Threading.Tasks;
using Api.Domain.Services.Genre;
using Moq;
using Xunit;

namespace Api.Service.Test.Genre
{
    public class WhenItRunsDeleteGenre : GenreTest
    {
        private IGenreService _service;
        private Mock<IGenreService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Delete (Genre).")]
        public async Task ItIsPossibleToRunDeleteGenre() 
        {
            _serviceMock = new Mock<IGenreService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deleted = await _service.Delete(GenreId);
            Assert.True(deleted);

            _serviceMock = new Mock<IGenreService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            deleted = await _service.Delete(GenreId);
            Assert.False(deleted);
        }       
    }
}