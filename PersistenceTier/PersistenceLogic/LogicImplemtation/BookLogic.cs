using Application.DaoInterface;
using Logic.LogicInterface;
using Shared.Domain;

namespace Logic.LogicImplemtation;

public class BookLogic : IBookLogic
{
    
    IBookDao _bookDao;
    
    public BookLogic(IBookDao bookDao)
    {
        this._bookDao = bookDao;
    }
    
    public async Task<Book> CreateAsync(Book book)
    {
        return await _bookDao.CreateAsync(book);        
    }
}