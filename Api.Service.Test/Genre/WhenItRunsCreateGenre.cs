using System.Threading.Tasks;
using Api.Domain.Services.Genre;
using Moq;
using Xunit;

namespace Api.Service.Test.Genre
{
    public class WhenItRunsCreateGenre : GenreTest
    {
        private IGenreService _service;
        private Mock<IGenreService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Create (Genre).")]
        public async Task ItIsPossibleToRunCreateGenre() 
        {
            
            _serviceMock = new Mock<IGenreService>();
            _serviceMock.Setup(m => m.Post(genreDtoCreate)).ReturnsAsync(genreDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(genreDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(GenreId, result.Id);
            Assert.Equal(GenreName, result.Name);
        }
        
    }
}