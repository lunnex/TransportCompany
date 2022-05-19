using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TransportCompany.Models;

namespace TransportCompany.Controllers
{
    public class ConfirmationController : Controller
    {
        public IActionResult Index(SerializedPurchase serializedPurchase)
        {
            PurchaseViewModel purchaseViewModel = JsonSerializer.Deserialize<PurchaseViewModel>(serializedPurchase.Serialized);
            return View(purchaseViewModel);
        }
    }
}
