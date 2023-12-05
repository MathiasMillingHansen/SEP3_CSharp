namespace Shared.DTOs;

public class UserInformationDto
{
    public string Username { get; }
    public string PhoneNumber{ get; }
    public string Email{ get; }

    public UserInformationDto(string username, string phoneNumber, string email)
    {
        Username = username;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}