using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitCalorie.Models.ViewModels
{
    public class DailyLogsViewModel
    {
        
        public int Id { get; set; }

        public string? UserId { get; set; }
       
       

        public int FoodId { get; set; }
        
        
        public double AmountGrames { get; set; }


        public IEnumerable<SelectListItem>? SelectedList { get; set; } =Enumerable.Empty< SelectListItem>();

    }
}
