using Library.BLL.DTO;
using Library.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> GetAll()
        {
            var books = _service.GetAll();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<BookDto> GetById(int id)
        {
            var book = _service.GetById(id);
            return book is null ? NotFound() : Ok(book);
        }

        [HttpPost]
        public ActionResult<BookDto> Create([FromBody] BookDto dto)
        {
            var created = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] BookDto dto)
        {
            _service.Update(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }

        [HttpGet("after/{year}")]
        public ActionResult<IEnumerable<BookDto>> GetBooksPublishedAfter(int year)
        {
            var books = _service.GetBooksPublishedAfter(year);
            return Ok(books);
        }

    }

}
