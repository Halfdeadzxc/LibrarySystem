using AutoMapper;
using Library.BLL.DTO;
using Library.BLL.Interfaces;
using Library.DAL.Interfaces;
using Library.DAL.Models;

namespace Library.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public IEnumerable<BookDto> GetAll() =>
            _mapper.Map<IEnumerable<BookDto>>(_repo.GetAll());

        public BookDto? GetById(int id)
        {
            var book = _repo.GetById(id);
            return book is null ? null : _mapper.Map<BookDto>(book);
        }

        public BookDto Create(BookDto dto)
        {
            Validate(dto);

            var book = _mapper.Map<Book>(dto);
            var created = _repo.Create(book);
            return _mapper.Map<BookDto>(created);
        }

        public void Update(int id, BookDto dto)
        {
            Validate(dto);

            var book = _mapper.Map<Book>(dto);
            _repo.Update(id, book);
        }

        public void Delete(int id) => _repo.Delete(id);

        private static void Validate(BookDto dto)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(dto.Title))
                errors.Add("Пустое название");

            if (dto.PublishedYear < 0)
                errors.Add("Год должен быть положительным");

            if (dto.AuthorId <= 0)
                errors.Add("Id автора больше 0");

            if (errors.Count > 0)
                throw new ArgumentException(string.Join(" ", errors));
        }
    }
}
