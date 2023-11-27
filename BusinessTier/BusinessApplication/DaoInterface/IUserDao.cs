using Shared.Domain;
using Shared.DTO_s;

namespace BusinessWebAPI.Application.DaoInterface;

public interface IUserDao
{
    public Task<ICollection<GetUserDto>> GetUsersAsync();
    
    Task<UserInformation> CreateAsync(UserInformation userInformation);
    Task<UserInformation?> GetByUsernameAsync(string username);
    Task<IEnumerable<UserInformation>> GetAllAsync();
}