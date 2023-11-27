using Application.DaoInterface;
using Shared.DTO_s;

namespace Application.DaoImplementation;

public class UserDao : IUserDAO
{


    public UserDao( )
    {
        throw new NotImplementedException();
    }
    
    public Task<ICollection<GetUserDto>> GetUsersAsync()
    {
        throw new NotImplementedException();
    }
}