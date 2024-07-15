
namespace Test.Entities
{
    public interface IBookRepository
    {
        Task<Book> CreateBook(Book book);
        Task<Book?> GetBookByTitle(string title);
        Task<Book?> GetBookById(int id);
        Task<bool> DeleteBook(int id);
        Task<List<Book>> GetAllBooks();
        Task<bool> UpdateBook(Book book);
    }
}
