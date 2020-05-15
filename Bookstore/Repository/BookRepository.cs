using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Bookstore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id ).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string title, string authorname)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorname)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id = 1 , Title = "MVC", Author = "Jeronimo"},
                new BookModel(){Id = 1 , Title = "C#", Author = "Monica"},
                new BookModel(){Id = 1 , Title = "Ruby", Author = "Facebook"},
                new BookModel(){Id = 1 , Title = "Java", Author = "Android"}
            };
        }

    }
}
