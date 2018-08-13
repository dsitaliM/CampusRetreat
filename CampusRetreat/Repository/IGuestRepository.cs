using System.Collections.Generic;
using System.Linq;
using CampusRetreat.Models;

namespace CampusRetreat.Repository
{
    public interface IGuestRepository
    {
        void AddGuest(Guest guest);
        void RemoveGuest(int guestId);
        IEnumerable<Guest> FindByName(string name);
        IEnumerable<Guest> FindByPhone(string phone);
        IEnumerable<Guest> FindBySchool(string school);
        Guest GetGuest(int id);
        IQueryable<Guest> GetAllGuests();
        IQueryable<Guest> GeneralSearch(string searchString);
    }
}