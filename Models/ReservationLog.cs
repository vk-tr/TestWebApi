using System;
using TestWebApi.Helpers;
using TestWebApi.Interfaces;

namespace TestWebApi.Models
{
    public class ReservationLog : IHaveId
    {
        public long Id { get; set; }

        public long BookId { get; set; }

        public ReservationStatus Status { get; set; }

        public DateTime DateTime { get; set; }

        public string? Comment { get; set; }
    }
}