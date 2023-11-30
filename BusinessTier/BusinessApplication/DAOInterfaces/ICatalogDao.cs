using Shared.Domain;
using Shared.DTOs;

namespace BusinessWebAPI.Application.DaoInterface;

public interface ICatalogDao
{
    Task<BookCourseDto> GetByCourseAsync(string course);
    
    Task<ICollection<BooksAvailableDto>> GetAllAsync();
    
    IEnumerable<BooksAvailableDto> SearchBooks(Book searchModel);
    
    
}