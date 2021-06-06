using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Genre;
using Api.Domain.Services.Genre;
using Moq;
using Xunit;

namespace Api.Service.Test.Genre
{
    public class WhenItRunsGetGenre : GenreTest     
    {
        private IGenreService _service;
        private Mock<IGenreService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método GET (Genre).")]
        public async Task ItIsPossibleToRunGetGenre() 
        {
            _serviceMock = new Mock<IGenreService>();
            _serviceMock.Setup(m => m.Get(GenreId)).ReturnsAsync(genreDtoResult);
            _service = _serviceMock.Object;

            var result = await _service.Get(GenreId);
            Assert.NotNull(result);
            Assert.True(result.Id == GenreId);
            Assert.Equal(GenreName, result.Name);

            _serviceMock = new Mock<IGenreService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((GenreDtoResult) null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(GenreId);
            Assert.Null(_record);
        }
    }
}