using Shared.Domain;
using Shared.DTOs;

namespace Logic.Interfaces;

public interface IBookLogic
{
    public Task<Book> CreateAsync(BookCreationDto bookCreationDto);
}