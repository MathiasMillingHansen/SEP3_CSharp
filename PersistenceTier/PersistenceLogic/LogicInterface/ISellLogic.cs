using Shared.Domain;
using Shared.DTOs;

namespace Logic.LogicInterface;

public interface ISellLogic
{
    Task<ICollection<BooksAvailableDto>> GetAllAsync();
    Task<ICollection<Condition>> GetConditionsAsync();
    Task<BookWrapperDto> GetByIsbnAsync(string isbn);
}