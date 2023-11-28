using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Domain;
using Shared.DTOs;

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
    public async Task<ActionResult<Book>> CreateAsync(BookSaleDto dto)
    {
        Console.WriteLine("Book received" + dto.BookTitle);
        return await _bookLogic.CreateAsync(dto);
    }
}