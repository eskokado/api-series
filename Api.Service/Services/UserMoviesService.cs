using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Genre;
using Api.Domain.Dtos.UserMovies;
using Api.Domain.Entities;
using Api.Domain.Models;
using Api.Domain.Repositories;
using Api.Domain.Services;
using Api.Domain.Services.Genre;
using AutoMapper;

namespace Api.Service.Services
{
    public class UserMoviesService : IUserMoviesService
    {
        private readonly IUserMoviesRepository _repository;
        private readonly IMapper _mapper;
        public UserMoviesService(IUserMoviesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserMoviesDtoResult>> FindCompleteByMovieName(string name)
        {
            var entities = await _repository.FindCompleteByMovieName(name);
            return _mapper.Map<IEnumerable<UserMoviesDtoResult>> (entities);
        }

        public async Task<IEnumerable<UserMoviesDtoResult>> FindCompleteByUserName(string name)
        {
            var entities = await _repository.FindCompleteByUserName(name);
            return _mapper.Map<IEnumerable<UserMoviesDtoResult>> (entities);
        }

        public async Task<UserMoviesDtoResult> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<UserMoviesDtoResult> (entity);
        }

        public async Task<IEnumerable<UserMoviesDtoResult>> GetAll()
        {
            var entities = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<UserMoviesDtoResult>> (entities);
        }

        public async Task<UserMoviesDtoResult> Post(UserMoviesDtoCreate dto)
        {
            var model = _mapper.Map<UserMoviesModel> (dto);
            var entity = _mapper.Map<UserMoviesEntity> (model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<UserMoviesDtoResult> (result);
        }

        public async Task<UserMoviesDtoResult> Put(UserMoviesDtoUpdate dto)
        {
            var model = _mapper.Map<UserMoviesModel> (dto);
            var entity = _mapper.Map<UserMoviesEntity> (model);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<UserMoviesDtoResult> (result);
        }
    }
}