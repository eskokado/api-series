using System;
using System.Collections.Generic;
using Api.Domain.Dtos.UserMovies;

namespace Api.Service.Test.UserMovies
{
    public class UserMoviesTest
    {
        public Guid UserMoviesUserId { get; set; }
        public Guid UserMoviesMovieId { get; set; }
        public Guid UserMoviesId { get; set; }

        public List<UserMoviesDtoResult> listUserMoviesDto = new List<UserMoviesDtoResult>();

        public UserMoviesDtoResult userMoviesDtoResult = new UserMoviesDtoResult();
        public UserMoviesDtoCreate userMoviesDtoCreate;
        public UserMoviesDtoUpdate userMoviesDtoUpdate;

        public UserMoviesTest()
        {
            UserMoviesId = Guid.NewGuid();
            UserMoviesUserId = Guid.NewGuid();
            UserMoviesMovieId = Guid.NewGuid();

            for (int i = 0; i < 10; i++)
            {
                var result = new UserMoviesDtoResult()
                {
                    Id = Guid.NewGuid(),
                    MovieId = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listUserMoviesDto.Add(result);
            }

            userMoviesDtoResult = new UserMoviesDtoResult() 
            {
                Id = UserMoviesId,
                UserId = UserMoviesUserId,
                MovieId = UserMoviesMovieId,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            userMoviesDtoCreate = new UserMoviesDtoCreate()
            {
                UserId = UserMoviesUserId,
                MovieId = UserMoviesMovieId,
            };


            userMoviesDtoUpdate = new UserMoviesDtoUpdate()
            {
                Id = UserMoviesId,
                UserId = UserMoviesUserId,
                MovieId = UserMoviesMovieId,
            };
        }
    }
}