using System.Text.Json.Serialization;

namespace RestApiSample.Domain
{
    public class TmdbSearchDto
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }
        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }
        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
        [JsonPropertyName("results")]
        public List<TmdbSearchResult> Results { get; set; } = [];
        public class TmdbSearchResult
        {

            [JsonPropertyName("title")]
            public string Title { get; set; } = string.Empty;
            [JsonPropertyName("overview")]
            public string Overview { get; set; } = string.Empty;
            [JsonPropertyName("genre_ids")]
            public List<int> GenreIds { get; set; } = [];
            public List<string> Genres { get; set; } = [];
        }
    }
}
