using System;
using Api.Domain.Dtos.Genre;

namespace Api.Domain.Dtos.Movie
{
    public class MovieDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid GenreId { get; set; }

        public GenreDtoResult Genre { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
