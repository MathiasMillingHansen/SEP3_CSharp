using Application.DaoInterface;
using Logic.LogicInterface;
using Shared.DTO_s;

namespace Logic.LogicImplemtation;

public class UserLogic : IUserLogic
{
    
    IUserDAO userDao;
    
    public UserLogic(IUserDAO userDao)
    {
        this.userDao = userDao;
    }
    
    public async Task<ICollection<GetUserDto>> GetUsersAsync()
    {
        ICollection<GetUserDto> users = await userDao.GetUsersAsync();
        return users;
    }
}