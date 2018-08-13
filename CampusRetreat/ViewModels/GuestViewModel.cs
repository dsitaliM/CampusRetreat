using System.Collections.Generic;
using CampusRetreat.Models;

namespace CampusRetreat.ViewModels
{
    public class GuestViewModel
    {
        public IEnumerable<Guest> Guests;
        //public SelectList Names;
        //public SelectList PhoneNumbers;
        //public SelectList Schools;

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AgeGroup { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string School { get; set; }
        public string YearOfStudy { get; set; }
        public string Member { get; set; }
        public string PrayerRequest { get; set; }


        public int NumGuests { get; set; }
        public int NumVisitors { get; set; }
        public int NumMembers { get; set; }
        public int NumWorkers { get; set; }
    }
}