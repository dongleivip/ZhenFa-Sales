using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;

namespace Web.Controllers
{
    public class BookController : Controller
    {
        private ApplicationContext _context;

        private IDataRepository<Book, int> _bookService;

        //        public BookController(ApplicationContext context)
        //        {
        //            this._context = context;
        //        }

        public BookController(IDataRepository<Book, int> bookService)
        {
            this._bookService = bookService;
        }

        // GET: /<controller>/
//        public IActionResult Index()
//        {
//            var books = _context.Books.ToList();
//
//            ViewData["Books"] = books;
//
//            return View();
//        }

        public IActionResult Index()
        {
            var books = _bookService.GetBooks();

            ViewData["Books"] = books;

            return View();
        }
    }
}
