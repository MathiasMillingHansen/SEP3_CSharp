using EFC_DataAccess.DAOs;
using Logic.LogicInterface;
using Shared.Domain;
using Shared.DTOs;

namespace Logic.LogicImplemtation;

public class SellLogic : ISellLogic
{
    
    IEfcBookDao _bookDao;
    
    public SellLogic(IEfcBookDao bookDao)
    {
        this._bookDao = bookDao;
    }

    public async Task<ICollection<BooksAvailableDto>> GetAllAsync()
    {
        return await _bookDao.GetAllAsync();
    }

    public async Task<ICollection<Condition>> GetConditionsAsync()
    {
        return await _bookDao.GetConditionsAsync();
    }

    public async Task<BookWrapperDto> GetByIsbnAsync(string isbn)
    {
        return await _bookDao.GetByIsbnAsync(isbn);
    }
}