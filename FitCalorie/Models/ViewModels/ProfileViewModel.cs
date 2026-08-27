using System.ComponentModel.DataAnnotations;

namespace FitCalorie.Models.ViewModels
{
    public class ProfileViewModel
    {
        [Required(ErrorMessage = "Weight is required")]
        [Range(30, 300, ErrorMessage = "Weight must be between 30kg and 300kg")]
        [Display(Name = "Weight (kg)")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Height is required")]
        [Range(100, 250, ErrorMessage = "Height must be between 100cm and 250cm")]
        [Display(Name = "Height (cm)")]
        public double Height { get; set; }

        [Required(ErrorMessage = "Fitness goal is required")]
        public string FitnessGoal { get; set; }
    }
}