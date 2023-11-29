using Logic.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shared.Domain;
using Shared.DTOs;

namespace BusinessWebAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class CatalogController
{
    private readonly ICatalogLogic _catalogLogic;
    
    public CatalogController(ICatalogLogic catalogLogic)
    {
        this._catalogLogic = catalogLogic;
    }
    
    [HttpGet]
    public async Task<ActionResult<ICollection<BooksAvailableDto>>> GetAllAsync()
    {
        try
        {
            return new OkObjectResult(await _catalogLogic.GetAllAsync());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet("category")]
    public async Task<ActionResult<ICollection<Condition>>> GetConditionsAsync()
    {
        throw new NotImplementedException();
    }
    
    
    [HttpGet("search")]
    public ActionResult<IEnumerable<BooksAvailableDto>> SearchBooks([FromQuery] Book searchModel)
    {
        var result = _catalogLogic.SearchBooks(searchModel);
        return null;
    }
}