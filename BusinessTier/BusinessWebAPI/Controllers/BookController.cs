using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Domain;
using Shared.DTOs;

namespace BusinessWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly ISellLogic _sellLogic;
    
    public BookController(ISellLogic sellLogic)
    {
        this._sellLogic = sellLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<string>> SellBookAsync(BookSaleDto dto)
    {
        try
        {
            return await _sellLogic.SellBookAsync(dto);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<ICollection<BooksAvailableDto>>> GetAllAsync()
    {
        try
        {
            return new OkObjectResult(await _sellLogic.GetAllAsync());
        }
        catch (HttpRequestException e)
        {
            return StatusCode(404, e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("conditions")]
    public async Task<ActionResult<ICollection<Condition>>> GetConditionsAsync()
    {
        try
        {
            ICollection<Condition> conditions = await _sellLogic.GetConditionsAsync();
            return new OkObjectResult(conditions);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet("/Book/Owner/{owner}")]
    public async Task<ActionResult<BooksForSaleDto>> GetBooksByOwnerAsync(string owner)
    {
        try
        {
            BooksForSaleDto booksForSaleDto = await _sellLogic.GetBooksByOwnerAsync(owner);
            return new OkObjectResult(booksForSaleDto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpDelete("/Book/{id}")]
    public async Task<ActionResult> DeleteBookForSaleAsync(int id)
    {
        try
        {
            await _sellLogic.DeleteBookForSaleAsync(id);
            return new OkResult();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpPatch("/editBook")]
    public async Task<ActionResult> EditBookForSaleAsync(EditBookForSaleDto dto)
    {
        try
        {
            await _sellLogic.EditBookForSaleAsync(dto);
            return new OkResult();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet("/BookOwnerInfo{username}")]
    public async Task<ActionResult<UserInfoDto>> GetUserInfoAsync(string username)
    {
        try
        {
            UserInfoDto userInfoDto = await _sellLogic.GetUserInfoAsync(username);
            return new OkObjectResult(userInfoDto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}