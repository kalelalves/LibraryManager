

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


    }
}
