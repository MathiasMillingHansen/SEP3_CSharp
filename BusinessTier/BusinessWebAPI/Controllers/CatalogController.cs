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
    public async Task<ActionResult<BooksForSaleDto>> GetAllBooksForSaleAsync()
    {
        try
        {
            return new OkObjectResult(await _catalogLogic.GetAllBooksForSaleAsync());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet("course")]
    public async Task<ActionResult<ICollection<Course>>> GetCourseAsync()
    {
        try
        {
            ICollection<BookCourseDto> courses = await _catalogLogic.GetByCourseAsync();
            return new OkObjectResult(courses);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    
    [HttpGet("search")]
    public ActionResult<IEnumerable<BooksAvailableDto>> SearchBooks([FromQuery] Book searchModel)
    {
        var result = _catalogLogic.SearchBooks(searchModel);
        return null;
    }
}