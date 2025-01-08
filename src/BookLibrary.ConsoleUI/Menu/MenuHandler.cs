using BookLibrary.Application.DTOs;
using BookLibrary.Application.Interfaces;
using BookLibrary.ConsoleUI.Helpers;

namespace BookLibrary.ConsoleUI.Menu;

public class MenuHandler
{
    private readonly IBookService _bookService;

    public MenuHandler(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task RunAsync()
    {
        while (true)
        {
            try
            {
                ConsoleHelper.WriteHeader("Book Library Management System");
                Console.WriteLine("1. View All Books");
                Console.WriteLine("2. Search Books by Author");
                Console.WriteLine("3. Add New Book");
                Console.WriteLine("4. Update Book");
                Console.WriteLine("5. Delete Book");
                Console.WriteLine("6. View Book Details");
                Console.WriteLine("0. Exit");

                var choice = ConsoleHelper.ReadInteger("\nSelect an option", 0, 6);

                await HandleMenuChoice(choice);

                if (choice == 0) break;
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteError($"An error occurred: {ex.Message}");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }

    private async Task HandleMenuChoice(int choice)
    {
        switch (choice)
        {
            case 1:
                await ViewAllBooks();
                break;
            case 2:
                await SearchBooksByAuthor();
                break;
            case 3:
                await AddNewBook();
                break;
            case 4:
                await UpdateBook();
                break;
            case 5:
                await DeleteBook();
                break;
            case 6:
                await ViewBookDetails();
                break;
        }

        if (choice != 0)
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    private async Task ViewAllBooks()
    {
        ConsoleHelper.WriteHeader("All Books");
        var books = await _bookService.GetAllBooksAsync();
        DisplayBooksList(books);
    }

    private async Task SearchBooksByAuthor()
    {
        var author = ConsoleHelper.ReadInput("Enter author name to search");
        ConsoleHelper.WriteHeader($"Books by {author}");
        var books = await _bookService.SearchBooksByAuthorAsync(author);
        DisplayBooksList(books);
    }

    private async Task AddNewBook()
    {
        ConsoleHelper.WriteHeader("Add New Book");

        var bookDto = new BookDto
        {
            Title = ConsoleHelper.ReadInput("Enter title"),
            Author = ConsoleHelper.ReadInput("Enter author"),
            PublicationYear = ConsoleHelper.ReadInteger("Enter publication year", 1000, 9999),
            ISBN = ConsoleHelper.ReadInput("Enter ISBN")
        };

        await _bookService.AddBookAsync(bookDto);
        ConsoleHelper.WriteSuccess("Book added successfully!");
    }

    private async Task UpdateBook()
    {
        ConsoleHelper.WriteHeader("Update Book");
        var id = ConsoleHelper.ReadInteger("Enter book ID to update");

        var existingBook = await _bookService.GetBookByIdAsync(id);
        if (existingBook == null)
        {
            ConsoleHelper.WriteError("Book not found!");
            return;
        }

        Console.WriteLine("\nCurrent book details:");
        DisplayBookDetails(existingBook);
        Console.WriteLine("\nEnter new details (press Enter to keep current value):");

        var title = ConsoleHelper.ReadInput("Title");
        var author = ConsoleHelper.ReadInput("Author");
        var yearStr = ConsoleHelper.ReadInput("Publication Year");
        var isbn = ConsoleHelper.ReadInput("ISBN");

        var bookDto = new BookDto
        {
            Id = id,
            Title = string.IsNullOrWhiteSpace(title) ? existingBook.Title : title,
            Author = string.IsNullOrWhiteSpace(author) ? existingBook.Author : author,
            PublicationYear = string.IsNullOrWhiteSpace(yearStr) ?
                existingBook.PublicationYear :
                int.Parse(yearStr),
            ISBN = string.IsNullOrWhiteSpace(isbn) ? existingBook.ISBN : isbn
        };

        await _bookService.UpdateBookAsync(bookDto);
        ConsoleHelper.WriteSuccess("Book updated successfully!");
    }

    private async Task DeleteBook()
    {
        ConsoleHelper.WriteHeader("Delete Book");
        var id = ConsoleHelper.ReadInteger("Enter book ID to delete");

        var book = await _bookService.GetBookByIdAsync(id);
        if (book == null)
        {
            ConsoleHelper.WriteError("Book not found!");
            return;
        }

        Console.WriteLine("\nBook to delete:");
        DisplayBookDetails(book);

        var confirm = ConsoleHelper.ReadInput("\nAre you sure you want to delete this book? (yes/no)").ToLower();
        if (confirm == "yes" || confirm == "y")
        {
            await _bookService.DeleteBookAsync(id);
            ConsoleHelper.WriteSuccess("Book deleted successfully!");
        }
        else
        {
            ConsoleHelper.WriteWarning("Deletion cancelled.");
        }
    }

    private async Task ViewBookDetails()
    {
        ConsoleHelper.WriteHeader("Book Details");
        var id = ConsoleHelper.ReadInteger("Enter book ID");

        var book = await _bookService.GetBookByIdAsync(id);
        if (book == null)
        {
            ConsoleHelper.WriteError("Book not found!");
            return;
        }

        DisplayBookDetails(book);
    }

    private void DisplayBooksList(List<BookDto> books)
    {
        if (!books.Any())
        {
            ConsoleHelper.WriteWarning("No books found.");
            return;
        }

        Console.WriteLine("\nID".PadRight(5) + "Title".PadRight(40) + "Author".PadRight(30) + "Year");
        Console.WriteLine(new string('-', 80));

        foreach (var book in books)
        {
            Console.WriteLine(
                $"{book.Id.ToString().PadRight(5)}" +
                $"{book.Title.PadRight(40)}" +
                $"{book.Author.PadRight(30)}" +
                $"{book.PublicationYear}");
        }

        Console.WriteLine($"\nTotal books: {books.Count}");
    }

    private void DisplayBookDetails(BookDto book)
    {
        Console.WriteLine($"\nID: {book.Id}");
        Console.WriteLine($"Title: {book.Title}");
        Console.WriteLine($"Author: {book.Author}");
        Console.WriteLine($"Publication Year: {book.PublicationYear}");
        Console.WriteLine($"ISBN: {book.ISBN}");
    }
}
