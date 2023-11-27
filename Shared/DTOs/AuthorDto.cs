namespace Shared.DTO_s;

public class AuthorDto
{
    public string FullName { get; set; }

    public AuthorDto(string fullName)
    {
        FullName = fullName;
    }
    
    
}