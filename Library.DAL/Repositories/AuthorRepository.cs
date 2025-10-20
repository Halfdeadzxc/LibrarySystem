using Library.DAL.Interfaces;
using Library.DAL.Models;

namespace Library.DAL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly List<Author> _authors = [];

        public IEnumerable<Author> GetAll() => _authors;

        public Author? GetById(int id) => _authors.FirstOrDefault(a => a.Id == id);

        public Author Create(Author author)
        {
            author.Id = _authors.Count > 0 ? _authors.Max(a => a.Id) + 1 : 1;
            _authors.Add(author);
            return author;
        }

        public void Update(int id, Author updated)
        {
            var author = GetById(id);
            if (author is null) return;
            author.Name = updated.Name;
            author.DateOfBirth = updated.DateOfBirth;
        }

        public void Delete(int id)
        {
            var author = GetById(id);
            if (author is not null) _authors.Remove(author);
        }
    }
}
