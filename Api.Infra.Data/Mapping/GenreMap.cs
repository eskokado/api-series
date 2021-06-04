using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Data.Mapping
{
    public class GenreMap : IEntityTypeConfiguration<GenreEntity>
    {
        public void Configure(EntityTypeBuilder<GenreEntity> builder)
        {
            builder.ToTable("Genres");

            builder.HasKey(g => g.Id);

            builder.HasIndex(g => g.Name)
                .IsUnique();
                
            builder.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}