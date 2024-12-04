
// Student ID: 15989
namespace MoviesApp_15989_API.Models
{
    public class Movie
    {
        public int MovieID { get; set; } 
        public string Title { get; set; } 
        public int GenreID { get; set; }  
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
        // Only used for navigation
        public Genre Genre { get; set; } 
    }
}
