using Shared.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<string> RegisterUserAsync(RegisterDto registerDto);

    Task<string> LoginUser(LoginDto loginDto);


}