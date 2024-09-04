using Socialmedia.Models;
using Socialmedia.Repository;

namespace Socialmedia.Service
{
    public class UserService:IUser
    {
        private readonly Models.UserContext _dbContext;

        public UserService(Models.UserContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public void AddUser(User user)
        {
            _dbContext.Add(user);
            _dbContext.SaveChanges();
        }
        public void UpdateUser(int id, User user)
        {
            _dbContext.Update(user);
            _dbContext.SaveChanges();
        }
        public User GetUserById(int id)
        {
            var user = _dbContext.Users.Find(id);
            if (user != null)
                return user;
            return null;
        }
        public void DeleteUser(int id, User user)
        {
            _dbContext.Remove(user);
            _dbContext.SaveChanges();
        }

    }
}
