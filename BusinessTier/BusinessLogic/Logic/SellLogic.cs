using BusinessWebAPI.Application.DaoInterface;
using Logic.Interfaces;
using Shared.Domain;
using Shared.DTOs;

namespace Application.Logic;

public class SellLogic : ISellLogic
{
    private readonly ISellDao _sellDao;

    public SellLogic(ISellDao sellDao)
    {
        _sellDao = sellDao;
    }
    
    public async Task<BookForSale> SellBookAsync(BookSaleDto dto)
    {
        
        BookForSale bookForSale = new BookForSale()
        {
            Owner = dto.Owner,
            Price = dto.Price,
            Comment = dto.Comment!,
            Condition = dto.BookCondition,
            BookIsbn = dto.Isbn
        };
        
        return await _sellDao.SellBookAsync(bookForSale);
    }

    public async Task<ICollection<BooksAvailableDto>> GetAllAsync()
    {
        return await _sellDao.GetAllAsync();
    }

    // TODO Simones template.
    // private async Task<BookWrapperDto> GetByIsbnAsync(string isbn)
    // {
    //     BookWrapperDto bookWrapperDto = await _sellDao.GetByIsbnAsync(isbn);
    //     return bookWrapperDto;
    // }

    public async Task<ICollection<Condition>> GetConditionsAsync()
    {
        ICollection<Condition> conditions = await _sellDao.GetConditionsAsync();
        return conditions;
    }

    private void ValidateBook(Book dto)
    {
        // TODO : Change this to validate a JWT token START -------
        // Change this to validate a JWT token END ----------------
    }

}