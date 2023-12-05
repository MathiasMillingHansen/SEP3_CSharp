using Logic.Interfaces;
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
    private readonly ICatalogLogic _catalogLogic;
    
    public BookDBController(ISellLogic sellLogic, ICatalogLogic catalogLogic)
    {
        this._sellLogic = sellLogic;
        this._catalogLogic = catalogLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<string>> SellBookAsync(BookForSale dto)
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
    public async Task<ActionResult<Book>> GetByIsbnAsync(string isbn)
    {
        try
        {
            Book book = await _sellLogic.GetByIsbnAsync(isbn);
            return new OkObjectResult(book);
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
    
    
    [HttpGet("booksForSale")]
    public async Task<ActionResult<BooksForSaleDto>> GetAllBooksForSaleAsync() 
    {
        try
        {
            BooksForSaleDto books = await _catalogLogic.GetAllBooksForSaleAsync();
            return new OkObjectResult(books);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet("/BookDB/Owner/{owner}")]
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
    
    [HttpDelete("{id}")]
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
    
    
}