using System;

namespace Api.Domain.Dtos.Genre
{
    public class GenreDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}