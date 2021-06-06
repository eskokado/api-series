using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.UserMovies;

namespace Api.Domain.Services
{
    public interface IUserMoviesService
    {
        Task<UserMoviesDtoResult> Get (Guid id);
        Task<IEnumerable<UserMoviesDtoResult>> GetAll();
        Task<UserMoviesDtoResult> Post(UserMoviesDtoCreate dto);
        Task<UserMoviesDtoResult> Put(UserMoviesDtoUpdate dto);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<UserMoviesDtoResult>> FindCompleteByMovieName(string name);
        Task<IEnumerable<UserMoviesDtoResult>> FindCompleteByUserName(string name);

    }
}