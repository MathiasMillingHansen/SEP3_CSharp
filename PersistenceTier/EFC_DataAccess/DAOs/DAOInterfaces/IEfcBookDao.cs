using Shared.Domain;

namespace EFC_DataAccess.DAOs;

public interface IEfcBookDao
{
    Task<Book> InsertAsync(Book book);
}