using LibraryManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Models
{
    public class CreateBook
    {
        string Title { get; set; }
        string Author { get; set; }

        string Publisher { get; set; }
        DateOnly Publication { get; set; }
        string ISBN { get; set; }

        Category CategoryId { get; set; }

        public Book ToEntity()=> new( Title, Author, Publisher, Publication, ISBN);  

    }
}
