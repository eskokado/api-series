using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Movie;
using Api.Domain.Entities;
using Api.Domain.Models;
using Api.Domain.Repositories;
using Api.Domain.Services.Movie;
using AutoMapper;

namespace Api.Service.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<MovieDtoResult>> FindCompleteByName(string name)
        {
            var entities = await _repository.FindCompleteByName(name);
            return _mapper.Map<IEnumerable<MovieDtoResult>> (entities);
        }

        public async Task<IEnumerable<MovieDtoResult>> FindCompleteByDescription(string description)
        {
            var entities = await _repository.FindCompleteByDescription(description);
            return _mapper.Map<IEnumerable<MovieDtoResult>> (entities);
        }

        public async Task<IEnumerable<MovieDtoResult>> FindCompleteByGenreName(string name)
        {
            var entities = await _repository.FindCompleteByGenreName(name);
            return _mapper.Map<IEnumerable<MovieDtoResult>> (entities);
        }

        public async Task<IEnumerable<MovieDtoResult>> FindCompleteByNameAndDescription(string text)
        {
            var entities = await _repository.FindCompleteByNameAndDescription(text);
            return _mapper.Map<IEnumerable<MovieDtoResult>> (entities);
        }

        public async Task<MovieDtoResult> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<MovieDtoResult> (entity);
        }

        public async Task<IEnumerable<MovieDtoResult>> GetAll()
        {
            var entities = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<MovieDtoResult>> (entities);
        }

        public async Task<MovieDtoCreateResult> Post(MovieDtoCreate dto)
        {
            var model = _mapper.Map<MovieModel> (dto);
            var entity = _mapper.Map<MovieEntity> (model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<MovieDtoCreateResult> (result);
        }

        public async Task<MovieDtoUpdateResult> Put(MovieDtoUpdate dto)
        {
            var model = _mapper.Map<MovieModel> (dto);
            var entity = _mapper.Map<MovieEntity> (model);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<MovieDtoUpdateResult> (result);
        }
    }
}