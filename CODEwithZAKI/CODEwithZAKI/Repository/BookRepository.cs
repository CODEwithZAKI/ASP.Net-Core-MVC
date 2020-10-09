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
                new BookModel(){Id=1,Title="ASP.Net",Author="Omarzaki",Description="This is Description of ASP.Net Book."},
                new BookModel(){Id=2,Title="C#",Author="Nitish",Description="This is Description of C# Book."},
                new BookModel(){Id=3,Title="Java",Author="CodewithZaki",Description="This is Description of Java Book."},
                new BookModel(){Id=4,Title="Web Development",Author="CodewithZaki",Description="This is Description of Web Development Book."},
                new BookModel(){Id=5,Title="Azure Dev",Author="CodewithZaki",Description="This is Description of Azure Dev Book."},
            };
        }
    }
}
