using API.Controllers;
using API.Dtos;
using API.Errors;
using API.UnitTests.Helpers;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace API.UnitTests.Controllers;

[TestFixture]
public class AccountControllerTest
{
    private AccountController _controller;
    private Mock<UserManager<AppUser>> _userManager;
    private Mock<SignInManager<AppUser>> _signInManager;
    private Mock<ITokenService> _tokenService;
    private LoginDto _loginDto;
    private RegisterDto _registerDto;
    private AppUser _appUser;

    [SetUp]
    public void SetUp()
    {
        _userManager = MockHelpers.MockUserManager();
        _signInManager = MockHelpers.MockSignInManager(_userManager);
        _tokenService = new Mock<ITokenService>();

        _controller = new AccountController(_userManager.Object, _tokenService.Object, _signInManager.Object);

        _loginDto = new LoginDto
        {
            Email = "test@gmail.com",
            Password = "ExamplePassword_123"
        };
        _registerDto = new RegisterDto()
        {
            Username = "AppUser",
            Email = _loginDto.Email,
            Password = _loginDto.Password
        };
        _appUser = new AppUser
        {
            Email = _loginDto.Email,
            UserName = "user123"
        };
    }

    [Test]
    public async Task CheckEmailExistsAsync_EmailDoesNotExist_ReturnFalse()
    {
        MockEmailDoesNotExist();

        var result = await _controller.CheckEmailExistsAsync(_loginDto.Email);

        Assert.That(result.Value, Is.False);
    }

    [Test]
    public async Task CheckEmailExistsAsync_EmailExists_ReturnTrue()
    {
        MockEmailExists();

        var result = await _controller.CheckEmailExistsAsync(_loginDto.Email);

        Assert.That(result.Value, Is.True);
    }

    [Test]
    public async Task Login_UserDoesNotExist_ReturnUnauthorized()
    {
       MockEmailDoesNotExist();

        var result = await _controller.Login(_loginDto);
        
        var actionResult = result.Result as UnauthorizedObjectResult;
        Assert.IsNotNull(actionResult);
        var apiResponse = actionResult.Value as ApiResponse;
        Assert.That(apiResponse.StatusCode, Is.EqualTo(401));
        Assert.That(apiResponse.Message, Is.EqualTo("User doesn't exist"));
    }

    [Test]
    public async Task Login_InvalidPassword_ReturnUnauthorized()
    {
       MockEmailExists();

        _signInManager.Setup(sm =>
            sm.CheckPasswordSignInAsync(_appUser, _loginDto.Password, false))
            .ReturnsAsync(SignInResult.Failed);

        var result = await _controller.Login(_loginDto);

        var actionResult = result.Result as UnauthorizedObjectResult;
        Assert.That(actionResult, Is.Not.Null);

        var apiResponse = actionResult.Value as ApiResponse;
        
        Assert.That(apiResponse.StatusCode, Is.EqualTo(401));
        Assert.That(apiResponse.Message, Is.EqualTo("Invalid email and/or password"));

    }

    [Test]
    public async Task Login_UserExists_ReturnUserDto()
    {
        MockEmailExists();

        _signInManager.Setup(sm =>
                sm.CheckPasswordSignInAsync(_appUser, _loginDto.Password, false))
                .ReturnsAsync(SignInResult.Success);

        var result = await _controller.Login(_loginDto);

        var userDto = result.Value;
        Assert.That(userDto, Is.TypeOf<UserDto>());
        Assert.That(userDto.Email, Is.EqualTo(_loginDto.Email));
        Assert.That(userDto.Username, Is.EqualTo(_appUser.UserName));
    }

    [Test]
    public async Task Register_EmailIsUsed_ReturnBadRequest()
    {
        MockEmailExists();

        var result = await _controller.Register(_registerDto);

        var actionResult = result.Result as BadRequestObjectResult;
        Assert.That(actionResult, Is.Not.Null);
        var apiValidationErrorResponse = actionResult.Value as ApiValidationErrorResponse;
        
        Assert.That(apiValidationErrorResponse!.Errors, Does.Contain("Email address is already in use"));
    }

    [Test]
    public async Task Register_InvalidCredentials_ReturnBadRequest()
    {
        MockEmailDoesNotExist();

        _userManager.Setup(um =>
            um.CreateAsync(It.IsAny<AppUser>(), It.IsAny<string>()))
            .ReturnsAsync(IdentityResult.Failed(new IdentityError
            {
                Description = "Invalid credentials"
            }));

        var result = await _controller.Register(_registerDto);

        var actionResult = result.Result as BadRequestObjectResult;
        Assert.That(actionResult, Is.Not.Null);

        var apiValidationErrorResponse = actionResult.Value as ApiValidationErrorResponse;
        Assert.That(apiValidationErrorResponse!.Errors.Single(), Is.EqualTo("Invalid credentials"));

    }
    
    private void MockEmailExists()
    {
        _userManager.Setup(um =>
                um.FindByEmailAsync(_registerDto.Email))
            .ReturnsAsync(_appUser);
    }
    
    private void MockEmailDoesNotExist()
    {
        _userManager.Setup(um =>
                um.FindByEmailAsync(_registerDto.Email))
            .ReturnsAsync((AppUser?)null);
        
    }
}
