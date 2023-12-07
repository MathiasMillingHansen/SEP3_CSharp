using Shared.Domain;

namespace EFC_DataAccess.DAOs;

public interface IEfcBookForSaleDao
{
    Task<string> InsertAsync(BookForSale bookForSale);

    Task<ICollection<BookForSale>> GetAllBooksForSaleAsync();
}