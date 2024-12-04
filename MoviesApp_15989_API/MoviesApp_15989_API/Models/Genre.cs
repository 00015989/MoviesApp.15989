using System.Collections.Generic;

// Student ID: 15989
namespace MoviesApp_15989_API.Models
{
    public class Genre
    {
        public int GenreID { get; set; }  
        public string Name { get; set; }  
        public List<Movie> Movies { get; set; }
    }
}


