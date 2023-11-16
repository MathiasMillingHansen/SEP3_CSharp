using Application.DaoInterface;
using DummyFileData;
using Shared.DTO_s;

namespace Application.DaoImplementation;

public class UserDao : IUserDAO
{

    private readonly FileContext _fileContext;

    public UserDao(FileContext fileContext)
    {
        _fileContext = fileContext;
    }
    
    public Task<ICollection<GetUserDto>> GetUsersAsync()
    {
        ICollection<GetUserDto> users = _fileContext.GetUsers();
        return Task.FromResult(users);
    }
}