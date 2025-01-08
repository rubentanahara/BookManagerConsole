using BookLibrary.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Infrastructure.Data;

public class LibraryDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired();
            entity.Property(e => e.Author).IsRequired();
            entity.Property(e => e.ISBN).IsRequired();
        });
    }
}
