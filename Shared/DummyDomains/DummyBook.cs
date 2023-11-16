namespace Shared.DummyDomains;

public class DummyBook
{
    private string Title { get; set; }
    private int Id { get; set; }
    private string Author { get; set; }

    public DummyBook(string title, int id, string author)
    {
        this.Title = title;
        this.Id = id;
        this.Author = author;
    }
}