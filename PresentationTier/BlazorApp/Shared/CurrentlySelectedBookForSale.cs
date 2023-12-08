using Shared.Domain;

namespace BlazorApp.Shared;

public class CurrentlySelectedBookForSale
{
    public static BookForSale? CurrentlySelected { get; set; }
}