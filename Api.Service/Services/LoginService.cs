using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Repositories;
using Api.Domain.Services.User;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {

        private IUserRepository _repository;

        public LoginService(IUserRepository repository)
        {
            _repository = repository;
        }        
        
        public async Task<object> FindByLogin(UserEntity user)
        {
            if (user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                return await _repository.FindByLogin(user.Email);
            } 
            else 
            {
                return null;
            }
        }
    }
}