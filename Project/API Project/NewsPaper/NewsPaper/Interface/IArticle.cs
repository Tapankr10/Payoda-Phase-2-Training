using NewsPaper.Model;

namespace NewsPaper.Interface
{
    public interface IArticle
    {
        Task<IEnumerable<Article>> GetAllAsync();
      //  Task<Author> GetByIdAsync(int AuthorId);
      Task AddAsync(Article article);
      Task UpdateAsync(Article article);
       Task DeleteAsync(int ArticleId);
        Task GetByIdAsync(Article article);
      Task<Article> GetArticleById(int id);
    }
}
