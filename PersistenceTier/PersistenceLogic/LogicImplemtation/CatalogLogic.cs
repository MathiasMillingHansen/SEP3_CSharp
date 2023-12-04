using EFC_DataAccess.DAOs;
using Logic.Interfaces;
using Shared.Domain;
using Shared.DTOs;

namespace Application.Logic;

public class CatalogLogic : ICatalogLogic
{
    IEfcBookForSaleDao _bookForSaleDao;

    public CatalogLogic(IEfcBookForSaleDao bookDao)
    {
        this._bookForSaleDao = bookDao;
    }
    
    public Task<ICollection<BookCourseDto>> GetByCourseAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<BooksForSaleDto> GetAllBooksForSaleAsync()
    {
        return await _bookForSaleDao.GetAllAsync();
    }
    
    public IEnumerable<BooksAvailableDto> SearchBooks(Book searchModel)
    {
        //TODO Implement the logic to search books in the database using the DAO
        return null;  //_catalogDao.SearchBooks(searchModel);
    }
}