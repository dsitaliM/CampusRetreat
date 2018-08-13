using System.Collections.Generic;
using System.Linq;
using CampusRetreat.Models;

namespace CampusRetreat.Repository
{
    public class GuestService : IGuestRepository
    {
        private readonly CampusRetreatContext _context;

        public GuestService(CampusRetreatContext context)
        {
            _context = context;
        }
        
        public void AddGuest(Guest guest)
        {
            _context.Add(guest);
            _context.SaveChanges();
        }

        public void RemoveGuest(int guestId)
        {
            _context.Remove(GetGuest(guestId));
            _context.SaveChanges();
        }

        public IEnumerable<Guest> FindByName(string name)
        {
            return GetAllGuests()
                .Where(guest => guest.FirstName.Contains(name) || guest.LastName.Contains(name));
        }

        public IEnumerable<Guest> FindByPhone(string phone)
        {
            return GetAllGuests()
                .Where(guest => guest.Phone.Contains(phone));
        }

        public IEnumerable<Guest> FindBySchool(string school)
        {
            return GetAllGuests()
                .Where(guest => guest.School.Contains(school));
        }

        public Guest GetGuest(int id)
        {
            var guest = GetAllGuests()
                .FirstOrDefault(gst => gst.Id == id);
            return guest;
        }

        public IQueryable<Guest> GetAllGuests()
        {
            return _context.Guests;
        }

        public IQueryable<Guest> GeneralSearch(string searchString)
        {
            return GetAllGuests()
                .Where(guest => guest.FirstName.ToLower().Contains(searchString)
                                || guest.LastName.ToLower().Contains(searchString)
                                || guest.School.ToLower().Contains(searchString)
                                || guest.Member.ToLower().Contains(searchString)
                                || guest.Phone.Contains(searchString));
        }
    }
}