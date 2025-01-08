using BookLibrary.Application.DTOs;
using BookLibrary.Application.Interfaces;
using BookLibrary.Core.Entities;
using BookLibrary.Core.Interfaces;

namespace BookLibrary.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<BookDto> AddBookAsync(BookDto bookDto)
    {
        var book = new Book(
            bookDto.Title,
            bookDto.Author,
            bookDto.PublicationYear,
            bookDto.ISBN
        );

        var result = await _bookRepository.AddAsync(book);
        return MapToDto(result);
    }

    public async Task<List<BookDto>> GetAllBooksAsync()
    {
        var books = await _bookRepository.GetAllAsync();
        return books.Select(MapToDto).ToList();
    }

    public async Task<BookDto?> GetBookByIdAsync(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        return book != null ? MapToDto(book) : null;
    }

    public async Task<List<BookDto>> SearchBooksByAuthorAsync(string author)
    {
        var books = await _bookRepository.FindByAuthorAsync(author);
        return books.Select(MapToDto).ToList();
    }

    public async Task UpdateBookAsync(BookDto bookDto)
    {
        var existingBook = await _bookRepository.GetByIdAsync(bookDto.Id);
        if (existingBook != null)
        {
            existingBook.Update(
                bookDto.Title,
                bookDto.Author,
                bookDto.PublicationYear,
                bookDto.ISBN
            );
            await _bookRepository.UpdateAsync(existingBook);
        }
    }

    public async Task DeleteBookAsync(int id)
    {
        
    }

    private static BookDto MapToDto(Book book)
    {
        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            PublicationYear = book.PublicationYear,
            ISBN = book.ISBN
        };
    }
}
