using AutoMapper;
using BookApi.Model.Domain;
using BookApi.Model.DTO;

namespace BookApi.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            //Convert the book data into my dto automatically
            CreateMap<Book, BookDTO>().ReverseMap();
        }
    }
}
