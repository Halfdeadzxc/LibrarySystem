using Library.DAL.Interfaces;
using Library.DAL.Models;

namespace Library.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books = [];

        public IEnumerable<Book> GetAll() => _books;

        public Book? GetById(int id) => _books.FirstOrDefault(b => b.Id == id);

        public Book Create(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new ArgumentException("У книги нет названия");

            book.Id = _books.Count > 0 ? _books.Max(b => b.Id) + 1 : 1;
            _books.Add(book);
            return book;
        }

        public void Update(int id, Book updated)
        {
            var book = GetById(id);
            if (book is null) return;

            if (string.IsNullOrWhiteSpace(updated.Title))
                throw new ArgumentException("У книги нет названия");

            book.Title = updated.Title;
            book.PublishedYear = updated.PublishedYear;
            book.AuthorId = updated.AuthorId;
        }

        public void Delete(int id)
        {
            var book = GetById(id);
            if (book is not null) _books.Remove(book);
        }
    }
}
