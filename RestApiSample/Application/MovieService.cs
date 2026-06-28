using RestApiSample.Application.Abstractions;
using RestApiSample.Domain;
using System.Data.Entity;

namespace RestApiSample.Application
{
    public class MovieService : IMovieService
    {
        private readonly IMovieContext _context;

        public MovieService(IMovieContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MyMovie>> GetMyMovies()
        {
            return _context.MyMovies.ToList();
        }
        public async Task<IEnumerable<Movie>> GetRandomMovies()
        {
            return await Task.FromResult<IEnumerable<Movie>>([]);
        }
    }
}
