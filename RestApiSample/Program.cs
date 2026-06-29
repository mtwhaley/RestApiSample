using Microsoft.EntityFrameworkCore;
using RestApiSample.Application;
using RestApiSample.Application.Abstractions;
using RestApiSample.Infrastructure;
using RestApiSample.Persistence;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// EF Core
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseSqlite("Data Source=movies.db"));

builder.Services.AddScoped<IMovieContext>(provider =>
    provider.GetRequiredService<MovieContext>());

// Add services to the container.
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddHttpClient<IMovieLookupService, MovieLookupService>((sp, client) =>
{
    var config = sp.GetRequiredService<IConfiguration>();

    client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            "Bearer",
            config["TmdbToken"] ?? throw new ArgumentNullException("TMDB token must be specified."));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seed test data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MovieContext>();

    context.Database.EnsureCreated();

    SeedData.Initialize(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
