using Logic.LogicImplemtation;
using Logic.LogicInterface;
using Microsoft.AspNetCore.Mvc;
using Shared.Domain;

namespace PersistenceWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BookDBController
{
    private readonly IBookLogic _bookLogic;
    
    public BookDBController(IBookLogic bookLogic)
    {
        this._bookLogic = bookLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Book>> CreateAsync(Book book)
    {
        return await _bookLogic.CreateAsync(book);
    }
}