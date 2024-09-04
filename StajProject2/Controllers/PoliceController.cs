using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace StajProject2.Controllers
{
    [Route("[Controller]/[action]")]
    public class PoliceController : Controller
    {
        private readonly IAppUserService _userService;
        private readonly IPoliceService _policeService;

        public PoliceController(IAppUserService userService, IPoliceService policeService)
        {
            _userService = userService;
            _policeService = policeService;
        }

        public IActionResult Index()
        {
            var result = _policeService.TPoliceRide();
            return View(result);
        }

        [HttpGet("{id}")]
        public IActionResult PoliceRide(int id)
        {
            var appUser = _userService.TGetByID(id);
            if (appUser == null)
            {
                return NotFound();
            }

            // Kullanıcı adını ViewBag'e atıyoruz
            ViewBag.CustomerName = appUser.FirstName + " " + appUser.LastName;

            return View();
        }

        [HttpGet]
        public IActionResult GetVehicleInfo(int vehicleBrandCode)
        {
            // Örnek veri: Gerçek veri kaynağınızdan çekebilirsiniz
            var vehicleInfo = new Dictionary<int, (string Brand, string Model)>
                {
                    { 1, ("Opel", "Astra") },
                    { 2, ("Ford", "Focus") },
                    { 3, ("Toyota", "Corolla") }
            };

            if (vehicleInfo.TryGetValue(vehicleBrandCode, out var info))
            {
                return Json(new { Brand = info.Brand, Model = info.Model });
            }
            else
            {
                return Json(new { Brand = "", Model = "" });
            }
        }


        [HttpPost("{id}")]
        public IActionResult PoliceRide(Police police, int id)
        {
            try
            {

                ViewBag.TotalPrice = _policeService.CalculatePolicyAmount(police);

                var appUser = _userService.TGetByID(id);
                if (appUser == null)
                {
                    return NotFound();
                }

                //if (ModelState.IsValid)
                //{
                police.CustomerID = id;
                _policeService.TAdd(police);
                return RedirectToAction("Index");
                //}

                //return View(police);
            }
            catch (Exception ex)
            {
                // Hata mesajını loglayabilir veya kullanıcıya gösterebilirsiniz
                ModelState.AddModelError("", "Bir hata oluştu: " + ex.Message);
                return View(police);
            }
        }
    }
}