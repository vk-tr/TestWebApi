using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using TestWebApi.Helpers;
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

        [HttpPost("Create4SampleBooks")]
        public HttpResponseMessage Create4SampleBooks()
        {
            return ResponseHelper.ThrowCatch(
                () => _booksService.CreateSample());
        }

        [HttpGet("GetAllBooks")]
        public Book[] GetAllBooks()
        {
            return _booksService.GetAll()
                .ToArray();
        }

        [HttpPost("AddNewBook")]
        public HttpResponseMessage AddNewBook(string title, string author)
        {
            return ResponseHelper.ThrowCatch(
                () => _booksService.Add(title, author));
        }

        [HttpGet("GetAvailableBooks")]
        public Book[] GetAvailableBooks()
        {
            return _booksService.GetAvailableBooks()
                .ToArray();
        }

        [HttpGet("GetBookStatusHistory")]
        public string GetBookStatusHistory(long bookId)
        {
            return _booksService.GetStatusHistory(bookId);
        }
    }
}