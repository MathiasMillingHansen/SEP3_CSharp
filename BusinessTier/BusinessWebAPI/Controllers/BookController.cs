using Logic.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shared.Domain;
using Shared.DTOs;

namespace BusinessWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController
{
    private readonly ISellLogic _sellLogic;
    
    public BookController(ISellLogic sellLogic)
    {
        this._sellLogic = sellLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<Book>> SellBookAsync(BookSaleDto dto)
    {
        return await _sellLogic.SellBookAsync(dto);
    }
    
    [HttpGet]
    public async Task<ActionResult<ICollection<BooksAvailableDto>>> GetAllAsync()
    {
        try
        {
            return new OkObjectResult(await _sellLogic.GetAllAsync());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet("{conditions}")]
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
    
}