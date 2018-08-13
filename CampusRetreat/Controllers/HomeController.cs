using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CampusRetreat.Models;
using CampusRetreat.Repository;
using Microsoft.AspNetCore.Authorization;

namespace CampusRetreat.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGuestRepository _guestsGuestRepository;

        public HomeController(IGuestRepository guestRepository)
        {
            _guestsGuestRepository = guestRepository;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Success()
        {
            return View("Okay");
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Guest guest)
        {
            if (ModelState.IsValid)
            {
                _guestsGuestRepository.AddGuest(guest);
                return Success();
            }

            return View();
        }

        [HttpGet]
        public IActionResult Details() => View();

        [HttpGet]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}