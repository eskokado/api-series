using System;

namespace Api.Domain.Entities
{
    public class UserMoviesEntity
    {
        public Guid UserId { get; set; }

        public UserEntity User { get; set; }

        public Guid MovieId { get; set; }

        public MovieEntity Movie { get; set; }
    }
}
