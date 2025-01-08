using BookLibrary.Core.Entities;

namespace BookLibrary.Core.Interfaces;

public interface IBookRepository
{
    Task<Book> GetByIdAsync(int id);
    Task<List<Book>> GetAllAsync();
    Task<List<Book>> FindByAuthorAsync(string author);
    Task<Book> AddAsync(Book book);
    Task UpdateAsync(Book book);
    Task DeleteAsync(int id);
}
