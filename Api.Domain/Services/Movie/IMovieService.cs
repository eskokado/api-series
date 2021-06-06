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
        Task<MovieDtoCreateResult> Post(MovieDtoCreate dto);
        Task<MovieDtoUpdateResult> Put(MovieDtoUpdate dto);
        Task<bool> Delete(Guid id);          
        Task<IEnumerable<MovieDtoResult>> FindCompleteByName(string name);
        Task<IEnumerable<MovieDtoResult>> FindCompleteByDescription(string description);
        Task<IEnumerable<MovieDtoResult>> FindCompleteByNameAndDescription(string text);
        Task<IEnumerable<MovieDtoResult>> FindCompleteByGenreName(string name);

    }
}