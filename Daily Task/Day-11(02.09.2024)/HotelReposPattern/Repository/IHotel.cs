using HotelReposPattern.Models;

namespace HotelReposPattern.Repository
{
    public interface IHotel
    {
        public IEnumerable<Hotel> GetAll();

        Hotel  GetHotelById(int id);

        public void AddHotel(Hotel hotel);
        void UpdateHotel(int id, Hotel hotel);
        void DeleteHotel(int id, Hotel hotel);






    }
}
