using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {

        builder
            .HasKey(b => b.Id);

        builder
            .Property(b => b.ISBN)
            .HasMaxLength(13);
            

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