using Logic.LogicInterface;
using Shared.DTO_s;

namespace Logic.LogicImplemtation;

public class UserLogic : IUserLogic
{
    
    
    public UserLogic( )
    {
    }
    
    public async Task<ICollection<GetUserDto>> GetUsersAsync()
    {
        throw new NotImplementedException();
    }
}