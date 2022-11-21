using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http;
using TestWebApi.Contexts;
using TestWebApi.Exceptions;
using TestWebApi.Interfaces;
using TestWebApi.Models;

namespace TestWebApi.Services
{
    public class ReservationsService
    {
        private readonly IRepository _repository;

        private readonly ReservationLogsService _reservationLogsService;

        public ReservationsService(
            ReservationLogsService reservationLogsService)
        {
            _repository = new Repository(new DataBaseContext());
            _reservationLogsService = reservationLogsService;
        }

        public IQueryable<Reservation> GetAll()
        {
            return _repository.GetAll<Reservation>();
        }

        public void Remove(long bookId)
        {
            if (bookId == default)
            {
                throw new ArgumentNullException($"{typeof(long)}");
            }

            var reservationToRemove = _repository.GetAll<Reservation>()
                .FirstOrDefault(x => x.BookId == bookId);

            if (reservationToRemove == null)
            {
                throw new ApiException("No reservation to remove");
            }

            _repository.Remove(reservationToRemove);

            _reservationLogsService.LogReleased(reservationToRemove.BookId);
        }

        public void Add(long bookId, string comment)
        {
            if (bookId == default || string.IsNullOrEmpty(comment))
            {
                throw new ArgumentNullException(
                    $"{typeof(long)}, {typeof(string)}");
            }

            var hasReservationWithThatBook = _repository.GetAll<Reservation>()
                .Select(x => x.BookId)
                .Any(x => x == bookId);

            if (hasReservationWithThatBook)
            {
                throw new ApiException("This book is already reserved!");
            }

            var newEntity = new Reservation
            {
                BookId = bookId,
                Comment = comment
            };

            _repository.Add(newEntity);

            _reservationLogsService.LogReserved(newEntity.BookId, newEntity.Comment);
        }
    }
}