using Microsoft.EntityFrameworkCore;
using RestApiSample.Domain;


namespace RestApiSample.Application.Abstractions
{
    public interface IMovieContext
    {
        DbSet<MyMovie> MyMovies { get; }
    }
}
