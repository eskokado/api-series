using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos;

namespace Api.Domain.Services.User
{
    public interface IUserService
    {
        Task<UserDtoResult> Get (Guid id);
        Task<IEnumerable<UserDtoResult>> GetAll();
        Task<UserDtoCreateResult> Post(UserDtoCreate user);
        Task<UserDtoUpdateResult> Put(UserDtoUpdate user);
        Task<bool> Delete(Guid id);          
    }
}