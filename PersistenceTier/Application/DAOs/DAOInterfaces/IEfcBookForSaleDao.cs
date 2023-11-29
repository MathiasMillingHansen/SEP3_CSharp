using Shared.Domain;

namespace EFC_DataAccess.DAOs;

public interface IEfcBookForSaleDao
{
    Task<BookForSale> InsertAsync(BookForSale bookForSale);
}