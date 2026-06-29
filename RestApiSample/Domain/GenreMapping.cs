using System.Text.Json.Serialization;

namespace RestApiSample.Domain
{
    public class GenreMapping
    {
        [JsonPropertyName("genres")]
        public List<Genre> Genres { get; set; } = [];
        public class Genre
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonPropertyName("name")]
            public string Name { get; set; } = string.Empty;
        }
    }
}
