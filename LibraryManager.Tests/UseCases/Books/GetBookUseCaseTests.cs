using System;
using System.Threading.Tasks;
using LibraryManager.Application.UseCases.Books;
using LibraryManager.Core.Entities;
using LibraryManager.Core.Interfaces;
using Moq;
using Xunit;

namespace LibraryManager.Tests.UseCases.Books
{
    public class GetBookUseCaseTests
    {
        private readonly Mock<IBookRepository> _bookRepositoryMock;
        private readonly GetBookUseCase _getBookUseCase;

        public GetBookUseCaseTests()
        {
            _bookRepositoryMock = new Mock<IBookRepository>();
            _getBookUseCase = new GetBookUseCase(_bookRepositoryMock.Object);
        }

        [Fact]
        public async Task Execute_WhenBookExists_ReturnsBook()
        {
            // Arrange
            var bookId = 1;
            var expectedBook = new Book
            {
                Id = bookId,
                Title = "Test Book",
                Author = "Test Author",
                ISBN = "1234567890"
            };

            _bookRepositoryMock.Setup(x => x.GetByIdAsync(bookId))
                .ReturnsAsync(expectedBook);

            // Act
            var result = await _getBookUseCase.Execute(bookId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(bookId, result.Id);
            Assert.Equal(expectedBook.Title, result.Title);
            Assert.Equal(expectedBook.Author, result.Author);
            Assert.Equal(expectedBook.ISBN, result.ISBN);
        }

        [Fact]
        public async Task Execute_WhenBookDoesNotExist_ThrowsException()
        {
            // Arrange
            var bookId = 1;
            _bookRepositoryMock.Setup(x => x.GetByIdAsync(bookId))
                .ReturnsAsync((Book)null);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _getBookUseCase.Execute(bookId));
        }
    }
} 