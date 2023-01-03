using System.ComponentModel.DataAnnotations;

namespace RideShareAPI.Models
{
    public class RegisterUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = " Provide a valid password ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirm passwords do not match")]
        public string ConfirmPassword { get; set; }

        public long Phone { get; set; }
    }
}
