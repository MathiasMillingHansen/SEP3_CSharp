using EFC_DataAccess.DAOs;
using Logic.LogicInterface;
using Shared.Domain;
using Shared.DTOs;

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