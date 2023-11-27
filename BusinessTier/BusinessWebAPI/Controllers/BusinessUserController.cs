using Application.LogicInterface;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO_s;

namespace BusinessWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BusinessUserController
{
    private readonly IUserLogic userLogic;
    
    public BusinessUserController(IUserLogic userLogic)
    {
        this.userLogic = userLogic;
    }
    
    [HttpGet]
    public async Task<ICollection<GetUserDto>> GetUsersAsync()
    {
        return await userLogic.GetUsersAsync();
    }
}