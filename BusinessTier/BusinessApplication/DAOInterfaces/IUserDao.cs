using Shared.Domain;
using Shared.DTOs;

namespace Application.DAOInterfaces;

public interface IUserDao
{
    public Task<UserBooksDto> CreateAsync(UserCreationDTO dto);

    public Task<UserBooksDto> GetByUsernameAsync(string username);

    Task<IEnumerable<UserBooksDto>> GetAllAsync();
}