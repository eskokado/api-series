using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Repositories
{
    public interface IUserMoviesRepository : IRepository<UserMoviesEntity>
    {
         Task<IEnumerable<UserMoviesEntity>> FindCompleteByMovieName(string name);
         Task<IEnumerable<UserMoviesEntity>> FindCompleteByUserName(string name);
    }
}