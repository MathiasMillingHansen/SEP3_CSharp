using Shared.DTO_s;

namespace BusinessWebAPI.Application.DaoInterface;

public interface IUserDao
{
    public Task<ICollection<GetUserDto>> GetUsersAsync();
}