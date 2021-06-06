using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Genre;

namespace Api.Domain.Services.Genre
{
    public interface IGenreService
    {
        Task<GenreDtoResult> Get (Guid id);
        Task<IEnumerable<GenreDtoResult>> GetAll();
        Task<GenreDtoCreateResult> Post(GenreDtoCreate dto);
        Task<GenreDtoUpdateResult> Put(GenreDtoUpdate dto);
        Task<bool> Delete(Guid id);          
        Task<IEnumerable<GenreDtoResult>> FindByName(string name);
    }
}