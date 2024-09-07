using Apiproject.Model;
using Apiproject.Service;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Apiproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _authorService;

        public AuthorController(Service.AuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: api/<AuthorController>
        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _authorService.GetAllAuthorAsync();
            return Ok(authors);
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public async Task<Author> Get(int id)
        {
            return await _authorService.GetAuthor(id);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] Author  author)
        {
            if (author == null) return BadRequest("Course cannot be null");

            await _authorService.AddAuthorAsync(author);
            return CreatedAtAction(nameof(GetAllAuthors), new { id = author.AuthorId }, author);
        }


        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] Author author)
        {
            if (id != author.AuthorId) return BadRequest("Author ID mismatch");

            await _authorService.UpdateAuthorAsync(author);
            return NoContent();
        }
        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _authorService.DeleteAsync(id);
            return NoContent();
        }
    }
}
