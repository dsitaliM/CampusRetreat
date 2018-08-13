using System.ComponentModel.DataAnnotations;

namespace CampusRetreat.Models
{
    public class Guest
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "Full Name")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Please Indicate your age group")]
        public string AgeGroup { get; set; }

        [Required(ErrorMessage = "Please Indicate your gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please Indicate your marital status")]
        public string MaritalStatus { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string Phone { get; set; }
        
        public string Email { get; set; }
        public string School { get; set; }

        public string YearOfStudy { get; set; }
        
        [Required(ErrorMessage = "Please indicate your membership status")]
        public string Member { get; set; }
        
        public string PrayerRequest { get; set; }
    }
}