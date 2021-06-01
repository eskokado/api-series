using System;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
    public class WhenItRunsGet : UserTest     
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método GET.")]
        public async Task ItIsPossibleToRunGet() 
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(UserId)).ReturnsAsync(userDtoResult);
            _service = _serviceMock.Object;

            var result = await _service.Get(UserId);
            Assert.NotNull(result);
            Assert.True(result.Id == UserId);
            Assert.Equal(UserName, result.Name);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDtoResult) null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(UserId);
            Assert.Null(_record);
        }
    }
}