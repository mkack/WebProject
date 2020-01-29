using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.DTO;
using WebProject.Services;

namespace WebProject.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var books = _bookService.GetBooks();

            if (books == null)
            {
                return NotFound();
            }

            return Json(books);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return Json(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] BookDTO book)
        {
            var validationResult = _bookService.Add(book);

            if (!validationResult.IsSuccess)
            {
                return BadRequest($"{validationResult.Message}");  
            }

            return Created($"book/{book.Id}", new object());
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] BookDTO book)
        {
            var validationResult = _bookService.Update(id, book);

            if (!validationResult.IsSuccess)
            {
                return BadRequest($"{validationResult.Message}");
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var validationResult = _bookService.Remove(id);

            if (!validationResult.IsSuccess)
            {
                return BadRequest($"{validationResult.Message}");
            }

            return NoContent();
        }
    }
}
