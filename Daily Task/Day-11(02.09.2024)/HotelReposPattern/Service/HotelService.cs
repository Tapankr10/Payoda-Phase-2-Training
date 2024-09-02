using HotelReposPattern.Models;
using HotelReposPattern.Repository;

namespace HotelReposPattern.Service
{
    public class HotelService:IHotel
    {
        private readonly Models.HotelContext _dbContext;

        public HotelService(Models.HotelContext dbContext)
        {
            _dbContext = dbContext;
        }

       public IEnumerable<Hotel> GetAll()
        {
            return _dbContext.HotelSet.ToList();
        }

        public void AddHotel(Hotel hotel)
        {
            _dbContext.Add(hotel);
            _dbContext.SaveChanges();
        }
        public void UpdateHotel(int id ,Hotel hotel)
        {
            _dbContext.Update(hotel);
            _dbContext.SaveChanges();
        }
        public Hotel GetHotelById(int id)
        {
            var hotel = _dbContext.HotelSet.Find(id);
            if (hotel != null)
                return hotel;
            return null;
        }
        public void DeleteHotel(int id, Hotel hotel)
        {
            _dbContext.Remove(hotel);
            _dbContext.SaveChanges();
        }

    }
}

