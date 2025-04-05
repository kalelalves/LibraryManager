using LibraryManager.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManager.Application.Services
{
    public interface IBooksCategoriesService
    {
        Task<IEnumerable<BooksCategories>> GetBooksCategoriesAsync();
        Task<BooksCategories> GetBooksCategoriesByIdAsync(int bookId, int categoryId);
        Task<BooksCategories> AddBooksCategoriesAsync(BooksCategories booksCategories);
        Task<bool> DeleteBooksCategoriesAsync(int bookId, int categoryId);
    }
}

