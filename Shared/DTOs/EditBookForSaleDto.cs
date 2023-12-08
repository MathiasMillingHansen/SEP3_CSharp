using Shared.Domain;

namespace Shared.DTOs;

public class EditBookForSaleDto
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public Condition Condition { get; set; }
    public string Comment { get; set; }
}