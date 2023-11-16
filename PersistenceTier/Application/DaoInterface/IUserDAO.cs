using Shared.DTO_s;

namespace Application.DaoInterface;

public interface IUserDAO
{
    public Task<ICollection<GetUserDto>> GetUsersAsync();
}