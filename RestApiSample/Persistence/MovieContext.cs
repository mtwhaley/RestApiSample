
using Microsoft.EntityFrameworkCore;
using RestApiSample.Application.Abstractions;
using RestApiSample.Domain;

namespace RestApiSample.Persistence
{
    public class MovieContext : DbContext, IMovieContext
    {

        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<MyMovie> MyMovies { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyMovie>(entity =>
            {
                entity.HasKey(m => m.Id);

                entity.Property(m => m.MovieId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(m => m.Status)
                    .HasConversion<string>()
                    .HasMaxLength(20);

                entity.Property(m => m.PersonalRating);

            });
        }
    }
}

