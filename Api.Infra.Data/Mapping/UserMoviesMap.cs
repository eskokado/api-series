using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Data.Mapping
{
    public class UserMoviesMap : IEntityTypeConfiguration<UserMoviesEntity>
    {
        public void Configure(EntityTypeBuilder<UserMoviesEntity> builder)
        {
            builder.ToTable("UserMovies");

            builder.HasKey(um => new { um.UserId, um.MovieId });

            builder.HasOne<UserEntity>(um => um.User)
                .WithMany(u => u.UserMovies)
                .HasForeignKey(um => um.UserId);


            builder.HasOne<MovieEntity>(um => um.Movie)
                .WithMany(m => m.UserMovies)
                .HasForeignKey(um => um.MovieId);
        }
    }
}