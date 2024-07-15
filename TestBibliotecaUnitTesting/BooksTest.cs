using Microsoft.AspNetCore.Http;
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

        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<IBookRepository> _logger;


        public BooksTest()
        {
            // Configurar el ILoggerFactory
            _loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("MyTests", LogLevel.Debug)
                    .AddConsole(); // Puedes añadir otros proveedores de logging aquí (e.g., Debug, EventSource, etc.)
            });

            // Crear un logger para esta clase de pruebas
            _logger = _loggerFactory.CreateLogger<IBookRepository>();

            _bookRepository = new BookRepository();
            _bookService = new BookService(_bookRepository, _logger);
            _controller = new BookController(_bookService);
        }

        //validamos el listado de libros correcto
        [Fact]
        public void GetAll_OK()
        {
            //Arrange

            //Act
            var result = _controller.GetBooks();

            //Assert
            var books = Assert.IsType<ActionResult<List<Book>>>(result.Result);
        }

        //validamos la creación de un libro nuevo
        [Fact]
        public void CreateBook_OK()
        {
            //Arrange

            Book book = new Book();
            book.Title = "Macario";
            book.Author = "No se";
            book.Stock = 5;
            book.LendBooks = 0;
            book.Available = 5;

            //Act
            var okResult = _controller.CreateBook(book).Result as CreatedAtActionResult;

            //Assert

            Assert.NotNull(okResult);
            Assert.Equal(201, okResult.StatusCode);
        }

        //validamos la creación de un libro nuevo cuando falta el titulo y autor
        [Fact]
        public void CreateBook_Fail()
        {
            //Arrange

            Book book = new Book();
            book.Title = "";
            book.Author = "";
            book.Stock = 5;
            book.LendBooks = 0;
            book.Available = 5;

            //Act
            var okResult = _controller.CreateBook(book).Result as BadRequestResult;

            //Assert

            Assert.NotNull(okResult);
            Assert.Equal(400, okResult.StatusCode);
        }

        //validamos la creación de un libro nuevo cuando el titulo ya existe
        [Fact]
        public void CreateBook_ExistTitle_Fail()
        {
            //Arrange

            Book book = new Book();
            book.Title = "Caballo de troya";
            book.Author = "JJ. Benitez";
            book.Stock = 5;
            book.LendBooks = 0;
            book.Available = 5;

            //Act
            var okResult = _controller.CreateBook(book).Result as ConflictResult;

            //Assert

            Assert.NotNull(okResult);
            Assert.Equal(409, okResult.StatusCode);
        }

        //validamos la eliminación de un libro existe
        [Fact]
        public void DeleteBook_Ok()
        {
            //Arrange

            int idBook = 1;

            //Act
            var okResult = _controller.DeleteBook(idBook).Result as NoContentResult;

            //Assert

            Assert.Equal(204, okResult.StatusCode);
        }

        //validamos la eliminación de un libro existe
        [Fact]
        public void DeleteBook_Fail()
        {
            //Arrange

            int idBook = 100;

            //Act
            var okResult = _controller.DeleteBook(idBook).Result as BadRequestResult;

            //Assert

            Assert.Equal(400, okResult.StatusCode);
        }

        //validamos la actualizacion de un libro existente
        [Fact]
        public void UpdateBook_Ok()
        {
            //Arrange
            int idBook = 1;
            Book book = new Book
            {
                Id=1,
                Title="Caballo de troya 2",
                Author = "JJ. Benitez",
                Stock = 5,
                LendBooks = 0,
                Available = 5,
            };

            //Act
           var okResult = _controller.UpdateBook(idBook,book).Result as NoContentResult;

            //Assert

            Assert.Equal(204, okResult.StatusCode);
        }

        //validamos la actualizacion de un libro que no existe
        [Fact]
        public void UpdateBook_Fail()
        {
            //Arrange
            int idBook = 100;
            Book book = new Book
            {
                Id = 100,
                Title = "Caballo de troya 2",
                Author = "JJ. Benitez",
                Stock = 5,
                LendBooks = 0,
                Available = 5,
            };

            //Act
            var okResult = _controller.UpdateBook(idBook, book).Result as BadRequestResult;

            //Assert

            Assert.Equal(400, okResult.StatusCode);
        }

        //validamos la actualizacion de un libro que no existe
        [Fact]
        public void LendBook_Ok()
        {
            //Arrange
            int idBook = 1;
            Book book = new Book
            {
                Id = 1,
                Title = "Caballo de troya 2",
                Author = "JJ. Benitez",
                Stock = 5,
                LendBooks = 0,
                Available = 5,
            };

            //Act
            var okResult = _controller.LendBook(idBook, book).Result as NoContentResult;

            //Assert

            Assert.Equal(204, okResult.StatusCode);
        }

        //validamos la actualizacion de un libro que no existe
        [Fact]
        public void LendBook_Fail()
        {
            //Arrange
            int idBook = 100;
            Book book = new Book
            {
                Id = 100,
                Title = "Caballo de troya 2",
                Author = "JJ. Benitez",
                Stock = 5,
                LendBooks = 0,
                Available = 5,
            };

            //Act
            var okResult = _controller.LendBook(idBook, book).Result as BadRequestResult;

            //Assert

            Assert.Equal(400, okResult.StatusCode);
        }

        //validamos la actualizacion de un libro que no existe
        [Fact]
        public void ReturnBook_Ok()
        {
            //Arrange
            int idBook = 1;
            Book book = new Book
            {
                Id = 1,
                Title = "Caballo de troya 2",
                Author = "JJ. Benitez",
                Stock = 5,
                LendBooks = 0,
                Available = 5,
            };

            //Act
            var okResult = _controller.ReturnBook(idBook, book).Result as NoContentResult;

            //Assert

            Assert.Equal(204, okResult.StatusCode);
        }

        //validamos la actualizacion de un libro que no existe
        [Fact]
        public void ReturnBook_Fail()
        {
            //Arrange
            int idBook = 100;
            Book book = new Book
            {
                Id = 100,
                Title = "Caballo de troya 2",
                Author = "JJ. Benitez",
                Stock = 5,
                LendBooks = 0,
                Available = 5,
            };

            //Act
            var okResult = _controller.LendBook(idBook, book).Result as BadRequestResult;

            //Assert

            Assert.Equal(400, okResult.StatusCode);
        }

    }
}