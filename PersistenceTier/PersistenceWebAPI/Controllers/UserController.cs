using Logic.LogicImplemtation;
using Logic.LogicInterface;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO_s;

namespace PersistenceWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController
{
    private readonly IUserLogic userLogic;
    
    public UserController(IUserLogic userLogic)
    {
        this.userLogic = userLogic;
    }

    [HttpGet]
    public async Task<ICollection<GetUserDto>> GetUsersAsync()
    {
        return await userLogic.GetUsersAsync();
    }
}