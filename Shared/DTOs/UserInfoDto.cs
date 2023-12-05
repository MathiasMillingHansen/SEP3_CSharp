namespace Shared.DTOs;

public class UserInfoDto
{
    public string username { get; set; }
    public string email { get; set; }
    public string phoneNumber { get; set; }

    public UserInfoDto(String username, String email, String phoneNumber) {
        this.username = username;
        this.email = email;
        this.phoneNumber = phoneNumber;
    }
    
    public UserInfoDto() {}
}