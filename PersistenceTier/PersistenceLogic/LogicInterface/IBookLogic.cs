using Shared.Domain;

namespace Logic.LogicInterface;

public interface IBookLogic
{
    public Task<Book> CreateAsync(Book book);
}