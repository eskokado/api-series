using System;
using System.Threading.Tasks;
using Api.Domain.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.UserMovies
{
    public class WhenItRunsDeleteUserMovies : UserMoviesTest
    {
        private IUserMoviesService _service;
        private Mock<IUserMoviesService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Delete (UserMovies).")]
        public async Task ItIsPossibleToRunDeleteUserMovies() 
        {
            _serviceMock = new Mock<IUserMoviesService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deleted = await _service.Delete(UserMoviesId);
            Assert.True(deleted);

            _serviceMock = new Mock<IUserMoviesService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            deleted = await _service.Delete(UserMoviesId);
            Assert.False(deleted);
        }       
    }
}