using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Services.User
{
    public interface ILoginService
    {
         Task<object> FindByLogin(UserEntity user);
    }
}