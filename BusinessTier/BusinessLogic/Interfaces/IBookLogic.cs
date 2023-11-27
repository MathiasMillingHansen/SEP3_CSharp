using Shared.Domain;
using Shared.DTO_s;

namespace Logic.Interfaces;

public interface IBookLogic
{
    public Task<Book> CreateAsync(BookCreationDto bookCreationDto);
}