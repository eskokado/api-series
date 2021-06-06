using System.Threading.Tasks;
using Api.Domain.Services.Movie;
using Moq;
using Xunit;

namespace Api.Service.Test.Movie
{
    public class WhenItRunsCreateMovie : MovieTest
    {
        private IMovieService _service;
        private Mock<IMovieService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Create (Movie).")]
        public async Task ItIsPossibleToRunCreateMovie() 
        {
            
            _serviceMock = new Mock<IMovieService>();
            _serviceMock.Setup(m => m.Post(movieDtoCreate)).ReturnsAsync(movieDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(movieDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(MovieId, result.Id);
            Assert.Equal(MovieName, result.Name);
        }
        
    }
}