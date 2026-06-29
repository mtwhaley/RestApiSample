using System.Text.Json.Serialization;

namespace RestApiSample.Domain
{
    public class TmdbDto
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;
        [JsonPropertyName("overview")]
        public string Overview { get; set; } = string.Empty;
        [JsonPropertyName("genres")]
        public List<Genre> Genres { get; set; } = [];
        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }

        public class Genre
        {
            [JsonPropertyName("name")]
            public string Name { get; set; } = string.Empty;
        } 
    }
}
