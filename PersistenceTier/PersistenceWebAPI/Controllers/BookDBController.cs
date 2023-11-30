using Logic.LogicImplemtation;
using Logic.LogicInterface;
using Microsoft.AspNetCore.Mvc;
using Shared.Domain;
using Shared.DTOs;

namespace PersistenceWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BookDBController
{
    private readonly ISellLogic _sellLogic;
    
    public BookDBController(ISellLogic sellLogic)
    {
        this._sellLogic = sellLogic;
    }
    
    [HttpGet]
    public async Task<ActionResult<ICollection<BooksAvailableDto>>> GetAllAsync()
    {
        try
        {
            ICollection<BooksAvailableDto> books = await _sellLogic.GetAllAsync();
            return new OkObjectResult(books);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet("{isbn}")]
    public async Task<ActionResult<BookDto>> GetByIsbnAsync(string isbn)
    {
        try
        {
            BookDto bookDto = await _sellLogic.GetByIsbnAsync(isbn);
            return new OkObjectResult(bookDto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
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
    
    [HttpPost]
    public async Task<ActionResult<BookForSale>> SellBookAsync(BookForSale bookForSale)
    {
        try
        {
            BookForSale result = await _sellLogic.SellBookAsync(bookForSale);
            return new OkObjectResult(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}