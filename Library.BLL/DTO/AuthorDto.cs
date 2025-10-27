namespace Library.BLL.DTO
{
    public sealed record AuthorDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public DateTime DateOfBirth { get; init; }
        public int BookCount { get; init; }
    }

}
