using System.Collections.Generic;
using System.Linq;
using Models;

namespace Repositories
{
    public class BookService : IDataRepository<Book, int>
    {
        private ApplicationContext ctx;

        public BookService(ApplicationContext context)
        {
            ctx = context;
        }

        public int Add(Book b)
        {
            ctx.Books.Add(b);
            var res = ctx.SaveChanges();
            return res;
        }

        public int Delete(int id)
        {
            var res = 0;

            var book = ctx.Books.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                ctx.Books.Remove(book);
                res = ctx.SaveChanges();
            }

            return res;
        }

        public IEnumerable<Book> GetAll()
        {
            var books = ctx.Books.ToList();
            return books;
        }

        public Book Get(int id)
        {
            var book = ctx.Books.FirstOrDefault(b => b.Id == id);
            return book;
        }
      

        public int Update(int id, Book b)
        {
            var res = 0;
            var book = ctx.Books.Find(id);

            if (book != null)
            {
                book.BookTitle = b.BookTitle;
                book.AuthorName = b.AuthorName;
                book.Publisher = b.Publisher;
                book.Genre = b.Genre;
                b.Price = b.Price;
                res = ctx.SaveChanges();
            }

            return res;
        }

    }
}
