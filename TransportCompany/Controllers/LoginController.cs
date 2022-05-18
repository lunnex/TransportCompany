using BLL;
using DAL;
using Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TransportCompany.Controllers
{
    public class LoginController : Controller
    {
        private readonly PassengerDAL _passengerDAL;
        private readonly PassengerBLL _passengerBL;
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
            _passengerDAL = new PassengerDAL(_configuration.GetConnectionString("Database"));
            _passengerBL = new PassengerBLL(_passengerDAL);
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(string phoneNumber, string password)
        {
            Passenger passenger = _passengerDAL.Get(phoneNumber);

            if (passenger != null && Passenger.HashPass(password) == passenger.Password)
            {
                //_signInManager.SignInAsync(passenger, false);
                var claims = new List<Claim>
                {
                new Claim(ClaimsIdentity.DefaultNameClaimType, phoneNumber)
                };
                // создаем объект ClaimsIdentity
                ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                // установка аутентификационных куки
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));

                return RedirectToAction("Index", "PersonalCabinet");

            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync();

            return RedirectToAction("Index");
        }
    }
}
