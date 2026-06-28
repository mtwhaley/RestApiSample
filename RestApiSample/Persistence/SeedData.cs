using RestApiSample.Domain;

namespace RestApiSample.Persistence
{
    /*
     *  This class is for the sole purpose of simulating persisted database data.
     */
    public static class SeedData
    {

        public static void Initialize(MovieContext context)
        {
            if (context.MyMovies.Any())
                return;
            context.MyMovies.AddRange(
            new MyMovie
            {
                MovieId = 1,
                Status = Movie.Status.Watched,
                PersonalRating = 10
            },
            new MyMovie
            {
                MovieId = 2,
                Status = Movie.Status.Watched,
                PersonalRating = 9
            },
            new MyMovie
            {
                MovieId = 3,
                Status = Movie.Status.WantToWatch,
                PersonalRating = 0
            });

            context.SaveChanges();
        }
    }
}
