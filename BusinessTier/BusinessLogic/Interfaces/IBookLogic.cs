
using Shared.Domain;
using Shared.DTO_s;

namespace Logic.Interface;

public interface IBookLogic
{
    public Task<Book> CreateAsync(Book bookCreationDto);
}