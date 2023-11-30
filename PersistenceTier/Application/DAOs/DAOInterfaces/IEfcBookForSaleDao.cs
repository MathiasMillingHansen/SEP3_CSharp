using Shared.Domain;
using Shared.DTOs;

namespace EFC_DataAccess.DAOs;

public interface IEfcBookForSaleDao
{
    Task<BookForSale> InsertAsync(BookForSale bookForSale);

    Task<BooksForSaleDto> GetAllAsync();
}