using BLL;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TransportCompany.Models;

namespace TransportCompany.Controllers
{
    public class StockController : Controller
    {
        private readonly BusDAL _busDAL;
        private readonly BusBLL _busBL;
        private readonly TrolleybusDAL _trolleybusDAL;
        private readonly TrolleybusBLL _trolleybusBL;
        private readonly IConfiguration _configuration;

        public StockController(IConfiguration configuration)
        {
            _configuration = configuration;
            _busDAL = new BusDAL(_configuration.GetConnectionString("Database"));
            _busBL = new BusBLL(_busDAL);
            _trolleybusDAL = new TrolleybusDAL(_configuration.GetConnectionString("Database"));
            _trolleybusBL = new TrolleybusBLL(_trolleybusDAL);
        }

        public IActionResult Index()
        {
            StockModel stockModel = new StockModel(_busBL.GetBuses(), _trolleybusBL.GetBuses());

            return View(stockModel);
        }

        public IActionResult Instance(string regNum)
        {
            StockModel stockModel = new StockModel(_busBL.GetBus(regNum), _trolleybusBL.GetBus(regNum));

            return View(stockModel);
        }
    }
}
