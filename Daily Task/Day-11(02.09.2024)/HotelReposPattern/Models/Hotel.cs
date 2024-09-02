using System.ComponentModel.DataAnnotations;

namespace HotelReposPattern.Models
{
    public class Hotel
    {

        public  int HotelId { get; set; }
        public string HotelName { get; set; }

        [StringLength(30, ErrorMessage = "Hotel Name is minimum 10 character", MinimumLength = 5)]
        public ICollection<Room>? Rooms { get; set; }
    }

 
}
