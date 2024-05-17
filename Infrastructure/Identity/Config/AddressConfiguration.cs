using Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Identity.Config;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder
            .HasKey(a => a.Id);
        
        builder
            .Property(a => a.FirstName).IsRequired().HasMaxLength(50);
        
        builder
            .Property(a => a.LastName).HasMaxLength(50);
        
        builder
            .Property(a => a.Street).HasMaxLength(100);
        
        builder
            .Property(a => a.ZipCode).HasMaxLength(16);

        builder
            .HasOne(a => a.AppUser)
            .WithOne(a => a.Address)
            .HasForeignKey<Address>(a => a.AppUserId)
            .IsRequired();
    }
}