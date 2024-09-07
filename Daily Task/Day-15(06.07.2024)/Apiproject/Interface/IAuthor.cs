using Apiproject.Model;

namespace Apiproject.Interface
{
    public interface IAuthor
    {
        Task<IEnumerable<Author>> GetAllAsync();
     //   Task<Author> GetByIdAsync(int AuthorId);
        Task AddAsync(Author author);
        Task UpdateAsync(Author author);
        Task DeleteAsync(int AuthorId);
        //Task GetByIdAsync(Author author);
        Task<Author> GetAuthorById(int id);
    }
}
