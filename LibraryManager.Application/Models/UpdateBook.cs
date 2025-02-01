using LibraryManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Models
{
    public class UpdateBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        string Author { get; set; }

        public string Publisher { get; set; }
        public DateOnly Publication { get; set; }
        public string ISBN { get; set; }

        public Category CategoryId { get; set; }



    }
}
