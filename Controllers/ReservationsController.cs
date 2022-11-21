using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using TestWebApi.Exceptions;
using TestWebApi.Helpers;
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
        public Reservation[] GetAllReservations()
        {
            return _reservationService.GetAll()
                .ToArray();
        }

        [HttpPost("PostReservation")]
        public HttpResponseMessage PostReservation(long bookId, string comment)
        {
            return ResponseHelper.ThrowCatch(
                () => _reservationService.Add(bookId, comment));
        }

        [HttpPost("RemoveReservation")]
        public HttpResponseMessage RemoveReservation(long bookId)
        {
            return ResponseHelper.ThrowCatch(
                () => _reservationService.Remove(bookId));
        }
    }
}