using BookShelfApi.Dtos;
using BookShelfApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookShelfApi.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _bookService.GetAll();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _bookService.GetById(id);

            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }
        [HttpPost]
        public IActionResult Create(CreateBookDTO dto)
        {
            var book = _bookService.Create(dto);

            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPatch("{id}/read")]
        public IActionResult MarkAsRead(int id)
        {
            var updated = _bookService.MarkAsRead(id);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _bookService.Delete(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
