using AutoMapper;
using BookApi.Model.DTO;
using BookApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("Book")]
    public class BookController : Controller
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;

        public BookController(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var bookList = await bookRepository.GetAllAsync();

            /*
            var bookListDTO = new List<BookDTO>();
            bookList.ToList().ForEach(item =>
            {
                var bookDTO = new BookDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Autor = item.Autor,
                    Year = item.Year,

                };
                bookListDTO.Add(bookDTO);
            });
            */

            var bookListDTO = mapper.Map<List<BookDTO>>(bookList);
            return Ok(bookListDTO);
        }
    }
}
