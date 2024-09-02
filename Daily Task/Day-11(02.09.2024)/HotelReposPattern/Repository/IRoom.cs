using HotelReposPattern.Models;

namespace HotelReposPattern.Repository
{
    public interface IRoom
    {
        public IEnumerable<Room> GetAll();
    }
}
