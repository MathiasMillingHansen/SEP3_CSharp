using System.Collections;
using EFC_DataAccess.DAOs;
using Logic.LogicInterface;
using Shared.Domain;
using Shared.DTOs;

namespace Logic.LogicImplemtation;

public class SellLogic : ISellLogic
{
    IEfcBookDao _bookDao;
    IEfcBookForSaleDao _bookForSaleDao;

    public SellLogic(IEfcBookDao bookDao, IEfcBookForSaleDao bookForSaleDao)
    {
        _bookDao = bookDao;
        _bookForSaleDao = bookForSaleDao;
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

    public async Task<BookForSale> SellBookAsync(BookForSale dto)
    {
        return await _bookForSaleDao.InsertAsync(dto);
    }
}