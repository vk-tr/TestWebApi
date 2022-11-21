using System;
using TestWebApi.Contexts;
using TestWebApi.Helpers;
using TestWebApi.Models;

namespace TestWebApi.Services
{
    public class ReservationLogsService
    {
        private readonly Repository _repository;

        public ReservationLogsService()
        {
            _repository = new Repository(new DataBaseContext());
        }

        public void LogReserved(long bookId, string comment)
        {
            var reservationLog = new ReservationLog
            {
                BookId = bookId,
                DateTime = DateTime.Now,
                Status = ReservationStatus.Reserved,
                Comment = comment
            };

            _repository.Add(reservationLog);
        }

        public void LogReleased(long bookId)
        {
            var reservationLog = new ReservationLog
            {
                BookId = bookId,
                DateTime = DateTime.Now,
                Status = ReservationStatus.Free
            };

            _repository.Add(reservationLog);
        }
    }
}