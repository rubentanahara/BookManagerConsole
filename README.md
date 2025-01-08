# Book Library Management System

A clean architecture-based console application for managing a book library using C#, SQLite, and Entity Framework Core.

## 📋 Features

- Full-screen console interface
- CRUD operations for books
- Search functionality
- SQLite database storage
- Clean Architecture implementation
- Dependency Injection
- Async operations

## 🏗️ Architecture

The project follows Clean Architecture principles with these layers:

```
BookLibrary/
├── src/
│   ├── BookLibrary.Core/                 # Core Domain Layer
│   │   ├── Entities/
│   │   ├── Interfaces/
│   │   └── Exceptions/
│   ├── BookLibrary.Application/          # Application Layer
│   │   ├── Interfaces/
│   │   ├── Services/
│   │   ├── DTOs/
│   │   └── Exceptions/
│   ├── BookLibrary.Infrastructure/       # Infrastructure Layer
│   │   ├── Data/
│   │   ├── Repositories/
│   │   └── Persistence/
│   └── BookLibrary.ConsoleUI/           # Presentation Layer
└── tests/                               # Test Projects
    ├── BookLibrary.Core.Tests/
    ├── BookLibrary.Application.Tests/
    └── BookLibrary.Infrastructure.Tests/
```

## 🚀 Getting Started

### Prerequisites

- .NET 6.0 SDK or later
- SQLite

### Installation

1. Clone the repository

```bash
git clone https://github.com/yourusername/BookLibrary.git
cd BookLibrary
```

2. Build the solution

```bash
dotnet build
```

3. Run the application

```bash
dotnet run --project src/BookLibrary.ConsoleUI
```

### Database Setup

The application will automatically create the SQLite database on first run. The default connection string is:

```
Data Source=library.db
```

To access the database directly using SQLite CLI:

```bash
sqlite3 library.db
```

Common SQLite commands:

```sql
-- Show all tables
.tables

-- Show table schema
.schema Books
```

## 🎯 Usage

The application provides these main functions:

1. View All Books
2. Search Books by Author
3. Add New Book
4. Update Book
5. Delete Book
6. View Book Details

## 🧪 Running Tests

Execute tests using:

```bash
dotnet test
```

## 🏗️ Project Structure Details

### Core Layer

- Contains enterprise logic and interfaces
- Entities (Book)
- Repository interfaces

### Application Layer

- Contains business logic
- DTOs
- Service interfaces and implementations

### Infrastructure Layer

- Contains database configuration
- Repository implementations
- Database context

### Presentation Layer

- Console UI implementation
- Dependency injection configuration
- User interaction logic

## 🛠️ Technical Details

### Dependencies

- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.EntityFrameworkCore.Design
- Microsoft.Extensions.DependencyInjection

## 📜 License

This project is licensed under the MIT License - see the LICENSE file for details.

## ✨ Future Enhancements

1. Add logging using ILogger interface
2. Implement validation using FluentValidation
3. Add error handling middleware
4. Implement caching layer
5. Add authentication and authorization
6. Implement CQRS pattern
7. Add event sourcing

## 📞 Support

For database operations or issues:

1. Check the database connection string
2. Verify SQLite installation
3. Use SQLite CLI for direct database access
4. Check application logs

## 🔍 Troubleshooting

Common issues and solutions:

1. Database Connection Issues:

   - Verify the connection string
   - Check file permissions
   - Ensure SQLite is installed

2. Build Errors:
   - Restore NuGet packages
   - Clean and rebuild solution
   - Check .NET SDK version

## 📚 Additional Resources

- [Entity Framework Core Documentation](https://docs.microsoft.com/en-us/ef/core/)
- [Clean Architecture Guide](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [SQLite Documentation](https://sqlite.org/docs.html)
