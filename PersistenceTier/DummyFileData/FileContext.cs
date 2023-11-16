using Shared.DTO_s;
using Shared.DummyDomains;

namespace DummyFileData;

public class FileContext
{
    public ICollection<DummyBook> Books { get; set; }
    public ICollection<DummyUser> Users { get; set; }
    
    public FileContext()
    {
        Books = new List<DummyBook>();
        Users = new List<DummyUser>();
        
        Books.Add(new DummyBook("The Lord of the Rings", 1, "J.R.R. Tolkien"));
        Books.Add(new DummyBook("The Hobbit", 2, "J.R.R. Tolkien"));
        Books.Add(new DummyBook("The Silmarillion", 3, "J.R.R. Tolkien"));
        Books.Add(new DummyBook("The Children of Húrin", 4, "J.R.R. Tolkien"));
        Users.Add(new DummyUser("admin", "admin"));
        Users.Add(new DummyUser("user", "user"));
        Users.Add(new DummyUser("test", "test"));
    }

    public ICollection<GetUserDto> GetUsers()
    {
        ICollection<GetUserDto> users = new List<GetUserDto>();
        foreach (var user in Users)
        {
            users.Add(new GetUserDto(user.Username));
        }
        return users;
    }
    
}