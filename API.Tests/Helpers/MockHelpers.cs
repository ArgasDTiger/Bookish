using Core.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace API.UnitTests.Helpers;

public static class MockHelpers
{
    public static Mock<UserManager<AppUser>> MockUserManager()
    {
        var store = new Mock<IUserStore<AppUser>>();
        var mockUserManager = new Mock<UserManager<AppUser>>(store.Object,
            null, null, null, null, null, null, null, null);
        return mockUserManager;
    }

    public static Mock<SignInManager<AppUser>> MockSignInManager(Mock<UserManager<AppUser>> userManager)
    {
        var contextAccessor = new Mock<IHttpContextAccessor>();
        var claimsFactory = new Mock<IUserClaimsPrincipalFactory<AppUser>>();
        var mockSignInManager = new Mock<SignInManager<AppUser>>(
            userManager.Object,
            contextAccessor.Object,
            claimsFactory.Object,
            null, null, null, null);
        return mockSignInManager;
    }
}