using HotelReposPattern.Models;
using HotelReposPattern.Repository;
using Microsoft.EntityFrameworkCore;

namespace HotelReposPattern.Service
{
    public class Roomservice : IRoom
    {
        private readonly Models.HotelContext _dbContext;

        public Roomservice(Models.HotelContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Room> GetAll()
        {

            return _dbContext.RoomSet.Include(h => h.Hotel).ToList();
        }

    }
}
