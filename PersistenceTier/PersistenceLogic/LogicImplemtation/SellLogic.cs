using System.Collections;
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

    public async Task<BookWrapperDto> GetByIsbnAsync(string isbn)
    {
        return await _bookDao.GetByIsbnAsync(isbn);
    }
}