using RestApiSample.Domain;

namespace RestApiSample.Application.Abstractions
{
    public interface IMovieService
    {
        Task<IEnumerable<MyMovie>> GetMyMovies();
        Task<IEnumerable<Movie>> GetRandomMovies();
    }
}
