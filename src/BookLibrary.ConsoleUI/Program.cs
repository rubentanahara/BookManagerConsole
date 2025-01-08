using BookLibrary.Application.Interfaces;
using BookLibrary.ConsoleUI;  // Add this line
using BookLibrary.ConsoleUI.Menu;
using BookLibrary.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddBookLibrary("Data Source=library.db");

var serviceProvider = services.BuildServiceProvider();

try
{
    // Initialize database
    using (var scope = serviceProvider.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
        await context.Database.EnsureCreatedAsync();
    }

    // Run the menu
    var menuHandler = new MenuHandler(serviceProvider.GetRequiredService<IBookService>());
    await menuHandler.RunAsync();
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Fatal error: {ex.Message}");
    Console.ResetColor();
    return 1;
}

return 0;
