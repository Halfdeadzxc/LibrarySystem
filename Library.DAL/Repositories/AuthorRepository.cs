using Library.DAL.Interfaces;
using Library.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext _context;

        public AuthorRepository(LibraryContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetAll() =>
            _context.Authors.Include(a => a.Books).ToList();

        public Author? GetById(int id) =>
            _context.Authors.Include(a => a.Books).FirstOrDefault(a => a.Id == id);

        public Author Create(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return author;
        }

        public void Update(int id, Author updated)
        {
            var author = _context.Authors.Find(id);
            if (author is null) return;

            author.Name = updated.Name;
            author.DateOfBirth = updated.DateOfBirth;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var author = _context.Authors.Find(id);
            if (author is not null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }
    }
}
