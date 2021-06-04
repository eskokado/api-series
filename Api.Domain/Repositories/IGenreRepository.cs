using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Repositories
{
    public interface IGenreRepository : IRepository<GenreEntity>
    {
         Task<IEnumerable<GenreEntity>> FindByName(string name);
    }
}