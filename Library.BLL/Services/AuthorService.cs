using AutoMapper;
using Library.BLL.DTO;
using Library.BLL.Interfaces;
using Library.DAL.Interfaces;
using Library.DAL.Models;

namespace Library.BLL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repo;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public IEnumerable<AuthorDto> GetAll() =>
            _mapper.Map<IEnumerable<AuthorDto>>(_repo.GetAll());

        public AuthorDto? GetById(int id)
        {
            var author = _repo.GetById(id);
            return author is null ? null : _mapper.Map<AuthorDto>(author);
        }

        public AuthorDto Create(AuthorDto dto)
        {
            Validate(dto);
            var author = _mapper.Map<Author>(dto);
            var created = _repo.Create(author);
            return _mapper.Map<AuthorDto>(created);
        }

        public void Update(int id, AuthorDto dto)
        {
            Validate(dto);
            var author = _mapper.Map<Author>(dto);
            _repo.Update(id, author);
        }

        public void Delete(int id) => _repo.Delete(id);

        private static void Validate(AuthorDto dto)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(dto.Name))
                errors.Add("Имя пустое");

            if (dto.DateOfBirth > DateTime.Today)
                errors.Add("Дата рождения не может быть позже");

            if (errors.Count > 0)
                throw new ArgumentException(string.Join(" ", errors));
        }

    }
}
