using Shared.Domain;
using Shared.DTO_s;

namespace Logic.LogicInterface;

public interface IBookLogic
{
    public Task<Book> CreateAsync(Book book);
}