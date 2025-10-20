using Library.DAL.Models;

namespace Library.DAL.Interfaces
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll();
        Author? GetById(int id);
        Author Create(Author author);
        void Update(int id, Author author);
        void Delete(int id);
    }
}
