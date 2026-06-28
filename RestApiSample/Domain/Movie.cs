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
        public string Genre { get; set; } = string.Empty;
    }
}
