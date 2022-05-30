using BLL;
using DAL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace TransportCompany.Controllers
{
    public class WaybillController : Controller
    {
        private readonly WaybillDAL _waybillDAL;
        private readonly WaybillBLL _waybillBL;
        private readonly IConfiguration _configuration;

        public WaybillController(IConfiguration configuration)
        {
            _configuration = configuration;
            _waybillDAL = new WaybillDAL(_configuration.GetConnectionString("Database"));
            _waybillBL = new WaybillBLL(_waybillDAL);
        }
        public IActionResult Index()
        {
            List<Waybill> waybills = _waybillBL.GetWaybills();
            return View(waybills);
        }
    }
}
