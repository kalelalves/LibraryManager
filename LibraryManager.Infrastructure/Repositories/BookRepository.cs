using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LibraryManager.Core.Entities;
using LibraryManager.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryManagerDbContext _context;

        public BookRepository(LibraryManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Categories)
                .FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books
                .Include(b => b.Categories)
                .Where(b => !b.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> FindAsync(Expression<Func<Book, bool>> predicate)
        {
            return await _context.Books
                .Include(b => b.Categories)
                .Where(predicate)
                .Where(b => !b.IsDeleted)
                .ToListAsync();
        }

        public async Task AddAsync(Book entity)
        {
            await _context.Books.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book entity)
        {
            entity.UpdatedAt = DateTime.Now;
            _context.Books.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = await GetByIdAsync(id);
            if (book != null)
            {
                book.IsDeleted = true;
                book.UpdatedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Books.AnyAsync(b => b.Id == id && !b.IsDeleted);
        }

        public async Task<IEnumerable<Book>> GetBooksByCategoryAsync(int categoryId)
        {
            return await _context.Books
                .Include(b => b.Categories)
                .Where(b => b.Categories.Any(c => c.CategoryId == categoryId) && !b.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAvailableBooksAsync()
        {
            return await _context.Books
                .Include(b => b.Categories)
                .Where(b => !b.IsDeleted && !b.Loans.Any(l => !l.ReturnDate.HasValue))
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author)
        {
            return await _context.Books
                .Include(b => b.Categories)
                .Where(b => b.Author.Contains(author) && !b.IsDeleted)
                .ToListAsync();
        }

        public async Task<bool> IsBookAvailableAsync(int bookId)
        {
            return await _context.Books
                .AnyAsync(b => b.Id == bookId && !b.IsDeleted && !b.Loans.Any(l => !l.ReturnDate.HasValue));
        }
    }
}
