using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder
            .HasKey(g => g.Id);

        builder
            .Property(g => g.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .HasMany(g => g.Books)
            .WithMany(b => b.Genres)
            .UsingEntity("BookGenre");
    }
}