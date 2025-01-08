using BookLibrary.Application.DTOs;

namespace BookLibrary.Application.Interfaces;

public interface IBookService
{
    Task<BookDto?> GetBookByIdAsync(int id);
    Task<List<BookDto>> GetAllBooksAsync();
    Task<List<BookDto>> SearchBooksByAuthorAsync(string author);
    Task<BookDto> AddBookAsync(BookDto bookDto);
    Task UpdateBookAsync(BookDto bookDto);
    Task DeleteBookAsync(int id);
}
