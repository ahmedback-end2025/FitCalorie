using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FitCalorie.Models
{
    public class ApplicationUser:IdentityUser
    {
        [PersonalData]
        public string? FullName { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; } 

        public string? Gender { get; set; }

        public int Age { get; set; }


        public double TotalCalorie { get; set; }
        public double TotalCarb { get; set; }
        public double TotalProtein { get; set; }
        public double TotalFat { get; set; }


    }
}
