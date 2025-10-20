using AutoMapper;
using Library.BLL.DTO;
using Library.DAL.Models;


namespace Library.BLL.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}
