using Apiproject.Interface;
using Apiproject.Model;

namespace Apiproject.Service
{
    public class AuthorService
    {
        private readonly IAuthor _author;

        public AuthorService(IAuthor repo)
        {
            _author = repo;
        }
        public async Task<IEnumerable<Author>> GetAllAuthorAsync()
        {
            return await _author.GetAllAsync();
        }

        public async Task<Author> GetAuthor(int id)
        {
            return await _author.GetAuthorById(id);
        }

        public async Task AddAuthorAsync(Author author)
        {
            await _author.AddAsync(author);
        }

        public async Task UpdateAuthorAsync(Author author)
        {
            await _author.UpdateAsync(author);
        }

        public async Task DeleteAsync(int AuthorId)
        {
            await _author.DeleteAsync(AuthorId);
        }
    }
}
