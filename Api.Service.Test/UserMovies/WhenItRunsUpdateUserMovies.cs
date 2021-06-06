using System.Threading.Tasks;
using Api.Domain.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.UserMovies
{
    public class WhenItRunsUpdateUserMovies : UserMoviesTest
    {
        private IUserMoviesService _service;
        private Mock<IUserMoviesService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Update (UserMovies).")]
        public async Task ItIsPossibleToRunUpdateUserMovies() 
        {
            _serviceMock = new Mock<IUserMoviesService>();
            _serviceMock.Setup(m => m.Put(userMoviesDtoUpdate)).ReturnsAsync(userMoviesDtoResult);
            _service = _serviceMock.Object;

            var result = await _service.Put(userMoviesDtoUpdate);
            Assert.NotNull(result);
            Assert.Equal(UserMoviesId, result.Id);
            Assert.Equal(UserMoviesMovieId, result.MovieId);
            Assert.Equal(UserMoviesUserId, result.UserId);
        }
    }
}