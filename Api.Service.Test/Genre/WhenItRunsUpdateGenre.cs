using System.Threading.Tasks;
using Api.Domain.Services.Genre;
using Moq;
using Xunit;

namespace Api.Service.Test.Genre
{
    public class WhenItRunsUpdateGenre : GenreTest
    {
        private IGenreService _service;
        private Mock<IGenreService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Update (Genre).")]
        public async Task ItIsPossibleToRunUpdateGenre() 
        {
            
            _serviceMock = new Mock<IGenreService>();
            _serviceMock.Setup(m => m.Put(genreDtoUpdate)).ReturnsAsync(genreDtoUpdateResult);
            _service = _serviceMock.Object;

            var result = await _service.Put(genreDtoUpdate);
            Assert.NotNull(result);
            Assert.Equal(GenreId, result.Id);
            Assert.Equal(GenreNameUpdate, result.Name);
        }
        
    }
}