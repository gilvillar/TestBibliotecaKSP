using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.BLL;
using Test.Entities;

namespace TestBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
               var books = await _bookService.GetAllBooks();
                return Ok(books);
            
        }

        [HttpPost]
        public async Task<ActionResult> CreateBook(Book book)
        {
            var result = await _bookService.CreateBook(book);

            if(result?.Id != null)
            {
                return CreatedAtAction(nameof(CreateBook), new { id = book.Id }, book);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBook(id);

            if (result)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book book,byte operation)
        {
            var result = await _bookService.UpdateBook(id,book,operation);
            if (result)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
