using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StajProject2.Controllers
{
    [Route("[Controller]/[action]")]
    public class AppUserController : Controller
    {
        private readonly IAppUserService _userService;

        public AppUserController(IAppUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index(string searchString)
        {
            ViewBag.CurrentFilter = searchString;

            var users = _userService.TGetList();

            if (!string.IsNullOrEmpty(searchString))
            {
                int searchNumber;
                bool isNumber = int.TryParse(searchString, out searchNumber);

                if (isNumber)
                {
                    users = users.Where(u => u.CustomerNumber == searchNumber || u.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                else
                {
                    users = users.Where(u => u.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                if (users.Count < 1)
                {
                    TempData["ErrorMessage"] = "Müşteri bulunamadı, lütfen müşteriyi oluşturun.";
                    return RedirectToAction("CreateAppUser");
                }
            }

            return View(users);
        }



        [HttpGet]
        public IActionResult CreateAppUser()
        {
            if (TempData["ErrorMessage"] != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
            }
            return View();
        }

        [HttpPost]
        public IActionResult CreateAppUser(Customer appUser)
        {
            try
            {
                Random random = new Random();
                appUser.CustomerNumber = random.Next(1000, 10000);
                _userService.TAdd(appUser);
                return Json(new { success = true, customerNumber = appUser.CustomerNumber });
            }
            catch (InvalidOperationException ex)
            {
                // TC kimlik numarası zaten mevcutsa hata mesajı dön
                return Json(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                // Diğer hatalar için genel hata mesajı dön
                return Json(new { success = false, message = "Bir hata oluştu. Lütfen tekrar deneyin." });
            }
        }



        [HttpGet]
        public IActionResult UpdateAppUser(int id)
        {
            var values = _userService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateAppUser(Customer appUser)
        {
            _userService.TUpdate(appUser);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteAppUser(int id)
        {
            var values = _userService.TGetByID(id);
            _userService.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
