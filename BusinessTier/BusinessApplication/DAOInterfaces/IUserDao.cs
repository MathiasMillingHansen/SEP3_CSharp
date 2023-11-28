using Shared.Domain;
using Shared.DTOs;

namespace Application.DAOInterfaces;

public interface IUserDao
{
    public Task<UserInformation> CreateAsync(UserCreationDTO dto);

    public Task<UserInformation> GetByUsernameAsync(string username);

    Task<IEnumerable<UserInformation>> GetAllAsync();
}