using NewsPaper.Interface;
using NewsPaper.Model;

namespace NewsPaper.Service
{
    public class ArticleService
    {
        private readonly IArticle _author;

        public ArticleService(IArticle repo)
        {
            _author = repo;
        }
        public async Task<IEnumerable<Article>> GetAllArticleAsync()
        {
            return await _author.GetAllAsync();
        }

        public async Task<Article> GetArticle(int id)
        {
            return await _author.GetArticleById(id);
        }

        public async Task AddArticleAsync(Article article)
        {
            await _author.AddAsync(article);
        }

        public async Task UpdateArticlesync(Article article)
        {
            await _author.UpdateAsync(article);
        }

        public async Task DeleteAsync(int AuthorId)
        {
            await _author.DeleteAsync(AuthorId);
        }
    }
}
