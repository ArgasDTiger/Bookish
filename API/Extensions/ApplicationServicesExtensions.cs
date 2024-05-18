using Core.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Services;

namespace API.Extensions;

public static class ApplicationServicesExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<ITokenService, TokenService>();
    }
}