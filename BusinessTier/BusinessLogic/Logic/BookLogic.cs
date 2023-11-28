using BusinessWebAPI.Application.DaoInterface;
using Logic.Interfaces;
using Shared.Domain;
using Shared.DTOs;

namespace Application.Logic;

public class BookLogic : IBookLogic
{
    private readonly IBookDao _bookDao;

    public BookLogic(IBookDao bookDao)
    {
        _bookDao = bookDao;
    }
    
    public async Task<Book> SellBookAsync(BookSaleDto dto)
    {
        BookWrapperDto bookWrapperDto = await _bookDao.GetByIsbnAsync(dto.Isbn);
        //TODO IMPLEMENT LOGIC
        BookForSale bookForSale = new BookForSale()
        {
            Owner = dto.Owner,
            Price = dto.Price,
            Comment = dto.Comment,
            Condition = dto.BookCondition,
            Book = new Book()
            {
                
            }
            
        };
        throw new NotImplementedException();
    }

    public async Task<ICollection<BooksAvailableDto>> GetAllAsync()
    {
        ICollection<BooksAvailableDto> books = await _bookDao.GetAllAsync();
        return books;
    }

    public async Task<BookWrapperDto> GetByIsbnAsync(string isbn)
    {
        BookWrapperDto bookWrapperDto = await _bookDao.GetByIsbnAsync(isbn);
        return bookWrapperDto;
    }

    public async Task<Book> GetByBookTitleAsync(string bookTitle)
    {
        Book book = await _bookDao.GetByBookTitleAsync(bookTitle);
        return book;
    }

    public async Task<ICollection<Condition>> GetConditionsAsync()
    {
        ICollection<Condition> conditions = await _bookDao.GetConditionsAsync();
        return conditions;
    }

    private void ValidateBook(Book dto)
    {
        // TODO : Change this to validate a JWT token START -------

        // Change this to validate a JWT token END ----------------

    }

}