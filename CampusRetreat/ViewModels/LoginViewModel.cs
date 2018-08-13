using System.ComponentModel.DataAnnotations;

namespace CampusRetreat.ViewModels
{
    public class LoginViewModel
    {
        //Email
        [Required]
        public string LoginToken { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
