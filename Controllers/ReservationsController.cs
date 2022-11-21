using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestWebApi.Models;
using TestWebApi.Services;

namespace TestWebApi.Controllers
{
    [ApiController]
    [Route("reservations/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly ReservationsService _reservationService;

        public ReservationsController(ReservationsService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet(Name = "GetAllReservations")]
        public List<Reservation> GetAllReservations()
        {
            return _reservationService.GetAll()
                .ToList();
        }

        [HttpPost("PostReservation")]
        public void PostReservation(long bookId, string comment)
        {
            _reservationService.Add(bookId, comment);
        }

        [HttpPost("RemoveReservation")]
        public void RemoveReservation(long bookId)
        {
            _reservationService.Remove(bookId);
        }
    }
}