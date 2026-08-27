using System.ComponentModel.DataAnnotations;

namespace FitCalorie.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;



        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;



        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;


        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; } = string.Empty;

        public string FitnessGoal { get; set; }
        public string Gender { get; set; }






        [Required(ErrorMessage = "Age is required")]
        [Range(10, 100, ErrorMessage = "Age must be between 10 and 100")]
        public int Age { get; set; }


        [Required(ErrorMessage = "Height is required")]
        [Range(100, 250, ErrorMessage = "Height must be between 100cm and 250cm")]
        [Display(Name = "Height (cm)")]
        public double Height { get; set; }


        [Required(ErrorMessage = "Weight is required")]
        [Range(30, 300, ErrorMessage = "Weight must be between 30kg and 300kg")]
        [Display(Name = "Weight (kg)")]
        public double Weight { get; set; }





    }
}