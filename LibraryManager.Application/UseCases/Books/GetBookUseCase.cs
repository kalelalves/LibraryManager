using System.Threading.Tasks;
using LibraryManager.Core.Entities;
using LibraryManager.Core.Interfaces;

namespace LibraryManager.Application.UseCases.Books
{
    public class GetBookUseCase
    {
        private readonly IBookRepository _bookRepository;

        public GetBookUseCase(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Execute(int bookId)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            
            if (book == null)
                throw new System.Exception("Book not found");

            return book;
        }
    }
} 