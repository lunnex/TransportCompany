using BLL;
using DAL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Configuration;

namespace TransportCompany.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly PassengerDAL _passengerDAL;
        private readonly PassengerBLL _passengerBL;
        private readonly IConfiguration _configuration;

        public RegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
            _passengerDAL = new PassengerDAL(_configuration.GetConnectionString("Database"));
            _passengerBL = new PassengerBLL(_passengerDAL);
        }

        public IActionResult Index()
        {
            //var tariffs = _passengerBL.GetAll();
            return View();
        }

        public IActionResult CheckPK(string phoneNumber)
        {
            if (_passengerDAL.Get(phoneNumber) != null)
                return Json(false);
            return Json(true);
        }

        public IActionResult Add(string phoneNumber, string password, string firstName, string secondName, string patronym, DateTime birthDate)
        {
            Passenger passenger = null;

            if (ModelState.IsValid)
            {
                passenger = new Passenger(phoneNumber, password, firstName, secondName, patronym, birthDate);
                _passengerDAL.Add(passenger);

                return RedirectToAction("Login", "Login", passenger);
            }
            else
            {
                return RedirectToAction("Index", passenger);
            }
            
        }
    }
}
