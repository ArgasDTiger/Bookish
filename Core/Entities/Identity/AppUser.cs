using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Identity;

public class AppUser : IdentityUser
{
    public Address Address { get; set; }
}