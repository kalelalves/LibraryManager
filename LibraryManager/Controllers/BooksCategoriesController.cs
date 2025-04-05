using LibraryManager.Core.Entities;
using LibraryManager.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksCategoriesController : ControllerBase
    {
        private readonly LibraryManagerDbContext _context;

        public BooksCategoriesController(LibraryManagerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BooksCategories>>> GetBooksCategories()
        {
            return await _context.BooksCategories.ToListAsync();
        }

        [HttpGet("{bookId}/{categoryId}")]
        public async Task<ActionResult<BooksCategories>> GetBooksCategories(int bookId, int categoryId)
        {
            var booksCategories = await _context.BooksCategories.FindAsync(bookId, categoryId);

            if (booksCategories == null)
            {
                return NotFound();
            }

            return booksCategories;
        }

        [HttpPost]
        public async Task<ActionResult<BooksCategories>> PostBooksCategories(BooksCategories booksCategories)
        {
            _context.BooksCategories.Add(booksCategories);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBooksCategories), new { bookId = booksCategories.BookId, categoryId = booksCategories.CategoryId }, booksCategories);
        }

        [HttpDelete("{bookId}/{categoryId}")]
        public async Task<IActionResult> DeleteBooksCategories(int bookId, int categoryId)
        {
            var booksCategories = await _context.BooksCategories.FindAsync(bookId, categoryId);
            if (booksCategories == null)
            {
                return NotFound();
            }

            _context.BooksCategories.Remove(booksCategories);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
