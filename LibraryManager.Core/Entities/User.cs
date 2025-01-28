using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Core.Entities
{
    public class User : BaseEntity
    {
        string Name { get; set; }
        string Email { get; set; }
        DateTime BirthDate { get; set; }

    }
}
