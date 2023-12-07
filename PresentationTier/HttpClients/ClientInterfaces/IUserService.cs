using Shared.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task RegisterUserAsync(string username, string password, string phoneNumber, string email);

    Task<string> LoginUser(string username, string password);


}