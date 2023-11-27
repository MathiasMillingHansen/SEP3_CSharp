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
        Book book = new Book(dto.Isbn, dto.BookTitle, dto.Author, dto.Edition, dto.PageCount, dto.Owner, dto.Condition, dto.Comment, 
            dto.Category);
        ValidateBook(book);
        Book created = await _bookDao.CreateAsync(book);
        return created;
    }

    public Task<IEnumerable<Book>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetByNameAsync(string bookName)
    {
        throw new NotImplementedException();
    }
    

    public Task<Book> GetByIsbnAsync(int isbn)
    {
        throw new NotImplementedException();
    }
    
    private void ValidateBook(Book dto)
    {
        if (string.IsNullOrEmpty(dto.BookTitle) || string.IsNullOrWhiteSpace(dto.BookTitle))
        {
            throw new ArgumentException("Book title cannot be null, empty or whitespace");
        }
        if (string.IsNullOrEmpty(dto.Author) || string.IsNullOrWhiteSpace(dto.Author))
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