namespace FitCalorie.Models.ViewModels
{
    public class DailyLogItemViewModel
    {
        public int LogId { get; set; }
        public string FoodName { get; set; } = string.Empty;
        public double AmountGrams { get; set; }
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fats { get; set; }
    }
}
