using Shared.Domain;
using Shared.DTO_s;

namespace Application.LogicInterface;

public interface IBookLogic
{
    Task<Book> CreateAsync(BookCreationDto book);

    Task<IEnumerable<Book>> GetAllAsync();

    Task<Book> GetByNameAsync(string bookName);

    Task<Book> GetByIsbnAsync(int isbn);
}