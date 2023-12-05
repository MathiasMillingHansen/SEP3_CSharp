namespace Shared.DTOs;

public class RegisterDto
{
    public string Username { get; }
    public string Password { get; }

    public RegisterDto(string username, string password)
    {
        Username = username;
        Password = password;
    }
}