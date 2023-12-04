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
        this._catalogLogic = catalogLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<BookForSale>> SellBookAsync(BookForSale dto)
    {
        return await _sellLogic.SellBookAsync(dto);
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
    public async Task<ActionResult<BookWrapperDto>> GetByIsbnAsync(string isbn)
    {
        try
        {
            BookWrapperDto bookWrapperDto = await _sellLogic.GetByIsbnAsync(isbn);
            return new OkObjectResult(bookWrapperDto);
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
    
    
    [HttpGet("test")]
    public async Task<ActionResult<ICollection<BookForSale>>> testGetAll() //TODO remove
    {
        try
        {
            ICollection<BookForSale> books = await _sellLogic.testGetAll();
            return new OkObjectResult(books);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}