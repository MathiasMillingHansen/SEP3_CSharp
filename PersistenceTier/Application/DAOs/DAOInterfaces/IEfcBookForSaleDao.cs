using Shared.Domain;
using Shared.DTOs;

namespace EFC_DataAccess.DAOs;

public interface IEfcBookForSaleDao
{
    Task<string> InsertAsync(BookForSale bookForSale);

    Task<ICollection<BookForSale>> GetAllBooksForSaleAsync();
    
    Task EditBookForSaleAsync(EditBookForSaleDto dto);
}