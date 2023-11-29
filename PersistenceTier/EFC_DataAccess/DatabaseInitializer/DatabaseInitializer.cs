using Shared.Domain;

namespace EFC_DataAccess;

public static class DatabaseInitializer
{
    public static void Initialize(DatabaseContext context)
    {
        context.Database.EnsureCreated();

        if (!context.courses.Any())
        {
            var courses = new Course[]
            {
                new Course("SDJ1"),
                new Course("WEB1"),
                new Course("DMA1")
            };
            foreach (var course in courses)
            {
                context.courses.Add(course);
            }

            context.SaveChanges();
        }

        if (!context.conditions.Any())
        {
            var conditions = new Condition[]
            {
                new Condition("Pristine"),
                new Condition("Very Good"),
                new Condition("Fair"),
                new Condition("Poor"),
                new Condition("Very Poor")
            };
            foreach (var condition in conditions)
            {
                context.conditions.Add(condition);
            }
            
            context.SaveChanges();
        }

        if (context.authors.Any() || context.books.Any())
        {
            return;
        }


        var authors = new Author[]
        {
            new Author("Tony Gaddis"),
            new Author("Jon Duckett"),
            new Author("Kenneth H. Rosen")
        };
        foreach (var author in authors)
        {
            context.authors.Add(author);
        }
        context.SaveChanges();

        var books = new Book[]
        {
            new Book("9780132164764", "Starting Out with Java: Early Objects", new List<Author> { authors[0] }, "5th",
                new List<Course> { context.courses.Find("SDJ1") }),
            new Book("9781118008188", "HTML and CSS: Design and Build Websites", new List<Author> { authors[1] }, "1st",
                new List<Course> { context.courses.Find("WEB1") }),
            new Book("9780073383095", "Discrete Mathematics and Its Applications", new List<Author> { authors[2] },
                "7th", new List<Course> { context.courses.Find("DMA1") }),
            new Book("9781118531648", "javascript and jquery: interactive front-end web development", new List<Author>{ authors[1] }, "1st",
                new List<Course> { context.courses.Find("WEB1") })
        };
        foreach (var book in books)
        {
            context.books.Add(book);
        }
        context.SaveChanges();
        
    }
}