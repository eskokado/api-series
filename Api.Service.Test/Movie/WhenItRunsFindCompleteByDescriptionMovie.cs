using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Movie;
using Api.Domain.Services.Movie;
using Moq;
using Xunit;

namespace Api.Service.Test.Movie
{
    public class WhenItRunsFindCompleteByDescriptionMovie : MovieTest
    {
        private IMovieService _service;
        private Mock<IMovieService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Find Complete By Description (Movie).")]
        public async Task ItIsPossibleToRunFindByDescriptionMovie() 
        {
             _serviceMock = new Mock<IMovieService>();
            _serviceMock.Setup(m => m.FindCompleteByDescription("a")).ReturnsAsync(listMovieDto);
            _service = _serviceMock.Object;

            var result = await _service.FindCompleteByDescription("a");
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<MovieDtoResult>();
            _serviceMock = new Mock<IMovieService>();
            _serviceMock.Setup(m => m.FindCompleteByDescription("a")).ReturnsAsync(_listResult.AsEnumerable<MovieDtoResult>);
            _service = _serviceMock.Object;

            var resultEmpty = await _service.FindCompleteByDescription("a");
            Assert.Empty(resultEmpty);
            Assert.True(resultEmpty.Count() == 0);
        }
    }
}