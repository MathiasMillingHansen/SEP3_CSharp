using EFC_DataAccess.DAOs;
using Logic.LogicInterface;
using Shared.Domain;

namespace Logic.LogicImplemtation;

public class BookLogic : IBookLogic
{
    
    IEfcBookDao _bookDao;
    
    public BookLogic(IEfcBookDao bookDao)
    {
        this._bookDao = bookDao;
    }
    
    public async Task<Book> CreateAsync(Book book)
    {
        return await _bookDao.InsertAsync(book);        
    }
}