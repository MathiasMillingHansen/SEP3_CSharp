using BusinessWebAPI.Application.DaoInterface;
using Logic.Interfaces;
using Shared.Domain;
using Shared.DTO_s;

namespace Application.Logic;

public class BookLogic : IBookLogic
{
    private readonly IBookDao _bookDao;

    public BookLogic(IBookDao bookDao)
    {
        _bookDao = bookDao;
    }
    
    public async Task<Book> CreateAsync(BookCreationDto dto)
    {
        Book book = new Book(dto.Isbn, dto.BookTitle, dto.Author, dto.Edition, dto.PageCount, dto.Owner, dto.Condition, dto.Comment, 
            dto.Category);
        ValidateBook(book);
        Book created = await _bookDao.CreateAsync(book);
        return created;
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        IEnumerable<Book> books = await _bookDao.GetAllAsync();
        return books;
    }
    

    public async Task<Book> GetByIsbnAsync(int isbn)
    {
        Book book = await _bookDao.GetByIsbnAsync(isbn);
        return book;
    }

    public async Task<Book> GetByBookTitleAsync(string bookTitle)
    {
        Book book = await _bookDao.GetByBookTitleAsync(bookTitle);
        return book;
    }

    private void ValidateBook(Book dto)
    {
        if ((string.IsNullOrEmpty(dto.BookTitle))||(string.IsNullOrEmpty(dto.Author))) throw new Exception("Title and author must contain characters.");
        // other validation stuff
    }

}