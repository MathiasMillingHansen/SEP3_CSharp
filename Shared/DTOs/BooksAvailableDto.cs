using Shared.Domain;

namespace Shared.DTOs;

public class BooksAvailableDto
{
    public string Title { get; set; }
    public string Edition { get; set; }
    public string Isbn { get; set; }

    public BooksAvailableDto()
    {
    }

    public BooksAvailableDto(Book book)
    {
        Title = book.BookTitle;
        Edition = book.Edition;
        Isbn = book.Isbn;
    }
}