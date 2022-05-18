using BLL;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace TransportCompany.Controllers
{
    public class TariffController : Controller
    {
        private readonly TariffDAL _tariffDAL;
        private readonly TariffBLL _tariffBL;
        private readonly IConfiguration _configuration;

        public TariffController(IConfiguration configuration)
        {
            _configuration = configuration;
            _tariffDAL = new TariffDAL(_configuration.GetConnectionString("Database"));
            _tariffBL = new TariffBLL(_tariffDAL);
        }

        public IActionResult Index()
        {
            var tariffs = _tariffBL.GetAll();
            return View(tariffs);
        }
    }
}
