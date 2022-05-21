using BLL;
using DAL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using TransportCompany.Models;

namespace TransportCompany.Controllers
{
    public class PersonalCabinetController : Controller
    {
        private readonly PassengerDAL _passengerDAL;
        private readonly PassengerBLL _passengerBL;
        private readonly TicketDAL _ticketDAL;
        private readonly TicketBLL _ticketBL;
        private readonly TariffDAL _tariffDAL;
        private readonly TariffBLL _tariffBL;
        private readonly TripDAL _tripDAL;
        private readonly TripBLL _tripBL;
        private readonly IConfiguration _configuration;

        public PersonalCabinetController(IConfiguration configuration)
        {
            _configuration = configuration;
            _passengerDAL = new PassengerDAL(_configuration.GetConnectionString("Database"));
            _passengerBL = new PassengerBLL(_passengerDAL);
            _ticketDAL = new TicketDAL(_configuration.GetConnectionString("Database"));
            _ticketBL = new TicketBLL(_ticketDAL);
            _tariffDAL = new TariffDAL(_configuration.GetConnectionString("Database"));
            _tariffBL = new TariffBLL(_tariffDAL);
            _tripDAL = new TripDAL(_configuration.GetConnectionString("Database"));
            _tripBL = new TripBLL(_tripDAL);
        }

        public IActionResult Index()
        {
            Passenger passenger = _passengerDAL.Get(User.Identity.Name);
            Ticket ticket = _ticketDAL.Get(User.Identity.Name);
            Tariff tariff = _tariffDAL.Get(ticket.IdTariff);
            List<TripViewModel> trips = _tripDAL.GetAllView(User.Identity.Name);
            PersonalCabinetModel personalCabinetModel = new PersonalCabinetModel(passenger, tariff, ticket, trips);

            return View(personalCabinetModel);
        }
    }
}
