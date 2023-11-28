using Shared.Domain;
using Shared.DTOs;

namespace Logic.Interfaces;

public interface IBookLogic
{
    public Task<Book> CreateAsync(BookCreationDto bookCreationDto);
    
    Task<IEnumerable<Book>> GetAllAsync();

    Task<Book> GetByIsbnAsync(int isbn);

    Task<Book> GetByBookTitleAsync(string bookTitle);
}