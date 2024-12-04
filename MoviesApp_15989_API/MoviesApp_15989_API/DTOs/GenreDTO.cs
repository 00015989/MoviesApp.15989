
// Student ID: 15989
namespace MoviesApp_15989_API.DTOs
{
    // Using these for GET responses
    public class GenreDTO
    {
        public int GenreID { get; set; }  
        public string Name { get; set; }  
    }

    // Using this only for POST/PUT requests
    public class CreateGenreDTO
    {
        public string Name { get; set; } 
    }
}

