using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.Genre;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class GenreMapper : BaseTestService
    {
        [Fact(DisplayName = "É possível Mapear os Modelos (Genre)")]
        public void ItIsPossibleToMapTheModelsGenre()
        {
            var model = new GenreModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var listEntity = new List<GenreEntity>();
            for (int i = 0; i < 5; i++) {
                var item = new GenreEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listEntity.Add(item);
            }

            var dtoCreate = new GenreDtoCreate
            {
                Name = Faker.Name.FullName(),
            };

            var dtoUpdate = new GenreDtoUpdate
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
            };

            var modelToEntity = Mapper.Map<GenreEntity>(model);
            Assert.Equal(modelToEntity.Id, model.Id);
            Assert.Equal(modelToEntity.Name, model.Name);
            Assert.Equal(modelToEntity.CreateAt, model.CreateAt);
            Assert.Equal(modelToEntity.UpdateAt, model.UpdateAt);

            var dto = Mapper.Map<GenreDtoResult>(modelToEntity);
            Assert.Equal(dto.Id, modelToEntity.Id);
            Assert.Equal(dto.Name, modelToEntity.Name);
            Assert.Equal(dto.CreateAt, modelToEntity.CreateAt);
            Assert.Equal(dto.UpdateAt, modelToEntity.UpdateAt);

            var listDto = Mapper.Map<List<GenreDtoResult>>(listEntity);
            Assert.NotNull(listDto);
            Assert.True(listDto.Count() == listEntity.Count());

            var dtoCreateResult = Mapper.Map<GenreDtoCreateResult>(modelToEntity);
            Assert.Equal(dtoCreateResult.Id, modelToEntity.Id);
            Assert.Equal(dtoCreateResult.Name, modelToEntity.Name);
            Assert.Equal(dtoCreateResult.CreateAt, modelToEntity.CreateAt);

            var dtoUpdateResult = Mapper.Map<GenreDtoUpdateResult>(modelToEntity);
            Assert.Equal(dtoUpdateResult.Id, modelToEntity.Id);
            Assert.Equal(dtoUpdateResult.Name, modelToEntity.Name);
            Assert.Equal(dtoUpdateResult.UpdateAt, modelToEntity.UpdateAt);
 
            var genModel = Mapper.Map<GenreModel>(dtoCreate);
            Assert.Equal(genModel.Name, dtoCreate.Name);

            genModel = Mapper.Map<GenreModel>(dtoUpdate);
            Assert.Equal(genModel.Id, dtoUpdate.Id);
            Assert.Equal(genModel.Name, dtoUpdate.Name);



        }
    }
}