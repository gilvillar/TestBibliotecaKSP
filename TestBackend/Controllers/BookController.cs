using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.BLL;
using Test.Entities;

namespace TestBackend.Controllers
{
    /// <summary>
    /// Esta clase representa la capa de presentacion de la administracion de libros.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Crea un libro.
        /// </summary>
        /// <param name="book">Objeto de tipo Book.</param>
        /// <returns>CreatedAtActionResult</returns>
        [HttpPost]
        public async Task<ActionResult> CreateBook(Book model)
        {
            //obtenemos el libro creado
            var book = await _bookService.CreateBook(model);


            if (book == null) //si es null es porque el libro ya existe y enviamos un ConflictResult
            {
                return Conflict();
            }
            else if (book?.Id == 0) // si el id es cero es porque ocurrio un error a un nivel mas interno
            {
                return BadRequest();
            }

            //si todo pasa bien enviamos un CreatedAtActionResult
            return CreatedAtAction(nameof(CreateBook), new { id = book.Id }, book);
        }


        /// <summary>
        /// Elimina un libro.
        /// </summary>
        /// <param name="id">Valor que representa el id del libro.</param>
        /// <returns>NoContent o BadRequest.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            //eliminamos el libro
            var result = await _bookService.DeleteBook(id);

            if (result) //si result es verdadero se elimino el libro correctamente
            {
                return NoContent();
            }
            else //si es falso sucedio un error
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Obtiene todos los libros
        /// </summary>
        /// <returns>OkObjectResult</returns>
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            //obtenemos la lista de libros
            var books = await _bookService.GetAllBooks();

            return Ok(books);
        }

        /// <summary>
        /// Actualiza los datos de un libro.
        /// </summary>
        /// <param name="id">Valor que representa el id del libro a actualizar.</param>
        /// /// <param name="book">Valor que representa el libro a actualizar.</param>
        /// <returns>NoContent o BadRequest.</returns>

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book book)
        {
            //actualizamos los datos del libro
            var result = await _bookService.UpdateBook(id, book);

            if (result) //si es verdadero el libro se actualizo correctamente
            {
                return NoContent();
            }
            else //si es falso ocurrio un error
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Realiza el prestamo de un libro.
        /// </summary>
        /// <param name="id">Valor que representa el id del libro a actualizar.</param>
        /// /// /// <param name="book">Valor que representa el libro a actualizar.</param>
        /// <returns>NoContent o BadRequest.</returns>

        //[Authorize]
        [HttpPut("{id}/lend")]
        public async Task<IActionResult> LendBook(int id, Book book)
        {
            //realizamos el prestamo de un libro
            var result = await _bookService.UpdateBook(id, book);
            if (result)
            {
                return NoContent(); //si es verdadero el libro se actualizo correctamente
            }
            else
            {
                return BadRequest(); //si es falso ocurrio un error
            }
        }

        /// <summary>
        /// Realiza la devolución de un libro.
        /// </summary>
        /// <param name="id">Valor que representa el id del libro a actualizar.</param>
        /// /// /// <param name="book">Valor que representa el libro a actualizar.</param>
        /// <returns>NoContent o BadRequest.</returns>
        
        [HttpPut("{id}/return")]
        public async Task<IActionResult> ReturnBook(int id, Book book)
        {
            //realizamos la devolución de un libro
            var result = await _bookService.UpdateBook(id, book);
            if (result)
            {
                return NoContent();  //si es verdadero el libro se actualizo correctamente
            }
            else
            {
                return BadRequest(); //si es falso ocurrio un error
            }
        }
    }
}
