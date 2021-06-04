using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public IEnumerable<UserMoviesEntity> UserMovies { get; set; }
    }
}
