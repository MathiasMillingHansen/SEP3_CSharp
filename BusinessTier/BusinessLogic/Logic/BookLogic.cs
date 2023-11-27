using Application.LogicInterface;
using BusinessWebAPI.Application.DaoInterface;
using Shared.Domain;
using Shared.DTO_s;

namespace Application.Logic;

public class BookLogic : IBookLogic
{
    private readonly IBookDao _bookDao;
    private readonly IUserDao _userDao;

    public BookLogic(IBookDao bookDao, IUserDao userDao)
    {
        _bookDao = bookDao;
        _userDao = userDao;
    }
    
    public async Task<Book> CreateAsync(BookCreationDto dto)
    {
        UserInformation? user = await _userDao.GetByUsernameAsync(dto.Owner);
        if (user == null)
        {
            throw new Exception($"User with username {dto.Owner} not found");
        }

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
        if ((string.IsNullOrEmpty(dto.BookTitle))||(string.IsNullOrEmpty(dto.Author))) throw new Exception("Title and author must contain characters.");
        // other validation stuff
    }
}