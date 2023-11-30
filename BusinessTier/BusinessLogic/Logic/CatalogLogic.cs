using BusinessWebAPI.Application.DaoInterface;
using EFC_DataAccess.DAOs;
using Logic.Interfaces;
using Shared.Domain;
using Shared.DTOs;

namespace Application.Logic;

public class CatalogLogic : ICatalogLogic
{
    private readonly ICatalogDao _catalogDao;
    public CatalogLogic(ICatalogDao catalogDao)
    {
        _catalogDao = catalogDao;
    }
    
    public Task<ICollection<BookCourseDto>> GetByCourseAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<BooksForSaleDto> GetAllBooksForSaleAsync()
    {
        return await _catalogDao.GetAllBooksForSaleAsync();
    }
    
    public IEnumerable<BooksAvailableDto> SearchBooks(Book searchModel)
    {
        //TODO Implement the logic to search books in the database using the DAO
        return _catalogDao.SearchBooks(searchModel);
    }
}