using System.Linq;
using TestWebApi.Contexts;
using TestWebApi.Interfaces;
using TestWebApi.Models;

namespace TestWebApi.Services
{
    public class ReservationsService
    {
        private readonly IRepository _repository;

        public ReservationsService()
        {
            _repository = new Repository(new DataBaseContext());
        }

        public IQueryable<Reservation> GetAll()
        {
            return _repository.GetAll<Reservation>();
        }

        public void Remove(long bookId)
        {
            var reservationToRemove = _repository.GetAll<Reservation>()
                .FirstOrDefault(x => x.BookId == bookId);

            if (reservationToRemove == default)
            {
                return;
            }

            _repository.Remove(reservationToRemove);
        }

        public void Add(long bookId, string comment)
        {
            var hasReservationWithThatBook = _repository.GetAll<Reservation>()
                .Select(x => x.BookId)
                .Any(x => x == bookId);

            if (hasReservationWithThatBook)
            {
                return;
            }

            var newEntity = new Reservation
            {
                BookId = bookId,
                Comment = comment
            };

            _repository.Add(newEntity);
        }
    }
}