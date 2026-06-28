using RestApiSample.Persistence;
using Microsoft.EntityFrameworkCore;
using RestApiSample.Application.Abstractions;
using RestApiSample.Application;

var builder = WebApplication.CreateBuilder(args);

// EF Core
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseSqlite("Data Source=movies.db"));

builder.Services.AddScoped<IMovieContext>(provider =>
    provider.GetRequiredService<MovieContext>());

// Add services to the container.
builder.Services.AddScoped<IMovieService, MovieService>();

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
