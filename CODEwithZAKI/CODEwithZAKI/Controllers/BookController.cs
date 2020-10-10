using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using CODEwithZAKI.Models;
using CODEwithZAKI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CODEwithZAKI.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        public BookController()
        {
            _bookRepository = new BookRepository();
        }
        public ViewResult GetAllBooks()
        {
            var data= _bookRepository.GetAllBooks();
            return View(data);
        }
        public ViewResult GetBook(int id)
        {
            var data= _bookRepository.GetBookById(id);
            return View(data);
        }
        public List<BookModel> SearchBook(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName,authorName);
        }
    }
}
