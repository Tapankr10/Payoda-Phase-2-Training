using Apiproject.Interface;
using Apiproject.Model;
using Microsoft.EntityFrameworkCore;

namespace Apiproject.Repository
{
    public class AuthorRepository:IAuthor
    {
        private readonly BookDbConnext _context;
      

        public AuthorRepository(BookDbConnext context)
        {
            _context = context;
        }
        public async Task AddAsync(Author author)
        {
            await _context.Author.AddAsync(author);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int AuthorId)
        {
            var author = await _context.Author.FindAsync(AuthorId);
            if (author != null)
            {
                _context.Author.Remove(author);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _context.Author.Include(s => s.BookAuthors!).ThenInclude(s => s.book).ToListAsync() ?? throw new NullReferenceException();
        }

        public async Task<Author> GetAuthorById(int id)
        {
            return await _context.Author.Include(s => s.BookAuthors!).ThenInclude(s => s.book).FirstOrDefaultAsync(e => e.AuthorId == id) ?? throw new NullReferenceException();

        }

        public Task GetByIdAsync(Author author)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Author author)
        {
            var existingCourse = await _context.Author.FindAsync(author.AuthorId);
            if (existingCourse == null)
            {
                throw new KeyNotFoundException("Course not found.");
            }

            _context.Entry(existingCourse).CurrentValues.SetValues(author);
            await _context.SaveChangesAsync();
        }
    }
}
