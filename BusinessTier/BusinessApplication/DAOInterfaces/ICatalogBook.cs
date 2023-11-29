using Shared.Domain;
using Shared.DTOs;

namespace BusinessWebAPI.Application.DaoInterface;

public interface ICatalogBook
{
    Task<BookCategoryDto> GetByCategoryAsync(string category);
    
    Task<IEnumerable<Book>> GetAllAsync();
    
    
}