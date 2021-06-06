using System.Threading.Tasks;
using Api.Domain.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.UserMovies
{
    public class WhenItRunsCreateUserMovies : UserMoviesTest
    {
        private IUserMoviesService _service;
        private Mock<IUserMoviesService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Create (UserMovies).")]
        public async Task ItIsPossibleToRunCreateUserMovies() 
        {
            
            _serviceMock = new Mock<IUserMoviesService>();
            _serviceMock.Setup(m => m.Post(userMoviesDtoCreate)).ReturnsAsync(userMoviesDtoResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(userMoviesDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(UserMoviesId, result.Id);
            Assert.Equal(UserMoviesMovieId, result.MovieId);
            Assert.Equal(UserMoviesUserId, result.UserId);
        }
        
    }
}