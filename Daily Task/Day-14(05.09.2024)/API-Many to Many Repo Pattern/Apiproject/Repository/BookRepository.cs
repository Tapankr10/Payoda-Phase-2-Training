using Apiproject.Interface;
using Apiproject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apiproject.Repository
{
    public class BookRepository:IBook
    {
        private readonly BookDbConnext _context;
        public BookRepository(BookDbConnext context)
        {
            _context = context;
        }
        // GET: api/Books
        //[HttpGet]
        public async Task<IEnumerable<Book>> GetBook()
        {
            return await _context.Books.Include(b => b.BookAuthors!)
                  .ThenInclude(a => a.Author)
                  .ToListAsync();
        }

        // GET: api/Books/5
        //[HttpGet("{id}")]
        public async Task<Book> GetBookById(int id)
        {
            return await _context.Books.Include(b => b.BookAuthors!)
                  .ThenInclude(a => a.Author).FirstOrDefaultAsync(e => e.BookId == id) ?? throw new NullReferenceException();
        }

        // PUT: api/Books/5

        //[HttpPut("{id}")]
        public async Task PutBook(int id, Book e)
        {
            if (id == e.BookId)
            {
                _context.Entry(e).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        // POST: api/Books

        [HttpPost]
        public async Task PostBook(Book e)
        {
            await _context.Books.AddAsync(e);
            await _context.SaveChangesAsync();
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task DeleteBook(int id)
        {
            var b = await _context.Books.FindAsync(id);
            if (b != null)
            {
                _context.Books.Remove(b);
                await _context.SaveChangesAsync();
            }
        }
    }
}
