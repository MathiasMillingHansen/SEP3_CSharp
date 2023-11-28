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
    
    public async Task<Book> CreateAsync(BookSaleDto dto)
    {
        //TODO IMPLEMENT LOGIC
        //Book book = new Book(dto.Isbn, dto.BookTitle, ConvertToAuthor(dto.Authors), dto.Edition, dto.PageCount, dto.Owner, dto.Condition, dto.Comment, 
        //    dto.Category, dto.Price); 
        // ValidateBook(book);
        // Book created = await _bookDao.CreateAsync(book);
        // return created;
        throw new NotImplementedException();
    }

    private ICollection<Author> ConvertToAuthor(ICollection<AuthorDto> dtoAuthors)
    {
        ICollection<Author> authors = new List<Author>();
        foreach (var author in dtoAuthors)
        {
            authors.Add(new Author(author.FullName));
        }
        

        return authors;
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
        // TODO : Change this to validate a JWT token START -------

        // Change this to validate a JWT token END ----------------

    }

}