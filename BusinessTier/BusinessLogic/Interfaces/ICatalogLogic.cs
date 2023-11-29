using Shared.Domain;
using Shared.DTOs;

namespace Logic.Interfaces;

public interface ICatalogLogic
{
    Task<BookCategoryDto> GetByCategoryAsync(string category);
    
    Task<ICollection<BooksAvailableDto>> GetAllAsync();
    
    IEnumerable<BooksAvailableDto> SearchBooks(Book searchModel);
}