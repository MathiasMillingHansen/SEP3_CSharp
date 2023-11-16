using System.Collections;
using BusinessWebAPI.Application.DaoInterface;
using Logic.Interface;
using Shared.DTO_s;

namespace Logic.Implementations;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<ICollection<GetUserDto>> GetUsersAsync()
    {
        ICollection<GetUserDto> users = await userDao.GetUsersAsync();
        return users;
    }
}