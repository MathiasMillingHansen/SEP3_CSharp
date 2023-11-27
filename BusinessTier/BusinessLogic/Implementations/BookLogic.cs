using System.Collections;
using BusinessWebAPI.Application.DaoInterface;
using Logic.Interface;
using Shared.DTO_s;

namespace Logic.Implementations;

public class BookLogic : IBookLogic
{
    private readonly IBookDao _bookDao;

    public BookLogic(IBookDao bookDao)
    {
        this._bookDao = bookDao;
    }

    public async Task<ICollection<GetUserDto>> PostBookAsync()
    {
        ICollection<GetUserDto> users = await _bookDao.PostBookAsync();
        return users;
    }
}