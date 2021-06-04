using System;

namespace Api.Domain.Dtos.Genre
{
    public class GenreDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }
    }
}