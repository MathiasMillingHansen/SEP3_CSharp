using Shared.DTO_s;

namespace Logic.LogicInterface;

public interface IUserLogic
{
    public Task<ICollection<GetUserDto>> GetUsersAsync();
}