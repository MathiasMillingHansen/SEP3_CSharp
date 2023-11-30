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
        BookDto bookDto = await _sellDao.GetByIsbnAsync(dto.Isbn);
        //TODO IMPLEMENT LOGIC

        Console.WriteLine("BookDtos booktitle is: " + bookDto.Title);

        BookForSale bookForSale = new BookForSale()
        {
            Owner = dto.Owner,
            Price = dto.Price,
            Comment = dto.Comment!,
            Condition = dto.BookCondition,
            Book = new Book()
            {
                Isbn = bookDto.Isbn,
                BookTitle = bookDto.Title,
                Authors = bookDto.Authors,
                Edition = dto.Edition,
                courses = bookDto.Courses
            }
        };

        await _sellDao.SellBookAsync(bookForSale);
        return bookForSale;
        
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