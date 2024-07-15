using Microsoft.Extensions.Logging;
using System;
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
            Book? result = new Book();
            try
            {

                if (string.IsNullOrEmpty(book.Title) && string.IsNullOrEmpty(book.Author))
                {
                    throw new Exception("El titulo y autor del libro son obligatorios");
                }
                else
                {
                    var existe = await GetBookByTitle(book.Title);
                    if (existe != null)
                    {
                        result = null;
                        throw new Exception("El libro ya existe");
                    }
                }

                result = await _bookRepository.CreateBook(book);
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
            var books = await _bookRepository.GetAllBooks();

            return books;
        }

        public async Task<Book?> GetBookById(int id)
        {
            Book? book = new Book();
            try
            {
                return await _bookRepository.GetBookById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrio un error al intentar obtener el libro");
            }

            return book;

        }
        public async Task<Book?> GetBookByTitle(string title)
        {
            Book? book = new Book();
            try
            {
                return await _bookRepository.GetBookByTitle(title);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrio un error al intentar obtener el libro");
            }

            return book;
        }

        public async Task<bool> UpdateBook(int id, Book book)
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
                    var existe = _bookRepository.GetBookById(book.Id);
                    if (existe == null)
                    {
                        result = false;
                        throw new Exception("El libro no existe");
                    }

                    result = await _bookRepository.UpdateBook(book);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrio un error al intentar actualizar el libro.");
            }

            return result;

        }

        public async Task<bool> LendBook(int id, Book book)
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
                    var existe = await _bookRepository.GetBookById(book.Id);

                    if (existe == null)
                    {
                        result = false;
                        throw new Exception("El libro no existe");
                    }
                    else if(existe.Available == 0)
                    {
                        result = false;
                        throw new Exception("No hay libros disponibles");
                    }

                    result = await _bookRepository.UpdateBook(book);
                }

            }
            catch (Exception ex)
            {
                 _logger.LogError(ex, "Ocurrio un error al intentar actualizar el libro.");
            }

            return result;
        }

        public async Task<bool> ReturnBook(int id, Book book)
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
                    var existe = await _bookRepository.GetBookById(book.Id);

                    if (existe == null)
                    {
                        result = false;
                        throw new Exception("El libro no existe");
                    }
                    else if (existe.LendBooks == 0)
                    {
                        result = false;
                        throw new Exception("No hay libros prestados");
                    }

                    result = await _bookRepository.UpdateBook(book);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrio un error al intentar actualizar el libro.");
            }

            return result;
        }
    }
}
