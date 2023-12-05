using BusinessWebAPI.Application.DaoInterface;
using Logic.Interfaces;
using RabbitMQ;
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
        string owner;
        try
        {
            owner = await BusinessSender.SendMessage(dto.Owner);
        }
        catch (Exception e)
        {
            throw;
        }

        BookForSale bookForSale = new BookForSale()
        {
            Owner = owner,
            Price = dto.Price,
            Comment = dto.Comment!,
            ConditionState = dto.BookCondition.State,
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

    public async Task<BooksForSaleDto> GetBooksByOwnerAsync(string owner)
    {
        return await _sellDao.GetBooksByOwnerAsync(owner);
    }

    public async Task DeleteBookForSaleAsync(int id)
    {
        await _sellDao.DeleteBookForSaleAsync(id);
    }

    private void ValidateBook(Book dto)
    {
        // TODO : Change this to validate a JWT token START -------
        // Change this to validate a JWT token END ----------------
    }

}