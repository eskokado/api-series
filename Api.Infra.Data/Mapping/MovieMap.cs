using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Data.Mapping
{
    public class MovieMap : IEntityTypeConfiguration<MovieEntity>
    {
        public void Configure(EntityTypeBuilder<MovieEntity> builder)
        {
            builder.ToTable("Movies");

            builder.HasKey(m => m.Id);

            builder.HasIndex(g => g.Name)
                .IsUnique();

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(150);
                
            builder.HasOne(m => m.Genre)
                .WithMany(g => g.Movies);
        }
    }
}