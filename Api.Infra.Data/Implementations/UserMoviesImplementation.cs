using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Repositories;
using Api.Infra.Data.Context;
using Api.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Data.Implementations
{
    public class UserMoviesImplementation : BaseRepository<UserMoviesEntity>, IUserMoviesRepository
    {
        private DbSet<UserMoviesEntity> _dataset;
        
        public UserMoviesImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<UserMoviesEntity> ();
        }

        public async Task<IEnumerable<UserMoviesEntity>> FindCompleteByMovieName(string name)
        {
            return await _dataset.Include(um => um.Movie).ThenInclude(m => m.Genre)
                                .Include(um => um.User).AsQueryable()
                                .Where(um => um.Movie.Name.Contains(name)).ToListAsync<UserMoviesEntity>();
        }

        public async Task<IEnumerable<UserMoviesEntity>> FindCompleteByUserName(string name)
        {
            return await _dataset.Include(um => um.Movie).ThenInclude(m => m.Genre)
                                .Include(um => um.User).AsQueryable()
                                .Where(um => um.User.Name.Contains(name)).ToListAsync<UserMoviesEntity>();
        }
    }
}