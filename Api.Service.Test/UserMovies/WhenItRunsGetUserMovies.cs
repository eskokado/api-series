using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.UserMovies;
using Api.Domain.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.UserMovies
{
    public class WhenItRunsGetUserMovies : UserMoviesTest     
    {
        private IUserMoviesService _service;
        private Mock<IUserMoviesService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método GET (UserMovies).")]
        public async Task ItIsPossibleToRunGetUserMovies() 
        {
            _serviceMock = new Mock<IUserMoviesService>();
            _serviceMock.Setup(m => m.Get(UserMoviesId)).ReturnsAsync(userMoviesDtoResult);
            _service = _serviceMock.Object;

            var result = await _service.Get(UserMoviesId);
            Assert.NotNull(result);
            Assert.True(result.Id == UserMoviesId);
            Assert.Equal(UserMoviesMovieId, result.MovieId);
            Assert.Equal(UserMoviesUserId, result.UserId);

            _serviceMock = new Mock<IUserMoviesService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserMoviesDtoResult) null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(UserMoviesId);
            Assert.Null(_record);
        }
    }
}