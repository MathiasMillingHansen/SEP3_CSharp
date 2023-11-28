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
    
    public async Task<Book> CreateAsync(BookCreationDto dto)
    {
        Book book = new Book(dto.Isbn, dto.BookTitle, dto.Authors, dto.Edition, dto.PageCount, dto.Owner, dto.Condition, dto.Comment, 
            dto.Category, dto.Price);
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
        if (string.IsNullOrEmpty(dto.BookTitle) || string.IsNullOrWhiteSpace(dto.BookTitle))
        {
            throw new ArgumentException("Book title cannot be null, empty or whitespace");
        }
        if (string.IsNullOrEmpty(dto.Authors.ToString()) || string.IsNullOrWhiteSpace(dto.Authors.ToString()))
        {
            throw new ArgumentException("Author cannot be null, empty or whitespace");
        }
        if (string.IsNullOrEmpty(dto.Edition) || string.IsNullOrWhiteSpace(dto.Edition))
        {
            throw new ArgumentException("Edition cannot be null, empty or whitespace");
        }
        if (string.IsNullOrEmpty(dto.Isbn.ToString()) || string.IsNullOrWhiteSpace(dto.Isbn.ToString()))
        {
            throw new ArgumentException("ISBN cannot be null, empty or whitespace");
        }
        // TODO : Change this to validate a JWT token START -------
        if (string.IsNullOrEmpty(dto.Owner) || string.IsNullOrWhiteSpace(dto.Owner))
        {
            throw new ArgumentException("Owner cannot be null, empty or whitespace");
        }
        // Change this to validate a JWT token END ----------------

    }

}