

namespace LibraryManager.Core.Entities
{
    public class Book : BaseEntity

    {
        string Title { get; set; }
        string Author { get; set; }

        string Publisher { get; set; }
        DateOnly Publication { get; set; }
        string ISBN { get; set; }

        Category CategoryId { get; set; }


        public Book(string title, string author, string publisher, DateOnly publication, string isbn, Category categoryId)
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
