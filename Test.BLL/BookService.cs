using Microsoft.Extensions.Logging;
using System;
using Test.Entities;

namespace Test.BLL
{
    /// <summary>
    /// Esta clase representa la logica de negocio de los libros.
    /// </summary>
    public class BookService : IBookService
    {
        readonly IBookRepository _bookRepository;
        private readonly ILogger<IBookRepository> _logger;

        public BookService(IBookRepository bookRepository, ILogger<IBookRepository> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        /// <summary>
        /// Crea un libro.
        /// </summary>
        /// <param name="book">Objeto de tipo Book.</param>
        /// <returns>El libro creado.</returns>
        public async Task<Book?> CreateBook(Book book)
        {
            Book? result = new Book();
            try
            {
                //validamos que el titulo y autor estan vacios
                if (string.IsNullOrEmpty(book.Title) && string.IsNullOrEmpty(book.Author))
                {
                    //si estan vacios generamos un excepcion y mandamos al log
                    throw new Exception("El titulo y autor del libro son obligatorios");
                }
                else
                {
                    //verificamos si el libro existe
                    var existe = await GetBookByTitle(book.Title);
                    if (existe != null)
                    {
                        //si existe generamos una excepción y mandamos al log
                        result = null;
                        throw new Exception("El libro ya existe");
                    }
                }

                //si las conciiones se cumplen generamos un nuevo libro
                result = await _bookRepository.CreateBook(book);
            }
            catch (Exception ex)
            {
                //registramos las excepciones en el log
                _logger.LogError(ex, "Ocurrio un error al intentar crear el libro.");
            }

            return result;
        }

        /// <summary>
        /// Elimina un libro.
        /// </summary>
        /// <param name="id">Valor que representa el id del libro.</param>
        /// <returns>Verdadero o falso.</returns>
        public async Task<bool> DeleteBook(int id)
        {
            bool result = false;
            try
            {
                //eliminamos un libro y retornamos el resultado
                return await _bookRepository.DeleteBook(id);

            }
            catch (Exception ex)
            {
                //si ocurre un error se registra en el log.
                _logger.LogError(ex, "Ocurrio un error al intentar eliminar el libro.");
            }

            return result;

        }

        /// <summary>
        /// Obtiene todos los libros
        /// </summary>
        /// <returns>Una lista de libros.</returns>
        public async Task<List<Book>> GetAllBooks()
        {
            //obtenemos el listado de libros
            var books = await _bookRepository.GetAllBooks();

            return books;
        }

        /// <summary>
        /// Obtiene un libro por su titulo
        /// </summary>
        /// /// <param name="title">Valor que representa el titulo del libro.</param>
        /// <returns>El libro consultado</returns>
        public async Task<Book?> GetBookByTitle(string title)
        {
            Book? book = new Book();
            try
            {
                //obtenemos el libro y lo retornamos
                return await _bookRepository.GetBookByTitle(title);
            }
            catch (Exception ex)
            {
                //si ocurre un error se registra en el log.
                _logger.LogError(ex, "Ocurrio un error al intentar obtener el libro");
            }

            return book;
        }

        /// <summary>
        /// Obtiene un libro.
        /// </summary>
        /// <param name="id">Valor que representa el id del libro a buscar.</param>
        /// <returns>Verdadero o falso.</returns>

        public async Task<Book?> GetBookById(int id)
        {
            Book? book = new Book();
            try
            {
                //obtenemos el libro y lo retornamos
                return await _bookRepository.GetBookById(id);
            }
            catch (Exception ex)
            {
                //si ocurre un error se registra en el log.
                _logger.LogError(ex, "Ocurrio un error al intentar obtener el libro");
            }

            return book;

        }

        /// <summary>
        /// Actualiza los datos de un libro.
        /// </summary>
        /// <param name="id">Valor que representa el id del libro a actualizar.</param>
        /// /// <param name="book">Valor que representa el libro a actualizar.</param>
        /// <returns>Verdadero o falso.</returns>
        public async Task<bool> UpdateBook(int id, Book book)
        {
            bool result = false;

            try
            {
                //validamos si el id coincide con el id del libro
                if (id != book.Id)
                {
                    //en caso de que no coincidad se retorna un false y se genera una excepcion
                    result = false;
                    throw new Exception("El id del libro es incorrecto");
                }
                else
                {
                    //verificamos si el libro existe o no
                    var existe = _bookRepository.GetBookById(book.Id);

                    //si el libro no existe retornamos un false y se genera una excepcion
                    if (existe == null)
                    {
                        result = false;
                        throw new Exception("El libro no existe");
                    }

                    //si todo pasa bien se actualiza el libro
                    result = await _bookRepository.UpdateBook(book);
                }
            }
            catch (Exception ex)
            {
                //si ocurre un error se registra en el log.
                _logger.LogError(ex, "Ocurrio un error al intentar actualizar el libro.");
            }

            return result;

        }

        /// <summary>
        /// Realiza el prestamo de un libro.
        /// </summary>
        /// <param name="id">Valor que representa el id del libro a actualizar.</param>
        /// /// /// <param name="book">Valor que representa el libro a actualizar.</param>
        /// <returns>Verdadero o falso.</returns>
        public async Task<bool> LendBook(int id, Book book)
        {
            bool result = false;

            try
            {
                //validamos si el id coincide con el id del libro
                if (id != book.Id)
                {
                    result = false;
                    throw new Exception("El id del libro es incorrecto");
                }
                else
                {
                    //verificamos si el libro existe o no
                    var existe = await _bookRepository.GetBookById(book.Id);

                    //si el libro no existe retornamos un false y se genera una excepcion
                    if (existe == null)
                    {
                        result = false;
                        throw new Exception("El libro no existe");
                    }
                    else if(existe.Available == 0) //verificamos si hay libros disponibles para prestar
                    {
                        //si no hay libros disponibles se retorna falso y se genera una excepcion
                        result = false;
                        throw new Exception("No hay libros disponibles");
                    }

                    //si todo pasa bien realizamos la operacion
                    result = await _bookRepository.UpdateBook(book);
                }
            }
            catch (Exception ex)
            {
                //si ocurre un error se registra en el log.
                _logger.LogError(ex, "Ocurrio un error al intentar actualizar el libro.");
            }

            return result;
        }

        /// <summary>
        /// Realiza la devolución de un libro.
        /// </summary>
        /// <param name="id">Valor que representa el id del libro a actualizar.</param>
        /// /// /// <param name="book">Valor que representa el libro a actualizar.</param>
        /// <returns>Verdadero o falso.</returns>
        public async Task<bool> ReturnBook(int id, Book book)
        {
            bool result = false;

            try
            {
                //validamos si el id coincide con el id del libro
                if (id != book.Id)
                {
                    result = false;
                    throw new Exception("El id del libro es incorrecto");
                }
                else
                {
                    //verificamos si el libro existe o no
                    var existe = await _bookRepository.GetBookById(book.Id);

                    //si el libro no existe retornamos un false y se genera una excepcion
                    if (existe == null)
                    {
                        result = false;
                        throw new Exception("El libro no existe");
                    }
                    else if (existe.LendBooks == 0) //verificamos si hay libros prestados para devolver
                    {
                        result = false;
                        throw new Exception("No hay libros prestados");
                    }

                    // si todo pasa bien realizamos la operacion
                    result = await _bookRepository.UpdateBook(book);
                }
            }
            catch (Exception ex)
            {
                //si ocurre un error se registra en el log.
                _logger.LogError(ex, "Ocurrio un error al intentar actualizar el libro.");
            }

            return result;
        }
    }
}
