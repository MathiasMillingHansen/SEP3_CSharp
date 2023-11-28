using Shared.Domain;
using Shared.DTOs;

namespace Logic.Interfaces;

public interface IBookLogic
{
    public Task<Book> SellBookAsync(BookSaleDto bookSaleDto);
    
    Task<ICollection<BooksAvailableDto>> GetAllAsync();

    Task<BookWrapperDto> GetByIsbnAsync(string isbn);

    Task<Book> GetByBookTitleAsync(string bookTitle);
    Task<ICollection<Condition>> GetConditionsAsync();
}