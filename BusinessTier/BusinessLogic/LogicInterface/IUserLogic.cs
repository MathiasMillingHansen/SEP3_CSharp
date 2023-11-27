using Shared.Domain;
using Shared.DTO_s;

namespace Application.LogicInterface;

public interface IUserLogic
{
    public Task<ICollection<GetUserDto>> GetUsersAsync();
    
   // public Task<User> CreateAsync(UserCreationDto dto);
   
    public Task<UserInformation> GetByUsernameAsync(string username);

    Task<IEnumerable<UserInformation>> GetAllAsync();
}