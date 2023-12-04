using Shared.Domain;

namespace Shared.DTOs;

public class BooksForSaleDto
{
    
    public ICollection<BookForSale> BooksForSale { get; set; }

    public BooksForSaleDto(ICollection<BookForSale> booksForSale)
    {
        BooksForSale = booksForSale;
    }
}