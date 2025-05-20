using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManager.Application.DTOs;

namespace LibraryManager.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetAllAsync();
        Task<BookDTO> GetByIdAsync(int id);
        Task<IEnumerable<BookDTO>> GetByCategoryAsync(int categoryId);
        Task<IEnumerable<BookDTO>> GetAvailableAsync();
        Task<BookDTO> CreateAsync(CreateBookDTO bookDto);
        Task UpdateAsync(UpdateBookDTO bookDto);
        Task DeleteAsync(int id);
    }
} 