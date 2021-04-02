using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieLibraryAPI.Data;
using MovieLibraryAPI.Models;

namespace MovieLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/Movies/AllMovies
        [HttpGet("AllMovies")]
        public async Task<ActionResult<IEnumerable<Movie>>> Getmoviess()
        {
            return await _context.Movies.ToListAsync();
        }
        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovies(int id)
        {
            var movies = await _context.Movies.FindAsync(id);
            if (movies == null)
            {
                return NotFound();
            }
            return movies;
        }
        // GET: api/Movies/Genre
        //[HttpGet("Genre")]
        //public async Task<ActionResult<Movie>> GetMoviesByGenre(string genre)
        //{
        //    var movies = await _context.Movies.FindAsync(genre);
        //    if (movies == null)
        //    {
        //        return NotFound();
        //    }
        //    return movies;
        //}
        // GET: api/Movies/Title
        //[HttpGet("{Title}")]
        //public IActionResult GetMoviesByTitle(string title)
        //{
        //    var movies = _context.Movies.Where(m => m.Title == title).ToArray();
        //    if (movies == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(movies);
        //}

        // GET: api/Movies/Director
        //[HttpGet("{Director}")]
        //public IActionResult GetMoviesByDirector(string Director)
        //{
        //    var movies = _context.Movies.Where(m => m.DirectorName == Director).ToArray();
        //    if (movies == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(movies);
        //}
        // GET: api/Movies/Genre
        //[HttpGet("Genre")]
        //public Task<IActionResult> GetByAnyOrAll([FromBody] Movie movies)
        //{
        //    var movies1 = _context.Movies.Where(m => m.Genre == movies.Genre).ToList();
        //    var movies2 = _context.Movies.Where(m => m.DirectorName == movies.DirectorName).ToList();
        //    var movies3 = _context.Movies.Where(m => m.Title == movies.Title).ToList();
        //    var movies4 = movies1.Where(m => m.DirectorName == m)
        //    var movie = _context.Movies.Where(m => m.Genre == moviesgenre).ToArray();
        //    if (movies == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(movies);
        //}
        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Movie movie)
        {

            _context.Entry(movie).State = EntityState.Modified;
            _context.SaveChangesAsync();
            return Ok(movie);
        }
        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovies(Movie movies)
        {
            _context.Movies.Add(movies);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMovies", new { id = movies.Id }, movies);
        }
        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovies(int id)
        {
            var mov = _context.Movies.Where(s => s.Id == id).FirstOrDefault();
            var movies = await _context.Movies.FindAsync(id);
            if (movies == null)
            {
                return NotFound();
            }
            _context.Movies.Remove(movies);
            await _context.SaveChangesAsync();
            return Ok(mov);
        }
        private bool MoviesExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}