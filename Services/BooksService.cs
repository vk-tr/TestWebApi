using System.Linq;
using TestWebApi.Contexts;
using TestWebApi.Interfaces;
using TestWebApi.Models;

namespace TestWebApi.Services
{
    public class BooksService
    {
        private readonly IRepository _repository;

        public BooksService()
        {
            _repository = new Repository(new DataBaseContext());
        }

        public IQueryable<Book> GetAll()
        {
            return _repository.GetAll<Book>();
        }

        public void Add(string title, string author)
        {
            var newEntity = new Book
            {
                Title = title,
                Author = author
            };

            _repository.Add(newEntity);
        }

        public IQueryable<Book> GetAvailableBooks()
        {
            var reservationIds = _repository.GetAll<Reservation>()
                .Select(x => x.BookId);

            return _repository.GetAll<Book>()
                .Where(x => !reservationIds.Any(y => y == x.Id));
        }
    }
}