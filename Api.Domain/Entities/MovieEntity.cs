using System;
using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class MovieEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid GenreId { get; set; }

        public GenreEntity Genre { get; set; }

        public IEnumerable<UserMoviesEntity> UserMovies { get; set; }
    }
}
