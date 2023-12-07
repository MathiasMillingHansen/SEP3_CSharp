using Shared.DTOs;

namespace BusinessWebAPI.Application.DaoInterface;

public interface IUserDao
{
    public Task<UserInformationDto> GetUserinformationAsync(UserInformationDto userInformationDto);
}