using AutoMapper;
using BookApi.Model.Domain;
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
            return Ok(bookList);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetByIdBook")]
        public async Task<IActionResult> GetByIdBook(int id)
        {
            var result = await bookRepository.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookDTO book)
        {
            var result = bookRepository.SaveBook(book);
            return CreatedAtAction(nameof(GetByIdBook), new { id = book.Id }, book);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> updateBook([FromRoute] int id, [FromBody] BookDTO book)
        {
            var result = bookRepository.UpdateBook(id, book);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> deleteBook(int id)
        {
            return Ok(bookRepository.DeleteById(id));
        }
    }
}
