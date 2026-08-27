using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitCalorie.Models
{
    public class DailyLog
    {
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public virtual ApplicationUser user { get; set; }

        public int FoodId { get; set; }
        [ForeignKey("FoodId")]
        [ValidateNever]
        public virtual FoodItem food {get;set;}

        public double AmountGrames { get; set; }


        [NotMapped]
        public double TotalCalorie => food != null ? food.calorie * (AmountGrames / 100.0) : 0;
        [NotMapped]
        public double TotalFat =>food!=null? food.fat * (AmountGrames / 100.0) : 0;
        [NotMapped]
        public double TotalCarb =>food!=null? food.carb * (AmountGrames / 100.0) : 0;
        [NotMapped]
        public double TotalProtein =>food!=null? food.protein * (AmountGrames / 100.0) : 0;

    }
}
