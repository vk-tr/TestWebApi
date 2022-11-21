using System.Linq;
using TestWebApi.Contexts;
using TestWebApi.Interfaces;
using TestWebApi.Models;

namespace TestWebApi.Services
{
    public class BooksService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Reservation> _reservationRepository;

        public BooksService()
        {
            _bookRepository = new Repository<Book>(new DataBaseContext());
            _reservationRepository = new Repository<Reservation>(new DataBaseContext());
        }

        public IQueryable<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public void Add(string title, string author)
        {
            var newEntity = new Book
            {
                Title = title,
                Author = author
            };

            _bookRepository.Add(newEntity);
        }

        public IQueryable<Book> GetAvailableBooks()
        {
            var reservationIds = _reservationRepository.GetAll()
                .Select(x => x.BookId);

            return _bookRepository.GetAll()
                .Where(x => reservationIds.Any(y => y == x.Id));
        }
    }
}