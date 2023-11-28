namespace Shared.Domain;

public class Condition
{
    public string condition { get; set; }

    public Condition(string condition)
    {
        this.condition = condition;
    }
    
    private Condition()
    {
    }
}