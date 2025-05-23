﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Core.Entities
{
    public class Loan:BaseEntity
    {
        public int UserId { get; set; } 
        public int BookId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; } 

        // Navegação
        public User User { get; set; }
        public Book Book { get; set; }
    }
}
