using Shared.Domain;

namespace Shared.DTOs;

public class BookCategoryDto
{
    public Book book { get; set; }
    
    public string Category { get; set; }

    public BookCategoryDto(string category)
    {
        Category = category;
    }
}