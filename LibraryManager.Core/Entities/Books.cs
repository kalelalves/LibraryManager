

namespace LibraryManager.Core.Entities
{
    public class Book : BaseEntity

    {
        public  string Title { get; set; }
        public string Author { get; set; }

        public string Publisher { get; set; }
        public DateOnly Publication { get; set; }
        public string ISBN { get; set; }

      

        public List<BooksCategories> Categories { get; set; } 

        public Book(string title, string author, string publisher, DateOnly publication, string isbn)
            :base()
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            Publication = publication;
            ISBN = isbn;
           
        }
        public ICollection<Loan> Loans { get; set; }
    }
}
