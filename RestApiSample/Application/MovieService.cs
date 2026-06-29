using RestApiSample.Application.Abstractions;
using RestApiSample.Domain;
using System.Data.Entity;

namespace RestApiSample.Application
{
    public record MovieQuery(string? Title = null);
    public class MovieService : IMovieService
    {
        private readonly IMovieContext _context;
        private readonly IMovieLookupService _movieLookupService;

        public MovieService(IMovieContext context, IMovieLookupService movieLookupService   )
        {
            _context = context;
            _movieLookupService = movieLookupService;
        }

        public async Task<IEnumerable<MyMovie>> GetMyMovies()
        {
            List<MyMovie> myMovies = [.. _context.MyMovies];
            foreach (var movie in myMovies)
            {
                movie.Movie = await _movieLookupService.GetById(movie.MovieId);
            }
            return myMovies;
        }
        public async Task<IEnumerable<Movie>> GetRandomMovies()
        {
            return await Task.FromResult<IEnumerable<Movie>>([]);
        }
        public async Task<IEnumerable<Movie>> SearchMovies(MovieQuery movieQuery)
        {
            return movieQuery.Title == null ? [] : await _movieLookupService.QueryByTitle(movieQuery.Title);
        }
    }
}
