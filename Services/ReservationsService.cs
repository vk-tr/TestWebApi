using System.Linq;
using TestWebApi.Contexts;
using TestWebApi.Interfaces;
using TestWebApi.Models;

namespace TestWebApi.Services
{
    public class ReservationsService
    {
        private readonly IRepository<Reservation> _reservationRepository;

        public ReservationsService()
        {
            _reservationRepository = new Repository<Reservation>(new DataBaseContext());
        }

        public IQueryable<Reservation> GetAll()
        {
            return _reservationRepository.GetAll();
        }

        public void Remove(long bookId)
        {
            var reservationToRemove = _reservationRepository.GetAll()
                .FirstOrDefault(x => x.BookId == bookId);

            if (reservationToRemove == default)
            {
                return;
            }

            _reservationRepository.Remove(reservationToRemove);
        }

        public void Add(long bookId, string comment)
        {
            var hasReservationWithThatBook = _reservationRepository.GetAll()
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

            _reservationRepository.Add(newEntity);
        }
    }
}