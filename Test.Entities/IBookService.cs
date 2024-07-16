using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Entities
{
    /// <summary>
    /// Esta interfaz representa las operaciones que se pueden de libros.
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Crea un libro.
        /// </summary>
        /// <param name="book">Objeto de tipo Book.</param>
        /// <returns>El libro creado.</returns>
        Task<Book?> CreateBook(Book book);

        /// <summary>
        /// Elimina un libro.
        /// </summary>
        /// <param name="id">Valor que representa el id del libro.</param>
        /// <returns>Verdadero o falso.</returns>
        Task<bool> DeleteBook(int id);

        /// <summary>
        /// Obtiene todos los libros
        /// </summary>
        /// <returns>Una lista de libros.</returns>
        Task<List<Book>> GetAllBooks();

        /// <summary>
        /// Obtiene un libro por su titulo
        /// </summary>
        /// /// <param name="title">Valor que representa el titulo del libro.</param>
        /// <returns>El libro consultado</returns>
        Task<Book> GetBookByTitle(string title);

        /// <summary>
        /// Obtiene un libro.
        /// </summary>
        /// <param name="id">Valor que representa el id del libro a buscar.</param>
        /// <returns>Verdadero o falso.</returns>
        Task<Book?> GetBookById(int id);

        /// <summary>
        /// Actualiza los datos de un libro.
        /// </summary>
        /// <param name="id">Valor que representa el id del libro a actualizar.</param>
        /// /// <param name="book">Valor que representa el libro a actualizar.</param>
        /// <returns>Verdadero o falso.</returns>
        Task<bool> UpdateBook(int id, Book book);

        /// <summary>
        /// Realiza el prestamo de un libro.
        /// </summary>
        /// <param name="id">Valor que representa el id del libro a actualizar.</param>
        /// /// /// <param name="book">Valor que representa el libro a actualizar.</param>
        /// <returns>Verdadero o falso.</returns>
        Task<bool> LendBook(int id, Book book);

        /// <summary>
        /// Realiza la devolución de un libro.
        /// </summary>
        /// <param name="id">Valor que representa el id del libro a actualizar.</param>
        /// /// /// <param name="book">Valor que representa el libro a actualizar.</param>
        /// <returns>Verdadero o falso.</returns>
        Task<bool> ReturnBook(int id, Book book);
    }
}
