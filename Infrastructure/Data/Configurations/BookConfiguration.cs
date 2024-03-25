using Core.Entities;
using CSharpVitamins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {

        builder
            .HasKey(b => b.ISBN);

        builder
            .Property(b => b.ISBN)
            .IsRequired()
            .HasMaxLength(13)
            .HasConversion(
                v => v.ToString(),
                v => new ShortGuid(v)
            );
            

        builder
            .Property(b => b.Title)
            .IsRequired();

        builder
            .Property(b => b.ImageUrl)
            .IsRequired();

        builder
            .HasOne(b => b.Publisher)
            .WithMany(b => b.Books)
            .HasForeignKey(b => b.PublisherId)
            .IsRequired();
        
        builder
            .HasMany(b => b.Authors)
            .WithMany(b => b.Books)
            .UsingEntity("AuthorBooks");
        
        builder
            .HasMany(b => b.Genres)
            .WithMany(g => g.Books)
            .UsingEntity("BookGenre");
    }
}