using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApp_15989_API.Data;
using MoviesApp_15989_API.DTOs;
using MoviesApp_15989_API.Models;

// Student ID: 00015989

namespace MoviesApp_15989_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesDbContext _context;

        public MoviesController(MoviesDbContext context)
        {
            _context = context;
        }

        // GET Method
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies()
        {
            var movies = await _context.Movies
                .Include(m => m.Genre)
                .Select(m => new MovieDTO
                {
                    MovieID = m.MovieID,
                    Title = m.Title,
                    GenreID = m.GenreID,
                    GenreName = m.Genre.Name,
                    ReleaseDate = m.ReleaseDate,
                    Director = m.Director,
                    Rating = m.Rating,
                    Description = m.Description
                })
                .ToListAsync();

            return Ok(movies);
        }

        // GET by id Method
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetMovie(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.Genre)
                .Where(m => m.MovieID == id)
                .Select(m => new MovieDTO
                {
                    MovieID = m.MovieID,
                    Title = m.Title,
                    GenreID = m.GenreID,
                    GenreName = m.Genre.Name,
                    ReleaseDate = m.ReleaseDate,
                    Director = m.Director,
                    Rating = m.Rating,
                    Description = m.Description
                })
                .FirstOrDefaultAsync();

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // POST Method 
        [HttpPost]
        public async Task<ActionResult<MovieDTO>> PostMovie(CreateMovieDTO createMovieDTO)
        {
            var movie = new Movie
            {
                Title = createMovieDTO.Title,
                GenreID = createMovieDTO.GenreID,
                ReleaseDate = createMovieDTO.ReleaseDate,
                Director = createMovieDTO.Director,
                Rating = createMovieDTO.Rating,
                Description = createMovieDTO.Description
            };

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            var movieDTO = new MovieDTO
            {
                MovieID = movie.MovieID,
                Title = movie.Title,
                GenreID = movie.GenreID,
                GenreName = (await _context.Genres.FindAsync(movie.GenreID))?.Name,
                ReleaseDate = movie.ReleaseDate,
                Director = movie.Director,
                Rating = movie.Rating,
                Description = movie.Description
            };

            return CreatedAtAction("GetMovie", new { id = movie.MovieID }, movieDTO);
        }

        // PUT Method
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, CreateMovieDTO createMovieDTO)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            movie.Title = createMovieDTO.Title;
            movie.GenreID = createMovieDTO.GenreID;
            movie.ReleaseDate = createMovieDTO.ReleaseDate;
            movie.Director = createMovieDTO.Director;
            movie.Rating = createMovieDTO.Rating;
            movie.Description = createMovieDTO.Description;

            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE Method
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
