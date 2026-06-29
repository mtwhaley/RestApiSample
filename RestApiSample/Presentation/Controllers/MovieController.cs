using Microsoft.AspNetCore.Mvc;
using RestApiSample.Application.Abstractions;
using RestApiSample.Domain;

namespace RestApiSample.Presentation.Controllers
{
    [ApiController]
    [Route("")]
    public class MovieController : ControllerBase
    {

        private readonly ILogger<MovieController> _logger;
        private readonly IMovieService _movieService;

        public MovieController(ILogger<MovieController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        [HttpGet, Route("mymovies")]
        public async Task<IEnumerable<MyMovie>> Get()
        {
            return await _movieService.GetMyMovies();
        }
        [HttpGet, Route("search")]
        public async Task<IEnumerable<Movie>> Search([FromQuery]string? title = null)
        {

            return await _movieService.SearchMovies(new Application.MovieQuery(title));
        }
    }
}
