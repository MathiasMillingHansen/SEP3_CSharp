using Shared.Domain;
using Shared.DTOs;

namespace Logic.Interfaces;

public interface ICatalogLogic
{
    Task<BooksForSaleDto> GetAllBooksForSaleAsync();
    
    IEnumerable<BooksAvailableDto> SearchBooks(Book searchModel);
    Task<ICollection<BookCourseDto>> GetByCourseAsync();
}