using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Application.DTOs;
using LibraryManager.Application.Interfaces;
using LibraryManager.Core.Entities;
using LibraryManager.Core.Interfaces;

namespace LibraryManager.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookDTO>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return books.Select(MapToDTO);
        }

        public async Task<BookDTO> GetByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            return book != null ? MapToDTO(book) : null;
        }

        public async Task<IEnumerable<BookDTO>> GetByCategoryAsync(int categoryId)
        {
            var books = await _bookRepository.GetBooksByCategoryAsync(categoryId);
            return books.Select(MapToDTO);
        }

        public async Task<IEnumerable<BookDTO>> GetAvailableAsync()
        {
            var books = await _bookRepository.GetAvailableBooksAsync();
            return books.Select(MapToDTO);
        }

        public async Task<BookDTO> CreateAsync(CreateBookDTO bookDto)
        {
            var book = new Book(
                bookDto.Title,
                bookDto.Author,
                "Unknown", // Publisher
                DateOnly.FromDateTime(DateTime.Now), // Publication
                bookDto.ISBN
            );
            await _bookRepository.AddAsync(book);
            return MapToDTO(book);
        }

        public async Task UpdateAsync(UpdateBookDTO bookDto)
        {
            var book = await _bookRepository.GetByIdAsync(bookDto.Id);
            if (book == null)
                return;

            book.Title = bookDto.Title;
            book.Author = bookDto.Author;
            book.ISBN = bookDto.ISBN;

            await _bookRepository.UpdateAsync(book);
        }

        public async Task DeleteAsync(int id)
        {
            await _bookRepository.DeleteAsync(id);
        }

        private static BookDTO MapToDTO(Book book)
        {
            return new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                PublicationYear = book.Publication.Year,
                Categories = book.Categories?.Select(c => new CategoryDTO
                {
                    Id = c.CategoryId,
                    Name = c.Category?.CategoryName ?? string.Empty
                }).ToList() ?? new List<CategoryDTO>()
            };
        }
    }
} 