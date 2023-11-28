using Application.DAOInterfaces;
using BusinessWebAPI.Application.DaoInterface;
using Logic.Interfaces;
using Shared.Domain;
using Shared.DTOs;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao _userDao;

    public UserLogic(IUserDao userDao)
    {
        _userDao = userDao;
    }
    
    // public async Task<UserInformation> CreateAsync(UserCreationDTO dto)
    // {
    //     UserInformation? existing = await _userDao.GetByUsernameAsync(dto.username);
    //     if (existing!=null)
    //     {
    //         throw new Exception("Username already taken!");
    //     }
    //
    //     ValidateUsername(dto);
    //     UserInformation toCreate = new UserInformation()
    //     {
    //         Username = dto.username,
    //     };
    //     UserInformation created = await _userDao.CreateAsync(toCreate);
    //     return created;
    // }
    //
    // public Task<UserInformation> GetByUsernameAsync(string username)
    // {
    //     return _userDao.GetByUsernameAsync(username);
    // }
    //
    // public Task<IEnumerable<UserInformation>> GetAllAsync()
    // {
    //     return _userDao.GetAllAsync();
    // }
    //
    // private void ValidateUsername(UserCreationDTO dto)
    // {
    //     if (dto.username.Length < 3)
    //     {
    //         throw new Exception("Username must be at least 4 characters.");
    //     }
    // }
    public Task<UserInformation> CreateAsync(UserCreationDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<UserInformation> GetByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserInformation>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}