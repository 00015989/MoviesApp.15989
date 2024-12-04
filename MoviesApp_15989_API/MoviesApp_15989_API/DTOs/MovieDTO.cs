

// Student ID: 15989
namespace MoviesApp_15989_API.DTOs
{
    // Using these for GET responses
    public class MovieDTO
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public int GenreID { get; set; }
        public string GenreName { get; set; }  
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
    }

    // Using for POST/PUT requests only
    public class CreateMovieDTO
    {
        public string Title { get; set; }
        public int GenreID { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
    }
}
