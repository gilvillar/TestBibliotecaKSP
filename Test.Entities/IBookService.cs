using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Entities
{
    public interface IBookService
    {
        Task<Book?> CreateBook(Book book);
        Task<bool> DeleteBook(int id);
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookByTitle(string title);
        Task<Book?> GetBookById(int id);
        Task<bool> UpdateBook(int id, Book book);

        Task<bool> LendBook(int id, Book book);
        Task<bool> ReturnBook(int id, Book book);
    }
}
