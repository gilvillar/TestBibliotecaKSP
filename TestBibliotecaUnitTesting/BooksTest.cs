using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Test.BLL;
using Test.DAL;
using Test.Entities;
using TestBackend.Controllers;

namespace TestBibliotecaUnitTesting
{

    public class BooksTest
    {
        private readonly BookController _controller;
        private readonly IBookService _bookService;
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<IBookRepository> _logger;


        public BooksTest()
        {
            _bookRepository = new BookRepository();
            _bookService = new BookService(_bookRepository, _logger);
            _controller = new BookController(_bookService);
        }


        [Fact]
        public void GetAll_OK()
        {
            var result = _controller.GetBooks();

            var books = Assert.IsType<ActionResult<List<Book>>>(result.Result);
        }
    }
}