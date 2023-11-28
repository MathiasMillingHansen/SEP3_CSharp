using Shared.Domain;
using Shared.DTOs;

namespace Logic.LogicInterface;

public interface IBookLogic
{
    public Task<Book> CreateAsync(Book book);

    Task<ICollection<BooksAvailableDto>> GetAllAsync();
    Task<ICollection<Condition>> GetConditionsAsync();
    Task<BookWrapperDto> GetByIsbnAsync(string isbn);
}