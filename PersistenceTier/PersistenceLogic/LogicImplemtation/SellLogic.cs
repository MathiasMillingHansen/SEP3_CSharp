using System.Collections;
using EFC_DataAccess.DAOs;
using Logic.LogicInterface;
using Shared.Domain;
using Shared.DTOs;

namespace Logic.LogicImplemtation;

public class SellLogic : ISellLogic
{
    IEfcBookDao _bookDao;
    private IEfcBookForSaleDao _bookForSaleDao;

    public SellLogic(IEfcBookDao bookDao, IEfcBookForSaleDao bookForSaleDao)
    {
        this._bookDao = bookDao;
        this._bookForSaleDao = bookForSaleDao;
    }

    public async Task<ICollection<BooksAvailableDto>> GetAllAsync()
    {
        ICollection<BooksAvailableDto> books = new List<BooksAvailableDto>();
        foreach (Book book in await _bookDao.GetAllAsync())
        {
            books.Add(new BooksAvailableDto(book));
        }

        return books;
    }

    public async Task<ICollection<Condition>> GetConditionsAsync()
    {
        return await _bookDao.GetConditionsAsync();
    }

    public async Task<BookDto> GetByIsbnAsync(string isbn)
    {
        return await _bookDao.GetByIsbnAsync(isbn);
    }

    public async Task<BookForSale> SellBookAsync(BookForSale bookForSale)
    {
        
        foreach (var author in bookForSale.Book.Authors)
        {
            _bookDao.AttachAuthor(author);
        }
        
        foreach (var course in bookForSale.Book.courses)
        {
            _bookDao.AttachCourse(course);
        }
        
        _bookDao.AttachBook(bookForSale.Book);
        
        _bookDao.AttachCondition(bookForSale.Condition);
        
        return await _bookForSaleDao.InsertAsync(bookForSale);
    }
}