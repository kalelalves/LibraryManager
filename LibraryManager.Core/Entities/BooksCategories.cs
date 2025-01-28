using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Core.Entities
{
    public class BooksCategories
    {
        Book BookId { get; set; }
        Category CategoryId { get; set; }   
    }
}
