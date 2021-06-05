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
    public class MovieImplementation : BaseRepository<MovieEntity>, IMovieRepository
    {
        private DbSet<MovieEntity> _dataset;

        public MovieImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<MovieEntity> ();
        }
        public async Task<IEnumerable<MovieEntity>> FindCompleteByName(string name)
        {
            return await _dataset.Include(m => m.Genre).AsQueryable()
                                .Where(m => m.Name.Contains(name))
                                .ToListAsync<MovieEntity>();
        }
        public async Task<IEnumerable<MovieEntity>> FindCompleteByDescription(string description)
        {
            return await _dataset.Include(m => m.Genre).AsQueryable()
                                .Where(m => m.Description.Contains(description))
                                .ToListAsync<MovieEntity>();
        }

        public async Task<IEnumerable<MovieEntity>> FindCompleteByNameAndDescription(string text)
        {
            return await _dataset.Include(m => m.Genre).AsQueryable()
                                .Where(m => m.Description.Contains(text) || m.Name.Contains(text))
                                .ToListAsync<MovieEntity>();
        }
        public async Task<IEnumerable<MovieEntity>> FindCompleteByGenreName(string name)
        {
            return await _dataset.Include(m => m.Genre).AsQueryable()
                                .Where(m => m.Genre.Name.Contains(name))
                                .ToListAsync<MovieEntity>();
        }
    }
}