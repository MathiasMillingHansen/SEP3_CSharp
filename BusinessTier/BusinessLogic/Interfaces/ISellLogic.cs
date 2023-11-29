using Shared.Domain;
using Shared.DTOs;

namespace Logic.Interfaces;

public interface ISellLogic
{
    public Task<Book> SellBookAsync(BookSaleDto bookSaleDto);
    Task<ICollection<BooksAvailableDto>> GetAllAsync();
    Task<ICollection<Condition>> GetConditionsAsync();
}