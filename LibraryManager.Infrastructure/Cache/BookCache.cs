using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManager.Core.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace LibraryManager.Infrastructure.Cache
{
    public class BookCache
    {
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _cacheDuration = TimeSpan.FromMinutes(30);

        public BookCache(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<Book> GetOrSetAsync(int bookId, Func<Task<Book>> getBook)
        {
            string cacheKey = $"book_{bookId}";

            if (!_cache.TryGetValue(cacheKey, out Book book))
            {
                book = await getBook();

                if (book != null)
                {
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(_cacheDuration);

                    _cache.Set(cacheKey, book, cacheEntryOptions);
                }
            }

            return book;
        }

        public async Task<IEnumerable<Book>> GetOrSetListAsync(string cacheKey, Func<Task<IEnumerable<Book>>> getBooks)
        {
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<Book> books))
            {
                books = await getBooks();

                if (books != null)
                {
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(_cacheDuration);

                    _cache.Set(cacheKey, books, cacheEntryOptions);
                }
            }

            return books;
        }

        public void Remove(int bookId)
        {
            string cacheKey = $"book_{bookId}";
            _cache.Remove(cacheKey);
        }

        public void RemoveList(string cacheKey)
        {
            _cache.Remove(cacheKey);
        }
    }
} 