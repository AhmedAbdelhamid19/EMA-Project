using System.ComponentModel.DataAnnotations;

namespace EMA_Project.Models
{
    public class SignUpModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }


        public bool? Gender { get; set; }

        public string Rule { get; set; } = "User";


        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }


        [Range(1, 4, ErrorMessage = "Level must be between 1 and 4.")]
        public int? Level { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Confirm Password is required.")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Confirm Password must be at least 8 characters.")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
