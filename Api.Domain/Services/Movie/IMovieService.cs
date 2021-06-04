using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Movie;

namespace Api.Domain.Services.Movie
{
    public interface IMovieService
    {
        Task<MovieDtoResult> Get (Guid id);
        Task<IEnumerable<MovieDtoResult>> GetAll();
        Task<MovieDtoCreateResult> Post(MovieDtoCreate user);
        Task<MovieDtoUpdateResult> Put(MovieDtoUpdate user);
        Task<bool> Delete(Guid id);          
    }
}