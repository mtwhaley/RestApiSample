namespace RestApiSample.Domain
{
    public class Movie
    {
        public enum Status
        {
            WantToWatch,
            Watching,
            Watched
        }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> Genres { get; set; } = [];

        public Movie() { }
        public Movie(TmdbDto tmdbDto)
        {
            Title = tmdbDto.Title;
            Description = tmdbDto.Overview;
            Genres = tmdbDto.Genres.Select(g => g.Name).ToList();
        }
    }
}
