using Logic.Interface;
using Microsoft.AspNetCore.Mvc;
using Shared.Domain;

namespace BusinessWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController
{
    private readonly IBookLogic _bookLogic;
    
    public BookController(IBookLogic bookLogic)
    {
        this._bookLogic = bookLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<Book>> PostBookAsync()
    {
        return await _bookLogic.PostBookAsync();
    }
}