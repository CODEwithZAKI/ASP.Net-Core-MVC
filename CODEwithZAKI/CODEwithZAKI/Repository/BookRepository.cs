using CODEwithZAKI.Data;
using CODEwithZAKI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CODEwithZAKI.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel bookModel)
        {
            var newBook = new Books()
            {
                Author = bookModel.Author,
                CreatedOn=DateTime.UtcNow,
                Description=bookModel.Description,
                Title=bookModel.Title,
                TotalPages=bookModel.TotalPages.HasValue ? bookModel.TotalPages.Value:0,
                UpdatedOn=DateTime.UtcNow
            };
           await _context.Books.AddAsync(newBook);
           await _context.SaveChangesAsync();
            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbooks = await _context.Books.ToListAsync();
            if(allbooks?.Any()==true)
            {
                foreach (var book in allbooks)
                {
                    if (book.Title== "Asp.Net")
                    {
                        
                    }
                        books.Add(new BookModel()
                        {

                            Author = book.Author,
                            Id = book.Id,
                            Title = book.Title,
                            TotalPages = book.TotalPages,
                            Category = book.Category,
                            Description = book.Description,
                            Language = book.Language
                        });
                    
                    
                    
                }
                          
            }
            return books;
        }
        public async Task< BookModel> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                var bookDetails = new BookModel()
                {
                    Author = book.Author,
                    Id = book.Id,
                    Title = book.Title,
                    TotalPages = book.TotalPages,
                    Category = book.Category,
                    Description = book.Description,
                    Language = book.Language
                };
                return bookDetails;
            }
            return null;
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
