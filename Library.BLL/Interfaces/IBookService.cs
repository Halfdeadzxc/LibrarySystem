using Library.BLL.DTO;

namespace Library.BLL.Interfaces
{
    public interface IBookService
    {
        IEnumerable<BookDto> GetAll();
        BookDto? GetById(int id);
        BookDto Create(BookDto dto);
        void Update(int id, BookDto dto);
        void Delete(int id);

    }

}
