using Socialmedia.Models;

namespace Socialmedia.Repository
{
    public interface IPost
    {
        public IEnumerable<Post> GetAll();
        Post GetPostById(int id);

        public void AddPost(Post post);
        void UpdatePost(int id, Post post);
        void DeletePost(int id, Post post);
    }
}
