namespace Shared.DTOs;

public class UserDto
{
    public string username { get; set; }

    public UserDto(string username)
    {
        this.username = username;
    }
}