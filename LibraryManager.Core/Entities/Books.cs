

namespace LibraryManager.Core.Entities
{
    public class Book : BaseEntity

    {
        public  string Title { get; set; }
        public string Author { get; set; }

        public string Publisher { get; set; }
        public DateOnly Publication { get; set; }
        public string ISBN { get; set; }

        public int CategoryId { get; set; }

        public List<BooksCategories> Categories { get; set; } 

        public Book(string title, string author, string publisher, DateOnly publication, string isbn, int categoryId)
            :base()
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            Publication = publication;
            ISBN = isbn;
            CategoryId = categoryId;
        }
    }
}
