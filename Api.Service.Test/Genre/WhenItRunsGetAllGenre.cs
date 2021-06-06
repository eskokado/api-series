using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Genre;
using Api.Domain.Services.Genre;
using Moq;
using Xunit;

namespace Api.Service.Test.Genre
{
    public class WhenItRunsGetAllGenre : GenreTest
    {
        private IGenreService _service;
        private Mock<IGenreService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método GET All (Genre).")]
        public async Task ItIsPossibleToRunGetAllGenre() 
        {
             _serviceMock = new Mock<IGenreService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listGenreDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<GenreDtoResult>();
            _serviceMock = new Mock<IGenreService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable<GenreDtoResult>);
            _service = _serviceMock.Object;

            var resultEmpty = await _service.GetAll();
            Assert.Empty(resultEmpty);
            Assert.True(resultEmpty.Count() == 0);
        }
    }
}