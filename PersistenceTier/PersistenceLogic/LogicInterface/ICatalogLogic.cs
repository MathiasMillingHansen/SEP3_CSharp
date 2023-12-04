using Shared.Domain;
using Shared.DTOs;

namespace Logic.Interfaces;

public interface ICatalogLogic
{
    Task<BooksForSaleDto> GetAllBooksForSaleAsync();
    
    Task<ICollection<BookCourseDto>> GetByCourseAsync();
}