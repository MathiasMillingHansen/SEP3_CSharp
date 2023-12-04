using Shared.Domain;
using Shared.DTOs;

namespace BusinessWebAPI.Application.DaoInterface;

public interface ICatalogDao
{
    Task<ICollection<BookCourseDto>> GetByCourseAsync(string course);
    
    Task<BooksForSaleDto> GetAllBooksForSaleAsync();
    
    IEnumerable<BooksAvailableDto> SearchBooks(Book searchModel);
    
    
}