using Application.LogicInterface;
using BusinessWebAPI.Application.DaoInterface;
using Shared.Domain;
using Shared.DTO_s;

namespace Application.Logic;

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
    

    public Task<UserInformation> GetByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserInformation>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}