using System.ComponentModel.DataAnnotations;

namespace Shared.Domain;

public class Condition
{
    [Key]
    public string State { get; set; }

    public Condition(string state)
    {
        this.State = state;
    }
    
    private Condition()
    {
    }
}