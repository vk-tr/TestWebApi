using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestWebApi.Models;
using TestWebApi.Services;

namespace TestWebApi.Controllers
{
    [ApiController]
    [Route("books/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet("GetAllBooks")]
        public List<Book> GetAllBooks()
        {
            return _booksService.GetAll().ToList();
        }

        [HttpPost("PostBook")]
        public void Post(string title, string author)
        {
            _booksService.Add(title, author);
        }

        [HttpPost("GetAvailableBooks")]
        public Book[] GetAvailableBooks()
        {
            return _booksService.GetAvailableBooks().ToArray();
        }
    }
}