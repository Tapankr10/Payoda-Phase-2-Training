using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Apiproject.Model;
using Apiproject.Service;

namespace Apiproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAuthorsController : ControllerBase
    {
       private readonly BookDbConnext _context;
        private readonly AuthorService _author;
        private readonly BookService _book;
        public BookAuthorsController(AuthorService author, BookService book)
        {
            _author = author;
            _book = book;
        }

      

        // GET: api/BookAuthors
        [HttpGet]
        public async Task<IActionResult> GetBookAuthorByAuthorId(int authorId)
        {
            var author = await _author.GetAuthor(authorId);

            if (author == null) return NotFound();

            var books = author.BookAuthors;
            return Ok(books);
        }

        // GET: api/BookAuthors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookAuthorByBookId(int bookId)
        {
            var book = await _book.Getbkbyid(bookId);

            if (book == null) return NotFound();

            var authors = book.BookAuthors;
            return Ok(authors);
        }


        // PUT: api/BookAuthors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookAuthor(int id, BookAuthor bookAuthor)
        {
            if (id != bookAuthor.AuthorId)
            {
                return BadRequest();
            }

            _context.Entry(bookAuthor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookAuthorExists(id))
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

        // POST: api/BookAuthors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookAuthor>> PostBookAuthor(BookAuthor bookAuthor)
        {
            _context.BookAuthor.Add(bookAuthor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookAuthorExists(bookAuthor.AuthorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookAuthor", new { id = bookAuthor.AuthorId }, bookAuthor);
        }

        // DELETE: api/BookAuthors/5
        [HttpDelete("{id}")]
         public async Task<IActionResult> Delete(BookAuthor bookAuthor)
        {
            if (bookAuthor == null) return BadRequest("BookAuhtor can not be null");

            var author = await _author.GetAuthor(bookAuthor.AuthorId);
            var book = await _book.Getbkbyid(bookAuthor.BookId);

            if (author == null || book == null) return BadRequest("Author or Book not found");

            author.BookAuthors!.Remove(bookAuthor);
            book.BookAuthors!.Remove(bookAuthor);

         //   await _author.UpdateAuthorAsync(author.AuthorId, author);
            await _book.Updatebk(book.BookId, book);

            return Ok("BookAuthor Deleted.");
        }

        private bool BookAuthorExists(int id)
        {
            return _context.BookAuthor.Any(e => e.AuthorId == id);
        }
    }
}
