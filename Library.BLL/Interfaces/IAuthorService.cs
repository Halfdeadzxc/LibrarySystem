using Library.BLL.DTO;

namespace Library.BLL.Interfaces
{
    public interface IAuthorService
    {
        IEnumerable<AuthorDto> GetAll();
        AuthorDto? GetById(int id);
        AuthorDto Create(AuthorDto dto);
        void Update(int id, AuthorDto dto);
        void Delete(int id);
    }
}
