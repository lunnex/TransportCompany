using BLL;
using DAL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace TransportCompany.Controllers
{
    public class PersonalCabinetController : Controller
    {
        private readonly PassengerDAL _passengerDAL;
        private readonly PassengerBLL _passengerBL;
        private readonly TicketDAL _ticketDAL;
        private readonly TicketBLL _ticketBL;
        private readonly IConfiguration _configuration;

        public PersonalCabinetController(IConfiguration configuration)
        {
            _configuration = configuration;
            _passengerDAL = new PassengerDAL(_configuration.GetConnectionString("Database"));
            _passengerBL = new PassengerBLL(_passengerDAL);
            _ticketDAL = new TicketDAL(_configuration.GetConnectionString("Database"));
            _ticketBL = new TicketBLL(_ticketDAL);
        }

        public IActionResult Index()
        {
            Passenger passenger = _passengerDAL.Get(User.Identity.Name);
            return View(passenger);
        }
    }
}
