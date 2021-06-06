using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Genre;
using Api.Domain.Entities;
using Api.Domain.Models;
using Api.Domain.Repositories;
using Api.Domain.Services.Genre;
using AutoMapper;

namespace Api.Service.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _repository;
        private readonly IMapper _mapper;
        public GenreService(IGenreRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<GenreDtoResult>> FindByName(string name)
        {
            var entities = await _repository.FindByName(name);
            return _mapper.Map<IEnumerable<GenreDtoResult>> (entities);
        }

        public async Task<GenreDtoResult> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<GenreDtoResult> (entity);
        }

        public async Task<IEnumerable<GenreDtoResult>> GetAll()
        {
            var entities = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<GenreDtoResult>> (entities);
        }

        public async Task<GenreDtoCreateResult> Post(GenreDtoCreate dto)
        {
            var model = _mapper.Map<GenreModel> (dto);
            var entity = _mapper.Map<GenreEntity> (model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<GenreDtoCreateResult> (result);
        }

        public async Task<GenreDtoUpdateResult> Put(GenreDtoUpdate dto)
        {
            var model = _mapper.Map<GenreModel> (dto);
            var entity = _mapper.Map<GenreEntity> (model);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<GenreDtoUpdateResult> (result);
        }
    }
}