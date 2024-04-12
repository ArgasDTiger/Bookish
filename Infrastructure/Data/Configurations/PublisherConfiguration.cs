using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder
            .HasKey(p => p.Id);
        
        builder
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(p => p.PhoneNumber)
            .HasMaxLength(10);

        builder
            .HasMany(p => p.Books)
            .WithOne(p => p.Publisher)
            .HasForeignKey(p => p.PublisherId)
            .IsRequired();
        
    }
}