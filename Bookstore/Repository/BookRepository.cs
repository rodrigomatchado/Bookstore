using Bookstore.Data;
using Bookstore.Models;
using BookStore.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Bookstore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow
            };

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbooks = await _context.Books.ToListAsync();
            if (allbooks?.Any() == true)
            {
                foreach (var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Id = book.Id,
                        Author = book.Author,
                        Title = book.Title,
                        Category = book.Category,
                        Language = book.Language,
                        Description = book.Description,
                        TotalPages = book.TotalPages,
                    });
                }
            }
            return books;
        }
        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if(book != null)
            {
                var bookDetails = new BookModel()
                {
                    Id = book.Id,
                    Author = book.Author,
                    Title = book.Title,
                    Category = book.Category,
                    Language = book.Language,
                    Description = book.Description,
                    TotalPages = book.TotalPages,
                };
                return bookDetails;
            }
            return null;
        }

        public List<BookModel> SearchBook(string title, string authorname)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorname)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id = 1 , Title = "MVC", Author = "Jeronimo", Description = "This is the description for MVC Book", Category="Programming", Language = "English", TotalPages = 134},
                new BookModel(){Id = 2 , Title = "C#", Author = "Monica", Description = "This is the description for C# Book", Category="Developer", Language = "Portuguese", TotalPages = 1259},
                new BookModel(){Id = 3 , Title = "Ruby", Author = "Facebook", Description = "This is the description for Ruby Book", Category="Concept", Language = "Chinese", TotalPages = 524},
                new BookModel(){Id = 4 , Title = "Java", Author = "Android", Description = "This is the description for Java Book", Category="Programming", Language = "English", TotalPages = 18},
                new BookModel(){Id = 5 , Title = ".Net Core", Author = "Microsoft", Description = "This is the description for .Net Core Book", Category="Framework", Language = "English", TotalPages = 239}
            };
        }
    }
}
