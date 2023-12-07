using BusinessWebAPI.Application.DaoInterface;
using Logic.Interfaces;
using Shared.DTOs;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao _userDao;

    public UserLogic(IUserDao userDao)
    {
        _userDao = userDao;
    }
    
    public Task<UserInformationDto> GetUserInformationAsync(UserInformationDto userInformationDto)
    {
            return _userDao.GetUserinformationAsync(userInformationDto);
    }
    
}