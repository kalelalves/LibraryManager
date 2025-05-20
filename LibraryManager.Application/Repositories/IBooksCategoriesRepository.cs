using LibraryManager.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManager.Application.Repositories
{
    public interface IBooksCategoriesRepository
    {
        Task<IEnumerable<BooksCategories>> GetBooksCategoriesAsync();
        Task<BooksCategories> GetBooksCategoriesByIdAsync(int bookId, int categoryId);
        Task<BooksCategories> AddBooksCategoriesAsync(BooksCategories booksCategories);
        Task<bool> DeleteBooksCategoriesAsync(int bookId, int categoryId);
    }
}

