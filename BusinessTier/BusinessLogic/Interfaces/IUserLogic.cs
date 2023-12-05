using Shared.DTOs;

namespace Logic.Interfaces;

public interface IUserLogic
{
    public Task<UserInformationDto> GetUserInformationAsync(UserInformationDto userInformationDto);
}