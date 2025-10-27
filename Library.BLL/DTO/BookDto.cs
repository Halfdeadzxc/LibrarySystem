namespace Library.BLL.DTO
{
    public sealed record BookDto
    {
        public int Id { get; init; }
        public string Title { get; init; } = string.Empty;
        public int PublishedYear { get; init; }
        public int AuthorId { get; init; }
    }

}
