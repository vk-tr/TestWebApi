using TestWebApi.Interfaces;

namespace TestWebApi.Models
{
    public class Reservation
        : IHaveId
    {
        public long Id { get; set; }

        public long BookId { get; set; }

        public string Comment { get; set; }
    }
}