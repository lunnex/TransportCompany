using BLL;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace TransportCompany.Controllers
{
    public class TariffZonesController : Controller
    {

        private readonly TariffZoneDAL _tariffZoneDAL;
        private readonly TariffZoneBLL _tariffZoneBL;
        private readonly IConfiguration _configuration;

        public TariffZonesController(IConfiguration configuration)
        {
            _configuration = configuration;
            _tariffZoneDAL = new TariffZoneDAL(_configuration.GetConnectionString("Database"));
            _tariffZoneBL = new TariffZoneBLL(_tariffZoneDAL);
        }
        public IActionResult Index()
        {
            return View(_tariffZoneBL.GetAll());
        }
    }
}
