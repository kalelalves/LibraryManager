using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Core.Entities
{
    public class Loan:BaseEntity
    {
        User UserId { get; set; }

        Book BookId { get; set; }
        DateTime LoanDate { get; set; }
        DateTime ReturnDate { get; set; }
    }
}
