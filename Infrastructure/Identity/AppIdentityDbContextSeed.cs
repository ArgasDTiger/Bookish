using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class AppIdentityDbContextSeed
{
    public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
    {
        if (!userManager.Users.Any())
        {
            var users = new List<AppUser>
            {
                new()
                {
                    UserName = "DDDDysik",
                    Email = "vlad@gmail.com",
                    Address = new Address
                    {
                        FirstName = "Vladyslav",
                        LastName = "Marchuk",
                        Street = "shouldn't concern you",
                        City = "Kyiv",
                        ZipCode = "01042"
                    }
                },
                new()
                {
                    UserName = "Loopa",
                    Email = "stas@gmail.com",
                    Address = new Address
                    {
                        FirstName = "Stanyslav",
                        LastName = "Johnson",
                        Street = "homeless",
                        City = "Texas",
                        ZipCode = "02043"
                    }
                },
            };

            foreach (var user in users)
            {
                await userManager.CreateAsync(user, "Bloxa_123");
            }
        }
    }
}