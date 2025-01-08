using BookLibrary.Core.Entities;
using BookLibrary.Core.Interfaces;
using BookLibrary.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryDbContext _context;

    public BookRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<Book> AddAsync(Book book)
    {
        await Task.Delay(20);
        return null;

        // await _context.Books.AddAsync(book);
        // await _context.SaveChangesAsync();
        // return book;
    }

    public async Task DeleteAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            // Save the data
        }
    }

    public async Task<List<Book>> FindByAuthorAsync(string author)
    {
        return await _context.Books
            .Where(b => b.Author.Contains(author))
            .ToListAsync();
    }

    public async Task<List<Book>> GetAllAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book> GetByIdAsync(int id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task UpdateAsync(Book book)
    {
        _context.Entry(book).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
