﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Core.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }


        public ICollection<BooksCategories> BooksCategories { get; set; }
    }


}
