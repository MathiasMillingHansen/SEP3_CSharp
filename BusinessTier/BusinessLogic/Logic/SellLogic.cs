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
    
    public async Task<string> SellBookAsync(BookSaleDto dto)
    {
        BookForSale bookForSale = new BookForSale()
        {
            Owner = dto.Owner,
            Price = dto.Price,
            Comment = dto.Comment!,
            ConditionState = dto.BookCondition.State,
            BookIsbn = dto.Isbn
        };

        await ValidateBook(bookForSale);
        
        return await _sellDao.SellBookAsync(bookForSale);
    }

    public async Task<ICollection<BooksAvailableDto>> GetAllAsync()
    {
        return await _sellDao.GetAllAsync();
    }

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

    public async Task<UserInfoDto> GetUserInfoAsync(string username)
    {
        UserInfoDto userInfoDto = await BusinessSender.GetUserInfoAsync(username);
        return userInfoDto;
    }

    public async Task EditBookForSaleAsync(EditBookForSaleDto dto)
    {
        ValidateBook(dto);
        await _sellDao.EditBookForSaleAsync(dto);
    }

    private async Task ValidateBook(BookForSale dto)
    {
        if (dto.Price < 0)
        {
            throw new Exception("Price cannot be negative");
        }

        if (dto.Comment.Length > 500)
        {
            throw new Exception("Comment cannot be longer than 500 characters");
        }
        
        await BusinessSender.SendMessage(dto.Owner);
    }
    
    private async Task ValidateBook(EditBookForSaleDto dto)
    {
        if (dto.Price < 0)
        {
            throw new Exception("Price cannot be negative");
        }

        if (dto.Comment.Length > 500)
        {
            throw new Exception("Comment cannot be longer than 500 characters");
        }
    }

}