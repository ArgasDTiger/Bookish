using Core.Entities;
using CSharpVitamins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class BookGenreConfiguration : IEntityTypeConfiguration<BookGenre>
{
    public void Configure(EntityTypeBuilder<BookGenre> builder)
    {
        builder
            .HasKey(bg => new { bg.BookId, bg.GenreId });
        
        builder
            .Property(bg => bg.GenreId)
            .HasConversion(
                v => v.ToString(),
                v => new ShortGuid(v)
            );
        
        builder
            .Property(bg => bg.BookId)
            .HasConversion(
                v => v.ToString(),
                v => new ShortGuid(v)
            );
    }
}