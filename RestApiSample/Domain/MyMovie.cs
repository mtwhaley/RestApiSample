using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiSample.Domain
{
    public class MyMovie
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        [NotMapped]
        public Movie? Movie { get; set; } = null;
        public Movie.Status Status { get; set; }
        public int PersonalRating { get; set; }
    }
}
