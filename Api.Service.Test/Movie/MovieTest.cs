using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Movie;

namespace Api.Service.Test.Movie
{
    public class MovieTest
    {
        public static string MovieName { get; set; }
        public static string MovieDescription { get; set; }
        public static Guid MovieGenreId { get; set; }
        public static string MovieNameUpdate { get; set; }
        public static string MovieDescriptionUpdate { get; set; }
        public static Guid MovieGenreIdUpdate { get; set; }
        public Guid MovieId { get; set; }

        public List<MovieDtoResult> listMovieDto = new List<MovieDtoResult>();

        public MovieDtoResult movieDtoResult = new MovieDtoResult();
        public MovieDtoCreate movieDtoCreate;
        public MovieDtoCreateResult movieDtoCreateResult;
        public MovieDtoUpdate movieDtoUpdate;
        public MovieDtoUpdateResult movieDtoUpdateResult;

        public MovieTest()
        {
            MovieId = Guid.NewGuid();
            MovieName = Faker.Name.FullName();
            MovieDescription = Faker.Lorem.Sentence(100);
            MovieGenreId = Guid.NewGuid();
            MovieNameUpdate = Faker.Name.FullName();
            MovieDescriptionUpdate = Faker.Lorem.Sentence(100);
            MovieGenreIdUpdate = Guid.NewGuid();

            for (int i = 0; i < 10; i++)
            {
                var result = new MovieDtoResult()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Description = Faker.Lorem.Sentence(100),
                    GenreId = Guid.NewGuid(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listMovieDto.Add(result);
            }

            movieDtoResult = new MovieDtoResult() 
            {
                Id = MovieId,
                Name = MovieName,
                Description = MovieDescription,
                GenreId = MovieGenreId,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            movieDtoCreate = new MovieDtoCreate()
            {
                Name = MovieName,
                Description = MovieDescription,
                GenreId = MovieGenreId,
            };

            movieDtoCreateResult = new MovieDtoCreateResult()
            {
                Id = MovieId,
                Name = MovieName,
                Description = MovieDescription,
                GenreId = MovieGenreId,
                CreateAt = DateTime.UtcNow
            };

            movieDtoUpdate = new MovieDtoUpdate()
            {
                Id = MovieId,
                Name = MovieNameUpdate,
                Description = MovieDescriptionUpdate,
                GenreId = MovieGenreIdUpdate,
            };

            movieDtoUpdateResult = new MovieDtoUpdateResult()
            {
                Id = MovieId,
                Name = MovieNameUpdate,
                Description = MovieDescriptionUpdate,
                GenreId = MovieGenreIdUpdate,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}