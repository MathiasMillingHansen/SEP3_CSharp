using Shared.Domain;
using Shared.DTO_s;

namespace BusinessWebAPI.Application.DaoInterface;

public interface IUserDao
{
    public Task<UserInformation> CreateAsync(UserCreationDTO dto);

    public Task<UserInformation> GetByUsernameAsync(string username);

    Task<IEnumerable<UserInformation>> GetAllAsync();
}