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
                new BookModel(){Id=1,Title="ASP.Net",Author="Omarzaki",Description="This is Description of ASP.Net Book.",Category="Framework",Language="English",TotalPages=502},
                new BookModel(){Id=2,Title="C#",Author="Nitish",Description="This is Description of C# Book.",Category="Programming Language",Language="English",TotalPages=600},
                new BookModel(){Id=3,Title="Java",Author="CodewithZaki",Description="This is Description of Java Book.",Category="Concept",Language="Chinese",TotalPages=801},
                new BookModel(){Id=4,Title="Web Development",Author="CodewithZaki",Description="This is Description of Web Development Book.",Category="Web",Language="English",TotalPages=387},
                new BookModel(){Id=5,Title="Azure Dev",Author="CodewithZaki",Description="This is Description of Azure Dev Book.",Category="Microsoft",Language="English",TotalPages=254},
                new BookModel(){Id=6,Title="Database with SQL",Author="CodewithZaki",Description="This is Description of Database with SQL Book.",Category="Database",Language="English",TotalPages=688},
            };
        }
    }
}
