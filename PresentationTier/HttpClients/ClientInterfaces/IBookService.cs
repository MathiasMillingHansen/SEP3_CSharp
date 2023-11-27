using Shared.Domain;
using Shared.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IBookService
{
    Task<Book> CreateAsync(BookCreationDto bookCreationDto);
}