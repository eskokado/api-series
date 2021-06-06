using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.UserMovies;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class UserMoviesMapper : BaseTestService
    {
        [Fact(DisplayName = "É possível Mapear os Modelos (UserMovies)")]
        public void ItIsPossibleToMapTheModelsUserMovies()
        {
            var model = new UserMoviesModel
            {
                Id = Guid.NewGuid(),
                MovieId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var entity = new UserMoviesEntity
            {
                Id = Guid.NewGuid(),
                MovieId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
                Movie = new MovieEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Description = Faker.Lorem.Sentence(100),
                },
                User = new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                }
            };


            var listEntity = new List<UserMoviesEntity>();
            for (int i = 0; i < 5; i++) {
                var item = new UserMoviesEntity
                {
                    Id = Guid.NewGuid(),
                    MovieId = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    Movie = new MovieEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Description = Faker.Lorem.Sentence(100),
                    },
                    User = new UserEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                    }
                };
                listEntity.Add(item);
            }

            var dtoCreate = new UserMoviesDtoCreate
            {
                MovieId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
            };

            var dtoUpdate = new UserMoviesDtoUpdate
            {
                Id = Guid.NewGuid(),
                MovieId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
            };

            var modelToEntity = Mapper.Map<UserMoviesEntity>(model);
            Assert.Equal(modelToEntity.Id, model.Id);
            Assert.Equal(modelToEntity.MovieId, model.MovieId);
            Assert.Equal(modelToEntity.UserId, model.UserId);
            Assert.Equal(modelToEntity.CreateAt, model.CreateAt);
            Assert.Equal(modelToEntity.UpdateAt, model.UpdateAt);

            var dto = Mapper.Map<UserMoviesDtoResult>(entity);
            Assert.Equal(dto.Id, entity.Id);
            Assert.Equal(dto.MovieId, entity.MovieId);
            Assert.Equal(dto.UserId, entity.UserId);
            Assert.Equal(dto.CreateAt, entity.CreateAt);
            Assert.Equal(dto.UpdateAt, entity.UpdateAt);

            var listDto = Mapper.Map<List<UserMoviesDtoResult>>(listEntity);
            Assert.NotNull(listDto);
            Assert.True(listDto.Count() == listEntity.Count());
 
            var genModel = Mapper.Map<UserMoviesModel>(dtoCreate);
            Assert.Equal(genModel.MovieId, dtoCreate.MovieId);
            Assert.Equal(genModel.UserId, dtoCreate.UserId);

            genModel = Mapper.Map<UserMoviesModel>(dtoUpdate);
            Assert.Equal(genModel.Id, dtoUpdate.Id);
            Assert.Equal(genModel.MovieId, dtoUpdate.MovieId);
            Assert.Equal(genModel.UserId, dtoUpdate.UserId);
        }
    }
}