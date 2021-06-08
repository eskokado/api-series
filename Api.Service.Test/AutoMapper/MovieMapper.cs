using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.Movie;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class MovieMapper : BaseTestService
    {
        [Fact(DisplayName = "É possível Mapear os Modelos (Movie)")]
        public void ItIsPossibleToMapTheModelsMovie()
        {
            var model = new MovieModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Description = Faker.Lorem.Sentence(25),
                GenreId = Guid.NewGuid(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var entity = new MovieEntity
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Description = Faker.Lorem.Sentence(25),
                GenreId = Guid.NewGuid(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
                Genre = new GenreEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                }
            };


            var listEntity = new List<MovieEntity>();
            for (int i = 0; i < 5; i++) {
                var item = new MovieEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Description = Faker.Lorem.Sentence(25),
                    GenreId = Guid.NewGuid(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    Genre = new GenreEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                    }
                };
                listEntity.Add(item);
            }

            var dtoCreate = new MovieDtoCreate
            {
                Name = Faker.Name.FullName(),
                Description = Faker.Lorem.Sentence(25),
                GenreId = Guid.NewGuid(),
            };

            var dtoUpdate = new MovieDtoUpdate
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Description = Faker.Lorem.Sentence(25),
                GenreId = Guid.NewGuid(),
            };

            var modelToEntity = Mapper.Map<MovieEntity>(model);
            Assert.Equal(modelToEntity.Id, model.Id);
            Assert.Equal(modelToEntity.Name, model.Name);
            Assert.Equal(modelToEntity.Description, model.Description);
            Assert.Equal(modelToEntity.GenreId, model.GenreId);
            Assert.Equal(modelToEntity.CreateAt, model.CreateAt);
            Assert.Equal(modelToEntity.UpdateAt, model.UpdateAt);

            var dto = Mapper.Map<MovieDtoResult>(entity);
            Assert.Equal(dto.Id, entity.Id);
            Assert.Equal(dto.Name, entity.Name);
            Assert.Equal(dto.Description, entity.Description);
            Assert.Equal(dto.GenreId, entity.GenreId);
            Assert.Equal(dto.CreateAt, entity.CreateAt);
            Assert.Equal(dto.UpdateAt, entity.UpdateAt);
            Assert.Equal(dto.Genre.Id, entity.Genre.Id);
            Assert.Equal(dto.Genre.Name, entity.Genre.Name);


            var listDto = Mapper.Map<List<MovieDtoResult>>(listEntity);
            Assert.NotNull(listDto);
            Assert.True(listDto.Count() == listEntity.Count());

            var dtoCreateResult = Mapper.Map<MovieDtoCreateResult>(entity);
            Assert.Equal(dtoCreateResult.Id, entity.Id);
            Assert.Equal(dtoCreateResult.Name, entity.Name);
            Assert.Equal(dtoCreateResult.Description, entity.Description);
            Assert.Equal(dtoCreateResult.GenreId, entity.GenreId);
            Assert.Equal(dtoCreateResult.CreateAt, entity.CreateAt);
            Assert.Equal(dtoCreateResult.Genre.Id, entity.Genre.Id);
            Assert.Equal(dtoCreateResult.Genre.Name, entity.Genre.Name);

            var dtoUpdateResult = Mapper.Map<MovieDtoUpdateResult>(entity);
            Assert.Equal(dtoUpdateResult.Id, entity.Id);
            Assert.Equal(dtoUpdateResult.Name, entity.Name);
            Assert.Equal(dtoUpdateResult.Description, entity.Description);
            Assert.Equal(dtoUpdateResult.GenreId, entity.GenreId);
            Assert.Equal(dtoUpdateResult.UpdateAt, entity.UpdateAt);
            Assert.Equal(dtoUpdateResult.Genre.Id, entity.Genre.Id);
            Assert.Equal(dtoUpdateResult.Genre.Name, entity.Genre.Name);
 
            var genModel = Mapper.Map<MovieModel>(dtoCreate);
            Assert.Equal(genModel.Name, dtoCreate.Name);
            Assert.Equal(genModel.Description, dtoCreate.Description);
            Assert.Equal(genModel.GenreId, dtoCreate.GenreId);

            genModel = Mapper.Map<MovieModel>(dtoUpdate);
            Assert.Equal(genModel.Id, dtoUpdate.Id);
            Assert.Equal(genModel.Name, dtoUpdate.Name);
            Assert.Equal(genModel.Description, dtoUpdate.Description);
            Assert.Equal(genModel.GenreId, dtoUpdate.GenreId);
        }
    }
}