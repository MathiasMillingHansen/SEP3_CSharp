namespace Shared.DTOs;

public class AuthorDto
{
    public string FullName { get; set; }

    public AuthorDto(string fullName)
    {
        FullName = fullName;
    }
    
    
}