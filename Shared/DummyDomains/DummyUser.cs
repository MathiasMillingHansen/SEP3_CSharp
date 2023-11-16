namespace Shared.DummyDomains;

public class DummyUser
{
    public string Username { get; set; }
    public string Password { get; set; }

    public DummyUser(string username, string password)
    {
        this.Username = username;
        this.Password = password;
    }
}