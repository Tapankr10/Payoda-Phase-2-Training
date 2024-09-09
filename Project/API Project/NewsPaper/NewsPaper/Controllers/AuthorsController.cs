using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsPaper.Model;

namespace NewsPaper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorsController : ControllerBase
    {
        private readonly NewsDbContext _context;

        public AuthorsController(NewsDbContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return await _context.Authors.ToListAsync();
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PutAuthor(int id, Author author)
        {
            if (id != author.AuthorID)
            {
                return BadRequest();
            }

            _context.Entry(author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
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

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthor", new { id = author.AuthorID }, author);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpGet("filter-by-name")]
        public async Task<IActionResult> FilterByName(string name)
        {
            var authors = await _context.Authors
                                        .Where(a => a.Name.Contains(name))
                                        .ToListAsync();
            if (!authors.Any())
            {
                return NotFound($"No authors found with name containing '{name}'");
            }

            return Ok(authors);
        }

        // Filter authors by credibility score
        [HttpGet("filter-by-credibility")]
        public async Task<IActionResult> FilterByCredibilityScore(decimal minScore)
        {
            var authors = await _context.Authors
                                        .Where(a => a.CredibilityScore >= minScore)
                                        .ToListAsync();
            if (!authors.Any())
            {
                return NotFound($"No authors found with a credibility score above '{minScore}'");
            }

            return Ok(authors);
        }

        
        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.AuthorID == id);
        }
    }
}
