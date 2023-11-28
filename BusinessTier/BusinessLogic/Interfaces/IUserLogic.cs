using Shared.Domain;
using Shared.DTOs;

namespace Logic.Interfaces;

public interface IUserLogic
{
    public Task<UserBooksDto> CreateAsync(UserCreationDTO dto);

    public Task<UserBooksDto> GetByUsernameAsync(string username);

    Task<IEnumerable<UserBooksDto>> GetAllAsync();
}
