namespace Shared.DTOs;

public class GetUserDto
{
    public string Username { get; set; }
    
    public GetUserDto(string username)
    {
        this.Username = username;
    }
}