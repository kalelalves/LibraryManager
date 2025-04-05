using LibraryManager.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManager.Application.Services
{
    public interface ILoanService
    {
        Task<IEnumerable<Loan>> GetLoansAsync();
        Task<Loan> GetLoanByIdAsync(int id);
        Task<Loan> AddLoanAsync(Loan loan);
        Task<Loan> UpdateLoanAsync(Loan loan);
        Task<bool> DeleteLoanAsync(int id);
    }
}

