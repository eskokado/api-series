using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Genre;

namespace Api.Service.Test.Genre
{
    public class GenreTest
    {
        public string GenreName { get; set; }
        public string GenreNameUpdate { get; set; }
        public Guid GenreId { get; set; }

        public List<GenreDtoResult> listGenreDto = new List<GenreDtoResult>();

        public GenreDtoResult genreDtoResult = new GenreDtoResult();
        public GenreDtoCreate genreDtoCreate;
        public GenreDtoCreateResult genreDtoCreateResult;
        public GenreDtoUpdate genreDtoUpdate;
        public GenreDtoUpdateResult genreDtoUpdateResult;

        public GenreTest()
        {
            GenreId = Guid.NewGuid();
            GenreName = Faker.Name.FullName();
            GenreNameUpdate = Faker.Name.FullName();

            for (int i = 0; i < 10; i++)
            {
                var result = new GenreDtoResult()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listGenreDto.Add(result);
            }

            genreDtoResult = new GenreDtoResult() 
            {
                Id = GenreId,
                Name = GenreName,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            genreDtoCreate = new GenreDtoCreate()
            {
                Name = GenreName,
            };

            genreDtoCreateResult = new GenreDtoCreateResult()
            {
                Id = GenreId,
                Name = GenreName,
                CreateAt = DateTime.UtcNow
            };

            genreDtoUpdate = new GenreDtoUpdate()
            {
                Id = GenreId,
                Name = GenreNameUpdate,
            };

            genreDtoUpdateResult = new GenreDtoUpdateResult()
            {
                Id = GenreId,
                Name = GenreNameUpdate,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}