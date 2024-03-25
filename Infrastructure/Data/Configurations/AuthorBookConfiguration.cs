using Core.Entities;
using CSharpVitamins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class AuthorBookConfiguration : IEntityTypeConfiguration<AuthorBook>
{
    public void Configure(EntityTypeBuilder<AuthorBook> builder)
    {
        builder
            .HasKey(ab => new { ab.AuthorId, ab.BookId });
        
        builder
            .Property(ab => ab.AuthorId)
            .HasConversion(
                v => v.ToString(),
                v => new ShortGuid(v)
            );
        
        builder
            .Property(ab => ab.BookId)
            .HasConversion(
                v => v.ToString(),
                v => new ShortGuid(v)
            );
    }
}