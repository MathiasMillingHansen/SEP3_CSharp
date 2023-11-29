using Shared.Domain;
using Shared.DTOs;

namespace BusinessWebAPI.Application.DaoInterface;

public interface ICatalogDao
{
    Task<BookCategoryDto> GetByCategoryAsync(string category);
    
    Task<ICollection<BooksAvailableDto>> GetAllAsync();
    
    IEnumerable<BooksAvailableDto> SearchBooks(Book searchModel);
    
    
}