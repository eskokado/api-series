using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class GenreEntity : BaseEntity
    {
        public string Name { get; set; }

        public IEnumerable<MovieEntity> Movies { get; set; }
    }
}
