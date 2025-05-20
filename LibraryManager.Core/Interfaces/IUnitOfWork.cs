using System;
using System.Threading.Tasks;

namespace LibraryManager.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Books { get; }
        Task<int> CompleteAsync();
    }
} 