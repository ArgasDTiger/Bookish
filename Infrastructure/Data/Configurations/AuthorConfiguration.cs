using Core.Entities;
using CSharpVitamins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .Property(a => a.Id)
            .HasConversion(
                v => v.ToString(),
                v => new ShortGuid(v)
                );

        builder
            .Property(a => a.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(a => a.Surname)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(a => a.PenName)
            .HasMaxLength(50);
        
        builder
            .Property(a => a.Country)
            .HasMaxLength(90);
        
        builder
            .Property(a => a.City)
            .HasMaxLength(190);

        builder
            .HasMany(b => b.Books)
            .WithMany(b => b.Authors)
            .UsingEntity("AuthorBooks");

    }
}