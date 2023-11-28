using Shared.Domain;

namespace EFC_DataAccess.DAOs;

public interface IEfcAuthorDao
{
    Task<Author> InsertAsync(Author author);
}