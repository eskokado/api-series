using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Repositories;
using Api.Infra.Data.Context;
using Api.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Data.Implementations
{
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dataset;
        
        public UserImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<UserEntity> ();
        }

        public async Task<UserEntity> FindByLogin(string email)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}