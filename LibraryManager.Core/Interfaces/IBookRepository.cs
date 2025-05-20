using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManager.Core.Entities;

namespace LibraryManager.Core.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetBooksByCategoryAsync(int categoryId);
        Task<IEnumerable<Book>> GetAvailableBooksAsync();
        Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author);
        Task<bool> IsBookAvailableAsync(int bookId);
    }
} 