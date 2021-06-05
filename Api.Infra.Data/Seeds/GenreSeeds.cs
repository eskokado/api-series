using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Data.Seeds
{
    public class GenreSeeds
    {
        public static void Genres(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenreEntity>().HasData(
                new GenreEntity()
                {
                    Id = new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"),
                    Name = "Romance",
                    CreateAt = DateTime.UtcNow
                },
                new GenreEntity()
                {
                    Id = new Guid("7cc33300-586e-4be8-9a4d-bd9f01ee9ad8"),
                    Name = "Drama",
                    CreateAt = DateTime.UtcNow
                },
                new GenreEntity()
                {
                    Id = new Guid("cb9e6888-2094-45ee-bc44-37ced33c693a"),
                    Name = "Ficção",
                    CreateAt = DateTime.UtcNow
                },
                 new GenreEntity()
                 {
                     Id = new Guid("409b9043-88a4-4e86-9cca-ca1fb0d0d35b"),
                     Name = "Aventura",
                     CreateAt = DateTime.UtcNow
                 },
                 new GenreEntity()
                 {
                     Id = new Guid("5abca453-d035-4766-a81b-9f73d683a54b"),
                     Name = "Terror",
                     CreateAt = DateTime.UtcNow
                 }
            );
        }

    }
}