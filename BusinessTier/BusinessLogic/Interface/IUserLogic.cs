using Shared.DTO_s;

namespace Logic.Interface;

public interface IUserLogic
{
    public Task<ICollection<GetUserDto>> GetUsersAsync();
}