using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Book/[action]")]
    public class BookController : Controller
    {
        private IDataRepository<Book> service;

        public BookController(IDataRepository<Book> service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            var item = service.GetAll();
            return item;
        }

        [HttpGet]
        public Book Add()
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                AuthorName = "author",
                BookTitle = "first book",
                Price = 100,
                Publisher = "pub"
            };

            service.Add(book);

            return book;
        }

        [HttpGet]
        public int Update()
        {
           var strId = @"b716388a-8c97-4165-ad8d-404cca26441c";
           var id = new Guid(strId); 

            var book = new Book
            {
                Id = id,
                AuthorName = "author",
                BookTitle = "updated book",
                Genre = "",
                Price = 10,
                Publisher = "pub"
            };

            return service.Update(book);
        }
    }
}