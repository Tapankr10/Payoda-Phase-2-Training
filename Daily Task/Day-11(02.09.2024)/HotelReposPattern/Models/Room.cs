using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReposPattern.Models
{
    public class Room
    {
        [Key]
       
        public int RoomNo { get; set; }
       
        public string RoomType { get; set; }

        public Double Price { get; set; }
        [Range(5000,200000, ErrorMessage ="Price should be between 5000 and 200000")]

        public int HotelId { get; set; }
        [ForeignKey ("HotelId")]
        public Hotel ? Hotel {  get; set; }


    }
}
