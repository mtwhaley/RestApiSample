using RestApiSample.Domain;

namespace RestApiSample.Application.Abstractions
{
    public interface IMovieLookupService
    {
        Task<Movie?> GetById(int movieId);
        Task<List<Movie>> QueryByTitle(string title);
    }
}
