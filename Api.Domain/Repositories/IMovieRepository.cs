using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Repositories
{
    public interface IMovieRepository : IRepository<MovieEntity>
    {
         Task<IEnumerable<MovieEntity>> FindCompleteByName(string name);
         Task<IEnumerable<MovieEntity>> FindCompleteByDescription(string description);
         Task<IEnumerable<MovieEntity>> FindCompleteByNameAndDescription(string text);
         Task<IEnumerable<MovieEntity>> FindCompleteByGenreName(string name);
    }
}