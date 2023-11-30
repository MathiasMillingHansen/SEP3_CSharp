using Shared.Domain;
using Shared.DTOs;

namespace EFC_DataAccess.DAOs;

public interface IEfcBookDao
{
    Task<Book> InsertAsync(Book book);
    Task<List<Book>> GetAllAsync();
    Task<ICollection<Condition>> GetConditionsAsync();
    Task<BookDto> GetByIsbnAsync(string isbn);
    Task<BookForSale> SellBookAsync(BookForSale bookForSale);
    void AttachAuthor(Author author);
    void AttachCourse(Course course);
    void AttachBook(Book book);
    void AttachCondition(Condition condition);
    
}