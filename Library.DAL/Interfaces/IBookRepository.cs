using Library.DAL.Models;

namespace Library.DAL.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book? GetById(int id);
        Book Create(Book book);
        void Update(int id, Book book);
        void Delete(int id);
    }
}
