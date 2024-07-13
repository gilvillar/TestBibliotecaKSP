using Microsoft.EntityFrameworkCore;
using Test.Entities;

namespace Test.DAL
{
    internal class BookRepository : IBookRepository
    {
        public BookRepository()
        {
            InitializedData();
        }

        public async Task<Book> CreateBook(Book book)
        {
            using (var _context = new ApiContext())
            {
                _context.Add(book);
                await _context.SaveChangesAsync();

            }

            return book;
        }

        public async Task<Book> GetBookById(int id)
        {
            Book? book;

            using (var _context = new ApiContext())
            {
                book = await _context.Books.FindAsync(id);
            }

            return book ?? new Book();
        }

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

            }

            return result == 1;
        }


        public async Task<List<Book>> GetAllBooks()
        {
            var result = new List<Book>();

            using (var _context = new ApiContext())
            {
                result = await _context.Books.ToListAsync();
            }

            return result;
        }

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
                            LentBooks=0,
                            Available=5
                        },
                        new Book {
                            Id = 2,
                            Title = "Azteca",
                            Author ="Gary Jennings",
                            Stock = 6,
                            LentBooks=0,
                            Available=6
                        },
                        new Book {
                            Id = 3,
                            Title = "El Psicoanalista",
                            Author="John Katzenbach",
                            Stock=4,
                            LentBooks=0,
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
