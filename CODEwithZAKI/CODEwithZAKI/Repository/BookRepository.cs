using CODEwithZAKI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CODEwithZAKI.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }
        public List<BookModel> SearchBook(string title,string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) && x.Author.Contains(authorName)).ToList();
        }
        public List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1,Title="ASP.Net",Author="Omarzaki"},
                new BookModel(){Id=2,Title="C#",Author="Nitish"},
                new BookModel(){Id=3,Title="Java",Author="CodewithZaki"},
                new BookModel(){Id=4,Title="Web Development",Author="CodewithZaki"},
            };
        }
    }
}
