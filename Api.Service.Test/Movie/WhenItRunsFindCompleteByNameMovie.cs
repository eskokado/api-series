using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Movie;
using Api.Domain.Services.Movie;
using Moq;
using Xunit;

namespace Api.Service.Test.Movie
{
    public class WhenItRunsFindCompleteByNameMovie : MovieTest
    {
        private IMovieService _service;
        private Mock<IMovieService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Find Complete By Name (Movie).")]
        public async Task ItIsPossibleToRunFindByNameMovie() 
        {
             _serviceMock = new Mock<IMovieService>();
            _serviceMock.Setup(m => m.FindCompleteByName("a")).ReturnsAsync(listMovieDto);
            _service = _serviceMock.Object;

            var result = await _service.FindCompleteByName("a");
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<MovieDtoResult>();
            _serviceMock = new Mock<IMovieService>();
            _serviceMock.Setup(m => m.FindCompleteByName("a")).ReturnsAsync(_listResult.AsEnumerable<MovieDtoResult>);
            _service = _serviceMock.Object;

            var resultEmpty = await _service.FindCompleteByName("a");
            Assert.Empty(resultEmpty);
            Assert.True(resultEmpty.Count() == 0);
        }
    }
}