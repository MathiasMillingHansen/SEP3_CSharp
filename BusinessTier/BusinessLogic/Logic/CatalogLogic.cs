using BusinessWebAPI.Application.DaoInterface;
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
    
    public Task<BookCourseDto> GetByCourseAsync(string course)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<BooksAvailableDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
    
    public IEnumerable<BooksAvailableDto> SearchBooks(Book searchModel)
    {
        //TODO Implement the logic to search books in the database using the DAO
        return _catalogDao.SearchBooks(searchModel);
    }
}