using Microsoft.EntityFrameworkCore;
using Socialmedia.Models;
using Socialmedia.Repository;

namespace Socialmedia.Service
{
    public class PostService:IPost
    {


        private readonly Models.UserContext _dbContext;

        public PostService(Models.UserContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Post> GetAll()
        {
            return _dbContext.Posts.Include(p => p.user).ToList();
        }
        public void AddPost(Post post)
        {
            _dbContext.Add(post);
            _dbContext.SaveChanges();
        }
        public void UpdatePost(int id, Post post)
        {
            _dbContext.Update(post);
            _dbContext.SaveChanges();
        }
        public Post GetPostById(int id)
        {
            return _dbContext.Posts.Include(u => u.user).FirstOrDefault(p => p.PostID == id);
        }
        public void DeletePost(int id, Post post)
        {
            _dbContext.Remove(post);
            _dbContext.SaveChanges();
        }


    }
}
