using Shared.Domain;
using Shared.DTOs;

namespace Logic.Interfaces;

public interface ICatalogLogic
{
    Task<BookCourseDto> GetByCourseAsync(string course);
    
    Task<ICollection<BooksAvailableDto>> GetAllAsync();
    
    IEnumerable<BooksAvailableDto> SearchBooks(Book searchModel);
}