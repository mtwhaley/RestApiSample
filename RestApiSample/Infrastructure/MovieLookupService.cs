using RestApiSample.Application.Abstractions;
using RestApiSample.Domain;
using System.Text.Json;

namespace RestApiSample.Infrastructure
{
    public class MovieLookupService : IMovieLookupService
    {
        private readonly HttpClient _httpClient;
        
        public MovieLookupService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private async Task<string> Get(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<Movie?> GetById(int movieId)
        {
            string endpoint = $"movie/{movieId}";

            string json = await Get(endpoint);

            var result = JsonSerializer.Deserialize<TmdbDto>(json);

            return result == null ? null : new Movie(result);
        }
        public async Task<List<Movie>> QueryByTitle(string title)
        {
            string endpoint = $"search/movie?query={Uri.EscapeDataString(title)}";

            var json = await Get(endpoint);

            var result = JsonSerializer.Deserialize<Movie>(json);

            return result == null ? [result] : [];
        }
    }
}
