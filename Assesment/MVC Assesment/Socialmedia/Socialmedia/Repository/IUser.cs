using Socialmedia.Models;

namespace Socialmedia.Repository
{
    public interface IUser
    {
        public  IEnumerable<User> GetAll();

        User GetUserById(int id);

        public void AddUser(User user);
        void UpdateUser(int id, User user);
        void DeleteUser(int id, User user);

    }
}
