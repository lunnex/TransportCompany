using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TransportCompany.Models;

namespace TransportCompany.Controllers
{
    public class PurchaseHistoryController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly PurchseDAL _passengerDAL;

        public PurchaseHistoryController(IConfiguration configuration)
        {
            _configuration = configuration;
            _passengerDAL = new PurchseDAL(_configuration.GetConnectionString("Database"));
        }

        public IActionResult Index()
        {
            PurchaseHistoryModel purchaseHistoryModel = new PurchaseHistoryModel(_passengerDAL.GetPurchases(User.Identity.Name));

            return View(purchaseHistoryModel);
        }
    }
}
