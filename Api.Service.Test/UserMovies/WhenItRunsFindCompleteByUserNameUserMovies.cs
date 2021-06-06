using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.UserMovies;
using Api.Domain.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.UserMovies
{
    public class WhenItRunsFindCompleteByUserNameUserMovies : UserMoviesTest
    {
        private IUserMoviesService _service;
        private Mock<IUserMoviesService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Find Complete By Genre Name (UserMovies).")]
        public async Task ItIsPossibleToRunFindByUserNameUserMovies() 
        {
             _serviceMock = new Mock<IUserMoviesService>();
            _serviceMock.Setup(m => m.FindCompleteByUserName("a")).ReturnsAsync(listUserMoviesDto);
            _service = _serviceMock.Object;

            var result = await _service.FindCompleteByUserName("a");
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<UserMoviesDtoResult>();
            _serviceMock = new Mock<IUserMoviesService>();
            _serviceMock.Setup(m => m.FindCompleteByUserName("a")).ReturnsAsync(_listResult.AsEnumerable<UserMoviesDtoResult>);
            _service = _serviceMock.Object;

            var resultEmpty = await _service.FindCompleteByUserName("a");
            Assert.Empty(resultEmpty);
            Assert.True(resultEmpty.Count() == 0);
        }
    }
}