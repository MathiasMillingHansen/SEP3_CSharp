using Shared.Domain;
using Shared.DTOs;

namespace BusinessWebAPI.Application.DaoInterface;

public interface IBookDao
{
    public Task<Book> CreateAsync(Book book);
    
    Task<ICollection<BooksAvailableDto>> GetAllAsync();

    Task<BookWrapperDto> GetByIsbnAsync(string isbn);

    Task<Book> GetByBookTitleAsync(string bookTitle);
    Task<ICollection<Condition>> GetConditionsAsync();
}