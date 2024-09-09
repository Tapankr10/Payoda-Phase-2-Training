using Microsoft.EntityFrameworkCore;
using NewsPaper.Interface;
using NewsPaper.Model;

namespace NewsPaper.Repository
{
    public class ArticleRepository : IArticle
    {
        private readonly NewsDbContext _context;


        public ArticleRepository(NewsDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Article article)
        {
            await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int ArticleId)
        {
            var author = await _context.Articles.FindAsync(ArticleId);
            if (author != null)
            {
                _context.Articles.Remove(author);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _context.Articles.ToListAsync() ?? throw new NullReferenceException();
        }

        //public async Task<Article> GetArticleById(int id)
        //{
        //    return await _context.Articles.FirstOrDefaultAsync(e => e.ArticleID == id) ?? throw new NullReferenceException();

        //}
        public async Task<Article> GetArticleById(int id)
        {
            var article = await _context.Articles.FirstOrDefaultAsync(e => e.ArticleID == id);

            if (article == null)
            {
                throw new KeyNotFoundException($"Article with ID {id} not found.");
            }

            return article;
        }


        public Task GetByIdAsync(Article article)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Article article)
        {
            var existingCourse = await _context.Articles.FindAsync(article.ArticleID);
            if (existingCourse == null)
            {
                throw new KeyNotFoundException("Course not found.");
            }

            _context.Entry(existingCourse).CurrentValues.SetValues(article);
            await _context.SaveChangesAsync();
        }
    
}
}
