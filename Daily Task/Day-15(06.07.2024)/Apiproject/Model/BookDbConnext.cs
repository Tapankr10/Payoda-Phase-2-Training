using Microsoft.EntityFrameworkCore;
using Apiproject.Model;

namespace Apiproject.Model
{
    public class BookDbConnext : DbContext
    {

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Author { get; set; }
        //  public BookDbConnext(DbContextOptions opt) : base(opt) { }

        public BookDbConnext(DbContextOptions<BookDbConnext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.AuthorId, ba.BookId });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.book)
                .WithMany(ba => ba.BookAuthors)
                .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(ba => ba.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);
        }
        public DbSet<Apiproject.Model.BookAuthor> BookAuthor { get; set; } = default!;


    }
}
