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
            _bookService.Add(book);
            return Created($"book/{book.Id}", new object());
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] BookDTO book)
        {
            _bookService.Update(id, book);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _bookService.Remove(id);
            return NoContent();
        }
    }
}
