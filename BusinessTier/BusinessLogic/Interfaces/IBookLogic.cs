using Shared.Domain;
using Shared.DTOs;

namespace Logic.Interfaces;

public interface IBookLogic
{
    public Task<Book> CreateAsync(BookSaleDto bookSaleDto);
    
    Task<IEnumerable<Book>> GetAllAsync();

    Task<Book> GetByIsbnAsync(int isbn);

    Task<Book> GetByBookTitleAsync(string bookTitle);
}