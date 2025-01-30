using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Application.Models;
using LibraryManager.Core.Entities;
using LibraryManager.Models;


namespace LibraryManager.Application.Services
{
    public interface IBookServicecs
    {

        ResultViewModel<List<BookViewModel>> GetAll(string search = "");
        ResultViewModel<BookViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateBook model);
        ResultViewModel Update(UpdateBook model);
        ResultViewModel Delete(int id);
    }

   }

