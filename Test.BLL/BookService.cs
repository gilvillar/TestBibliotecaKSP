using Test.Entities;

namespace Test.BLL
{
    public class BookService
    {
        readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> CreateBook(Book book)
        {
            return await _bookRepository.CreateBook(book);
        }

        public async Task<bool> DeleteBook(int id)
        {
            return await _bookRepository.DeleteBook(id);
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _bookRepository.GetAllBooks();
        }

        public async Task<bool> UpdateBook(Book book)
        {
            return await _bookRepository.UpdateBook(book);
        }
    }
}
