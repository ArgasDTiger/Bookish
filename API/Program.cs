using API.Extensions;
using API.Helpers;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddControllers();

builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));

builder.Services.AddDbContext<BooksContext>(
    options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

    });

builder.Services.AddDbContext<AppIdentityDbContext>(
    options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("IdentityConnection"));
        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    });


builder.Services.AddApplicationServices();

builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
    });
});


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

app.UseCors("CorsPolicy");

app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<BooksContext>();
        await BookContextSeed.SeedData(context);
        await context.Database.MigrateAsync();
        
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "An error occured during migration");
    }
}
app.Run();