using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Core.Entities
{
    public class BooksCategories
    {
        public Book BookId { get; set; }
        public Category CategoryId { get; set; }   
    }
}
