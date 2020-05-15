using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models;
using Bookstore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository bookRepository = null;
        public BookController()
        {
            bookRepository = new BookRepository();
        }

        public ViewResult GetAllBooks()
        {
            var data = bookRepository.GetAllBooks();
            return View();
        }

        public BookModel GetBook(int id)
        {
            return bookRepository.GetBookById(id);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return bookRepository.SearchBook(bookName, authorName);
        }

    }
}