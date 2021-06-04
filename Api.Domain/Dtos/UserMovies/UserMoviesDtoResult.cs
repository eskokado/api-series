using System;
using Api.Domain.Dtos.Movie;

namespace Api.Domain.Dtos.UserMovies
{
    public class UserMoviesDtoResult
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public UserDtoResult User { get; set; }

        public Guid MovieId { get; set; }
        public MovieDtoResult Movie { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
