using System.Threading.Tasks;
using Api.Domain.Services.Movie;
using Moq;
using Xunit;

namespace Api.Service.Test.Movie
{
    public class WhenItRunsUpdateMovie : MovieTest
    {
        private IMovieService _service;
        private Mock<IMovieService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Update (Movie).")]
        public async Task ItIsPossibleToRunUpdateMovie() 
        {
            
            _serviceMock = new Mock<IMovieService>();
            _serviceMock.Setup(m => m.Put(movieDtoUpdate)).ReturnsAsync(movieDtoUpdateResult);
            _service = _serviceMock.Object;

            var result = await _service.Put(movieDtoUpdate);
            Assert.NotNull(result);
            Assert.Equal(MovieId, result.Id);
            Assert.Equal(MovieNameUpdate, result.Name);
            Assert.Equal(MovieDescriptionUpdate, result.Description);
            Assert.Equal(MovieGenreIdUpdate, result.GenreId);
        }
        
    }
}