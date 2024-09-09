using Microsoft.EntityFrameworkCore;

namespace NewsPaper.Model
{
    public class NewsDbContext:DbContext
    {
       

        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<User> users { get; set; }
        public NewsDbContext(DbContextOptions<NewsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships if necessary
            modelBuilder.Entity<Article>()
                .HasOne(a => a.Authors)
                .WithMany(b => b.Articles)
                .HasForeignKey(a => a.AuthorID);
        
      
            // Seed data for Authors
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    AuthorID = 1,
                    Name = "John Doe",
                    CredibilityScore = 9.5m,
                    Bio = "John Doe is a veteran journalist with over 20 years of experience in investigative reporting."
                },
                new Author
                {
                    AuthorID = 2,
                    Name = "Jane Smith",
                    CredibilityScore = 8.7m,
                    Bio = "Jane Smith is an award-winning author and editor, known for her insightful articles on technology and innovation."
                }
            );

            // Seed data for Articles
            modelBuilder.Entity<Article>().HasData(
                new Article
                {
                    ArticleID = 1,
                    Title = "Breaking News: Major Event in Tech",
                    Content = "A major event has shaken the tech world, with significant implications for the industry.",
                    PublishedDate = DateTime.Now.AddDays(-10),
                    AuthorID = 1, // Foreign key to Author with AuthorID = 1
                    Views = 1200
                },
                new Article
                {
                    ArticleID = 2,
                    Title = "Healthcare Advances in 2024",
                    Content = "The latest advances in healthcare technology are transforming patient care.",
                    PublishedDate = DateTime.Now.AddDays(-5),
                    AuthorID = 2, // Foreign key to Author with AuthorID = 2
                    Views = 850
                },
                new Article
                {
                    ArticleID = 3,
                    Title = "The Future of AI and Robotics",
                    Content = "AI and robotics are set to revolutionize various industries. Here's what to expect in the coming years.",
                    PublishedDate = DateTime.Now.AddDays(-2),
                    AuthorID = 2, // Foreign key to Author with AuthorID = 2
                    Views = 2300
                }
            );
        }
    }
}
