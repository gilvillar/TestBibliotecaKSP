using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult> CreateBook(Book model)
        {
            var book = await _bookService.CreateBook(model);

            if(book == null)
            {
                return Conflict();
            }
            else if(book?.Id ==0)
            {
                return BadRequest();
            }
             
            return CreatedAtAction(nameof(CreateBook), new { id = book.Id }, book);
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
        public async Task<IActionResult> UpdateBook(int id, Book book)
        {
            var result = await _bookService.UpdateBook(id,book);
            if (result)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPut("{id}/lend")]
        public async Task<IActionResult> LendBook(int id, Book book)
        {
            var result = await _bookService.UpdateBook(id, book);
            if (result)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}/return")]
        public async Task<IActionResult> ReturnBook(int id, Book book)
        {
            var result = await _bookService.UpdateBook(id, book);
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
