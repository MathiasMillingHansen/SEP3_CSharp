using System.ComponentModel.DataAnnotations;

namespace Shared.Domain;

public class Condition
{
    [Key]
    public string condition { get; set; }

    public Condition(string condition)
    {
        this.condition = condition;
    }
    
    private Condition()
    {
    }
}