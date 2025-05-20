using System;
using System.Threading.Tasks;
using LibraryManager.Core.Interfaces;
using LibraryManager.Infrastructure.Repositories;

namespace LibraryManager.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryManagerDbContext _context;
        private IBookRepository _books;

        public UnitOfWork(LibraryManagerDbContext context)
        {
            _context = context;
        }

        public IBookRepository Books => _books ??= new BookRepository(_context);

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
} 