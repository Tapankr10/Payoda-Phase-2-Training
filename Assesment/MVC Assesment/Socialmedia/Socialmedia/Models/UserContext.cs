using Microsoft.EntityFrameworkCore;

namespace Socialmedia.Models
{
    public class UserContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasData(new User() { uId =1, UserName="Sai", Email="Abc@gmail.com"},
               new User() {uId= 2, UserName="Ravi", Email="abd@gamil.com" });
            modelBuilder.Entity<Post>()
           .HasData(new Post() { PostID = 101, Title = "Sun ", Content = "Story", CreatedDate = new DateTime(2024, 9, 1), UserId = 1 },

           new Post() { PostID = 102, Title = "Ram ", Content = "Fiction", CreatedDate = new DateTime(2024, 8, 23), UserId = 1 });

               modelBuilder.Entity<User>()

                 .HasMany(o => o.Posts)
                 .WithOne(c => c.user)
                 .HasForeignKey(c => c.UserId);

 



        }



    }
}
