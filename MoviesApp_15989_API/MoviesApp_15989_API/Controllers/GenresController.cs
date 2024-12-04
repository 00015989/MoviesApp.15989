using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApp_15989_API.Data;
using MoviesApp_15989_API.Models;
using MoviesApp_15989_API.DTOs;

// Student ID: 15989

namespace MoviesApp_15989_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly MoviesDbContext _context;

        public GenresController(MoviesDbContext context)
        {
            _context = context;
        }

        // GET method
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDTO>>> GetGenres()
        {
            var genres = await _context.Genres
                .Select(g => new GenreDTO
                {
                    GenreID = g.GenreID,
                    Name = g.Name
                })
                .ToListAsync();

            return Ok(genres);
        }

        // GET by id Method
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDTO>> GetGenre(int id)
        {
            var genre = await _context.Genres
                .Where(g => g.GenreID == id)
                .Select(g => new GenreDTO
                {
                    GenreID = g.GenreID,
                    Name = g.Name
                })
                .FirstOrDefaultAsync();

            if (genre == null)
            {
                return NotFound();
            }

            return Ok(genre);
        }



        // POST Method
        [HttpPost]
        public async Task<ActionResult<GenreDTO>> PostGenre(CreateGenreDTO createGenreDTO)
        {
            var genre = new Genre
            {
                Name = createGenreDTO.Name
            };

            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();

            var genreDTO = new GenreDTO
            {
                GenreID = genre.GenreID,
                Name = genre.Name
            };

            return CreatedAtAction("GetGenre", new { id = genre.GenreID }, genreDTO);
        }


        // PUT Method
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre(int id, CreateGenreDTO createGenreDTO)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            genre.Name = createGenreDTO.Name;

            _context.Entry(genre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Genres.Any(e => e.GenreID == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // DELETE Method
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
