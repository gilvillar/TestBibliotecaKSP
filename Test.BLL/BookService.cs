using Microsoft.Extensions.Logging;
using Test.Entities;

namespace Test.BLL
{
    public class BookService : IBookService
    {
        readonly IBookRepository _bookRepository;
        private readonly ILogger<IBookRepository> _logger;

        public BookService(IBookRepository bookRepository, ILogger<IBookRepository> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public async Task<Book?> CreateBook(Book book)
        {
            Book? result = null;
            try
            {
                if(book != null && !string.IsNullOrEmpty(book.Title) && !string.IsNullOrEmpty(book.Author)) {
                    result = await _bookRepository.CreateBook(book);
                }
                else
                {
                    throw new Exception("El titulo y autor del libro son obligatorios");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrio un error al intentar crear el libro.");
            }

            return result;
        }

        public async Task<bool> DeleteBook(int id)
        {
            bool result = false;
            try
            {
                return await _bookRepository.DeleteBook(id);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrio un error al intentar eliminar el libro.");
            }

            return result;

        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _bookRepository.GetAllBooks();
        }

        public async Task<bool> UpdateBook(int id, Book book, byte operation)
        {
            bool result = false;

            try
            {
                if (id != book.Id)
                {
                    result = false;
                    throw new Exception("El id del libro es incorrecto");
                }
                else
                {
                    result = await _bookRepository.UpdateBook(book);
                }
            }
            catch (Exception ex)
            {
                switch (operation)
                {
                    case 1:
                        _logger.LogError(ex, "Ocurrio un error al intentar actualizar el libro.");
                        break;
                    case 2:
                        _logger.LogError(ex, "Ocurrio un error al intentar prestar el libro.");
                        break;
                    case 3:
                        _logger.LogError(ex, "Ocurrio un error al intentar devolver el libro.");
                        break;
                }

            }

            return result;
          
        }
    }
}
