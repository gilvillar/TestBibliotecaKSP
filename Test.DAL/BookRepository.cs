using Microsoft.EntityFrameworkCore;
using Test.Entities;

namespace Test.DAL
{
    /// <summary>
    /// Esta clase realiza las operaciones a la tabla de libros.
    /// </summary>
    public class BookRepository : IBookRepository
    {
        public BookRepository()
        {
            InitializedData();
        }

        /// <summary>
        /// Crea un libro.
        /// </summary>
        /// <param name="book">Objeto de tipo Book.</param>
        /// <returns>El libro creado.</returns>
        public async Task<Book> CreateBook(Book book)
        {
            using (var _context = new ApiContext())
            {
                _context.Add(book);
                await _context.SaveChangesAsync();

            }

            return book;
        }

        /// <summary>
        /// Elimina un libro.
        /// </summary>
        /// <param name="id">Valor que representa el id del libro.</param>
        /// <returns>Verdadero o falso.</returns>
        public async Task<bool> DeleteBook(int id)
        {
            int result = 0;

            using (var _context = new ApiContext())
            {
                var book = _context.Books.Find(id);

                if (book != null)
                {
                    _context.Remove<Book>(book);
                    result = await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("El libro no existe");
                }

            }

            return result == 1;
        }

        /// <summary>
        /// Obtiene todos los libros
        /// </summary>
        /// <returns>Una lista de libros.</returns>
        public async Task<List<Book>> GetAllBooks()
        {
            var result = new List<Book>();

            using (var _context = new ApiContext())
            {
                result = await _context.Books.ToListAsync();
            }

            return result;
        }

        /// <summary>
        /// Obtiene un libro por su titulo
        /// </summary>
        /// /// <param name="title">Valor que representa el titulo del libro.</param>
        /// <returns>El libro consultado</returns>
        public async Task<Book?> GetBookByTitle(string title)
        {
            Book? book;

            using (var _context = new ApiContext())
            {
                book = await _context.Books.Where(x=> x.Title.ToUpper() == title.ToUpper()).FirstOrDefaultAsync();
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
            Book? book;

            using (var _context = new ApiContext())
            {
                book = await _context.Books.FindAsync(id);
            }

            return book;
        }

        /// <summary>
        /// Actualiza los datos de un libro, prestamo y devolución.
        /// </summary>
        /// /// <param name="book">Valor que representa el libro a actualizar.</param>
        /// <returns>Verdadero o falso.</returns>
        public async Task<bool> UpdateBook(Book book)
        {
            int result = 0;
            using (var _context = new ApiContext())
            {
                _context.Entry(book).State = EntityState.Modified;
                result = await _context.SaveChangesAsync();
            }

            return result == 1;
        }

        /// <summary>
        /// Inserta datos iniciales a la base de datos
        /// </summary>
        private void InitializedData()
        {
            using (var _context = new ApiContext())
            {
                if (!_context.Books.Any())
                {
                    var books = new List<Book>
                    {
                        new Book
                        {
                            Id = 1,
                            Title="Caballo de Troya",
                            Author = "JJ. Benitez",
                            Stock = 5,
                            LendBooks=0,
                            Available=5
                        },
                        new Book {
                            Id = 2,
                            Title = "Azteca",
                            Author ="Gary Jennings",
                            Stock = 6,
                            LendBooks=0,
                            Available=6
                        },
                        new Book {
                            Id = 3,
                            Title = "El Psicoanalista",
                            Author="John Katzenbach",
                            Stock=4,
                            LendBooks=0,
                            Available=4
                        }
                    };

                    _context.Books.AddRange(books);
                    _context.SaveChanges();
                }
            }
        }

    }
}
