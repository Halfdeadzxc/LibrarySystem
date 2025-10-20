namespace Library.BLL.DTO
{
    public sealed record BookDto(
    int Id,
    string Title,
    int PublishedYear,
    int AuthorId
    );
}
