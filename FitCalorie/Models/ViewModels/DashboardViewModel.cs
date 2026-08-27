namespace FitCalorie.Models.ViewModels
{
    public class DashboardViewModel
    {
        
        public double TotalCalories { get; set; }
        public double TotalProtein { get; set; }
        public double TotalCarbs { get; set; }
        public double TotalFats { get; set; }

        
        public double TargetCalories { get; set; } = 2500;
        public double TargetProtein { get; set; } = 150;
        public double TargetCarbs { get; set; } = 250;
        public double TargetFats { get; set; } = 70;

        
        public int CaloriesPercent => TargetCalories > 0 ? (int)Math.Min((TotalCalories / TargetCalories) * 100, 100) : 0;
        public int ProteinPercent => TargetProtein > 0 ? (int)Math.Min((TotalProtein / TargetProtein) * 100, 100) : 0;
        public int CarbsPercent => TargetCarbs > 0 ? (int)Math.Min((TotalCarbs / TargetCarbs) * 100, 100) : 0;
        public int FatsPercent => TargetFats > 0 ? (int)Math.Min((TotalFats / TargetFats) * 100, 100) : 0;

        
        public List<DailyLogItemViewModel> LoggedMeals { get; set; } = new();
    }
}
