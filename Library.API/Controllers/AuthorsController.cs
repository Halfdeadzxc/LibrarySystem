using Library.BLL.DTO;
using Library.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _service;

        public AuthorsController(IAuthorService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AuthorDto>> GetAll()
        {
            var authors = _service.GetAll();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public ActionResult<AuthorDto> GetById(int id)
        {
            var author = _service.GetById(id);
            return author is null ? NotFound() : Ok(author);
        }

        [HttpPost]
        public ActionResult<AuthorDto> Create([FromBody] AuthorDto dto)
        {
            var created = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] AuthorDto dto)
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
    }
}
