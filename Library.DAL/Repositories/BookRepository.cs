using Library.DAL.Interfaces;
using Library.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAll() =>
            _context.Books.Include(b => b.Author).ToList();

        public Book? GetById(int id) =>
            _context.Books.Include(b => b.Author).FirstOrDefault(b => b.Id == id);

        public Book Create(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new ArgumentException("У книги нет названия");

            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public void Update(int id, Book updated)
        {
            var book = _context.Books.Find(id);
            if (book is null) return;

            if (string.IsNullOrWhiteSpace(updated.Title))
                throw new ArgumentException("У книги нет названия");

            book.Title = updated.Title;
            book.PublishedYear = updated.PublishedYear;
            book.AuthorId = updated.AuthorId;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book is not null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
