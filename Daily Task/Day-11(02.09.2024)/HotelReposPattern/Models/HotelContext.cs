using Microsoft.EntityFrameworkCore;

namespace HotelReposPattern.Models
{
    public class HotelContext: DbContext
    {

        public DbSet<Hotel> HotelSet { get; set; }  
        public DbSet<Room> RoomSet { get; set; }    
        public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }

        protected  override void  OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=PTSQLTESTDB01;database=Hotel_tapan;integrated security=true;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
               .HasData(new Hotel() { HotelId = 1, HotelName = "Taj Hotel" },
               new Hotel() { HotelId = 2, HotelName = "Phenoix" });
            modelBuilder.Entity<Room>()
                .HasData(new Room() { RoomNo = 1, RoomType = "AC", Price = 35000 },
                new Room() { RoomNo = 2, RoomType = " Normal", Price = 4000 });

            modelBuilder.Entity<Hotel>()

                 .HasMany(o => o.Rooms)
                 .WithOne(c => c.Hotel)
                 .HasForeignKey(c => c.HotelId);

            modelBuilder.Entity<Room>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

                
        }

    }
}
