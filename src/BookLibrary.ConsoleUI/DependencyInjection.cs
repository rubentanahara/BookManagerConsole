using BookLibrary.Application.Interfaces;
using BookLibrary.Application.Services;
using BookLibrary.Core.Interfaces;
using BookLibrary.Infrastructure.Data;
using BookLibrary.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookLibrary.ConsoleUI;

public static class DependencyInjection
{
    public static IServiceCollection AddBookLibrary(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<LibraryDbContext>(options =>
            options.UseSqlite(connectionString));

        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBookService, BookService>();

        return services;
    }
}
