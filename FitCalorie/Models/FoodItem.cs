using System.ComponentModel.DataAnnotations;

namespace FitCalorie.Models
{
    public class FoodItem
    {
        [Key]
        int Id { get; set; }

        [Required]
        public string Name { get; set; }
        //per 100 g 
        public double calorie { get; set; }
        public double protein { get; set; }
        public double carb { get; set; }
        public double fat { get; set; }

        
    }
}
