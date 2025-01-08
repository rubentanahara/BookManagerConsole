namespace BookLibrary.Core.Entities;

public class Book
{
    // Parameterless constructor for EF Core
    protected Book() { }

    public Book(string title, string author, int publicationYear, string isbn)
    {
        Title = title;
        Author = author;
        PublicationYear = publicationYear;
        ISBN = isbn;
    }

    public int Id { get; set; }
    // Changed to public set for EF Core
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int PublicationYear { get; set; }
    public string ISBN { get; set; } = string.Empty;

    public void Update(string title, string author, int publicationYear, string isbn)
    {
        Title = title;
        Author = author;
        PublicationYear = publicationYear;
        ISBN = isbn;
    }
}
