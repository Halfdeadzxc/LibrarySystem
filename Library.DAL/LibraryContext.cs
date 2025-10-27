using Library.DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace Library.DAL
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);
            modelBuilder.Entity<Author>().HasData(
        new Author { Id = 1, Name = "Александр Пушкин", DateOfBirth = new DateTime(1799, 6, 6) },
        new Author { Id = 2, Name = "Лев Толстой", DateOfBirth = new DateTime(1828, 9, 9) }
    );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Евгений Онегин", PublishedYear = 1833, AuthorId = 1 },
                new Book { Id = 2, Title = "Война и мир", PublishedYear = 1869, AuthorId = 2 }
            );
        }
    }
}
