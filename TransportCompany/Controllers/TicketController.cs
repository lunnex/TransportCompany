using BLL;
using DAL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using TransportCompany.Models;

namespace TransportCompany.Controllers
{
    public class TicketController : Controller
    {
        private readonly TariffDAL _tariffDAL;
        private readonly TariffBLL _tariffBL;
        private readonly TariffZoneDAL _tariffZoneDAL;
        private readonly TariffZoneBLL _tariffZoneBL;
        private readonly TicketDAL _ticketDAL;
        private readonly TicketBLL _ticketeBL;
        private readonly IConfiguration _configuration;

        public TicketController(IConfiguration configuration)
        {
            _configuration = configuration;
            _tariffDAL = new TariffDAL(_configuration.GetConnectionString("Database"));
            _tariffBL = new TariffBLL(_tariffDAL);
            _tariffZoneDAL = new TariffZoneDAL(_configuration.GetConnectionString("Database"));
            _tariffZoneBL = new TariffZoneBLL(_tariffZoneDAL);
            _ticketDAL = new TicketDAL(_configuration.GetConnectionString("Database"));
            _ticketeBL = new TicketBLL(_ticketDAL);
        }

        public IActionResult Index(int tarifId)
        {
            PurchaseViewModel purchaseViewModel = new(_tariffZoneBL.GetAll(), _tariffBL.Get(tarifId));
            return View(purchaseViewModel);
        }

        [HttpPost]
        public IActionResult Add(string phoneUser, int idTariffZone, int tariffId)
        {
            Tariff tariff = _tariffBL.Get(tariffId);
            Ticket ticket = null;
            if(tariff.ValidityPeriod == null)
            {
                ticket = new Ticket(0, phoneUser, tariff.Id, idTariffZone, DateTime.Now, null, tariff.TripCount);
            }
            else if (tariff.TripCount == null)
            {
                ticket = new Ticket(0, phoneUser, tariff.Id, idTariffZone, DateTime.Now, DateTime.Now.AddHours((double)tariff.ValidityPeriod), null);
            }
            _ticketeBL.Add(ticket);

            return View("Index", "Confirmaion");
        }
    }
}
