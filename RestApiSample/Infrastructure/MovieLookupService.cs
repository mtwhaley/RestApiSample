using RestApiSample.Application.Abstractions;
using RestApiSample.Domain;
using System.Text.Json;

namespace RestApiSample.Infrastructure
{
    public class MovieLookupService : IMovieLookupService
    {
        private readonly HttpClient _httpClient;
        private Dictionary<int, string>? GenreMap { get; set; } = null;
        
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

            var result = JsonSerializer.Deserialize<TmdbSearchDto>(json);

            if (result == null) return [];

            if (GenreMap == null) await GetGenreMap();

            foreach (TmdbSearchDto.TmdbSearchResult searchResult in result.Results)
            {
                searchResult.Genres = searchResult.GenreIds.Select(gi => GenreMap![gi]).ToList();
            }
            
            List<Movie> movies = result.Results.Select(r => new Movie(r)).ToList();



            return movies;
        }

        public async Task GetGenreMap()
        {
            string endpoint = "genre/movie/list";
            string json = await Get(endpoint);
            var result = JsonSerializer.Deserialize<GenreMapping>(json);

            if (result == null) throw new InvalidOperationException("Unable to parse genre response");

            GenreMap = result.Genres.Select(g => new KeyValuePair<int, string>(g.Id, g.Name)).ToDictionary();

        }
    }
}
