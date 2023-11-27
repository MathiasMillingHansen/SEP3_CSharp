
namespace Logic.Interface;

public interface IBookLogic
{
    public Task<Book> PostBookAsync(BookCreationDto bookCreationDto);
}