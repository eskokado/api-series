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
    public class GenreImplementation : BaseRepository<GenreEntity>, IGenreRepository
    {
        private DbSet<GenreEntity> _dataset;
        
        public GenreImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<GenreEntity> ();
        }

        public async Task<IEnumerable<GenreEntity>> FindByName(string name)
        {
            return await _dataset.AsQueryable().Where(u => u.Name.Contains(name)).ToListAsync<GenreEntity>();
        }
    }
}