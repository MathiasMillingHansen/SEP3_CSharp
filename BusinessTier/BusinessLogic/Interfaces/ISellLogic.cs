using Shared.Domain;
using Shared.DTOs;

namespace Logic.Interfaces;

public interface ISellLogic
{
    public Task<string> SellBookAsync(BookSaleDto bookSaleDto);
    Task<ICollection<BooksAvailableDto>> GetAllAsync();
    Task<ICollection<Condition>> GetConditionsAsync();
    Task<BooksForSaleDto> GetBooksByOwnerAsync(string owner);
    Task DeleteBookForSaleAsync(int bookForSale);
    Task EditBookForSaleAsync(EditBookForSaleDto dto);
    Task<UserInfoDto> GetUserInfoAsync(string username);
}