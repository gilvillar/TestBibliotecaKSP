
namespace Test.Entities
{
    /// <summary>
    /// Esta interfaz representa las operaciones que se pueden realizar a la tabla de libros.
    /// </summary>
    public interface IBookRepository
    {
        /// <summary>
        /// Crea un libro.
        /// </summary>
        /// <param name="book">Objeto de tipo Book.</param>
        /// <returns>El libro creado.</returns>
        Task<Book> CreateBook(Book book);

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
        Task<Book?> GetBookByTitle(string title);

        /// <summary>
        /// Obtiene un libro.
        /// </summary>
        /// <param name="id">Valor que representa el id del libro a buscar.</param>
        /// <returns>Verdadero o falso.</returns>
        Task<Book?> GetBookById(int id);

        /// <summary>
        /// Actualiza los datos de un libro, prestamo y devolución.
        /// </summary>
        /// /// <param name="book">Valor que representa el libro a actualizar.</param>
        /// <returns>Verdadero o falso.</returns>
        Task<bool> UpdateBook(Book book);
    }
}
