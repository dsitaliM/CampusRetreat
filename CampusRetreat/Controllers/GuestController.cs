using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CampusRetreat.Extensions;
using CampusRetreat.Helpers;
using CampusRetreat.Models;
using CampusRetreat.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusRetreat.Controllers
{
    [Authorize]
    public class GuestController : Controller
    {
        private readonly IGuestRepository _guestsGuestRepository;
        public GuestController(IGuestRepository guestRepository)
        {
            _guestsGuestRepository = guestRepository;
            
        }
        public async Task<IActionResult> Index(string sortString, string searchString, string currentFilter, int? page)
        {
            ViewData["SortByName"] = string.IsNullOrEmpty(sortString) ? "descendName" : "";
            ViewData["SortBySchool"] = sortString == "school" ? "descendSchool" : "school";
            ViewData["currentFilter"] = searchString;

            ViewData["CurrentSort"] = sortString;

            ViewData["CountAll"] = _guestsGuestRepository.GetAllGuests().Count();
            ViewData["CountVisitors"] = _guestsGuestRepository
                .GetAllGuests()
                .Count(guest => guest.Member == "visitor");
            ViewData["CountWorkers"] = _guestsGuestRepository
                .GetAllGuests()
                .Count(guest => guest.Member == "worker");

            ViewData["CountMembers"] = _guestsGuestRepository
                .GetAllGuests()
                .Count(guest => guest.Member == "member");

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            IQueryable<Guest> guests = _guestsGuestRepository.GetAllGuests();

            if (!string.IsNullOrEmpty(searchString))
            {
                guests = _guestsGuestRepository.GeneralSearch(searchString);
            }

            switch (sortString)
            {
                case "descendName":
                    guests = guests.OrderBy(guest => guest.FirstName);
                    break;
                case "school":
                    guests = guests.OrderByDescending(guest => guest.School);
                    break;
                default:
                    guests = guests.OrderBy(guest => guest.LastName);
                    break;  
            }

            #region Guest ViewModel
            //var guestVM = guests
            //    .Select(guest => new Guest()
            //    {
            //        Id = guest.Id,
            //        FirstName = guest.FirstName,
            //        LastName = guest.LastName,
            //        AgeGroup = guest.AgeGroup,
            //        Gender = guest.Gender,
            //        MaritalStatus = guest.MaritalStatus,
            //        Phone = guest.Phone,
            //        Email = guest.Email,
            //        School = guest.School,
            //        YearOfStudy = guest.YearOfStudy,
            //        Member = guest.Member,
            //        PrayerRequest = guest.PrayerRequest,



            //    }); 
            #endregion

            const int pageSize = 10;
            return View(await PaginatedList<Guest>.CreateAsync(guests.AsNoTracking(), page ?? 1, pageSize));
        }

        public FileStreamResult ExportToCsv()
        {
            var result = ExportTable.WriteCsvToMemory(_guestsGuestRepository.GetAllGuests());
            var memoryStream = new MemoryStream(result);
            return new FileStreamResult(memoryStream, "text/csv") { FileDownloadName = "guests.csv"};
        }

        #region OtherSearchMethods
        //[HttpGet]
        //public IActionResult FindByName(string name)
        //{
        //    if (string.IsNullOrEmpty(name))
        //    {
        //        return Index();
        //    }
        //    var results = _guestsGuestRepository.FindByName(name);
        //    return View("Index", results);
        //}

        //[HttpGet]
        //public IActionResult FindBySchool(string school)
        //{
        //    if (string.IsNullOrEmpty(school))
        //    {
        //        return Index();
        //    }
        //    var results = _guestsGuestRepository.FindBySchool(school);
        //    return View("Index", results);
        //}

        //[HttpGet]
        //public IActionResult FindByPhone(string phone)
        //{
        //    if (string.IsNullOrEmpty(phone))
        //    {
        //        return Index();
        //    }
        //    var results = _guestsGuestRepository.FindByPhone(phone);
        //    return View("Index", results);
        //}

        //public IActionResult SearchAction(string searchField, string searchString)
        //{
        //    switch (searchField)
        //    {
        //        case "byName":
        //            return FindByName(searchString);
        //        case "byPhone":
        //            return FindByPhone(searchString);
        //        case "bySchool":
        //            return FindBySchool(searchString);
        //        case null:
        //            return View("Index");
        //    }

        //    return View("Index");

        //} 
        #endregion

        public IActionResult DeleteGuest(int guestId)
        {
            _guestsGuestRepository.RemoveGuest(guestId);
            return RedirectToAction("Index");
        }

    }
}