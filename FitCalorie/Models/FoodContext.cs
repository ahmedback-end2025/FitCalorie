using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitCalorie.Models
{
    public class FoodContext : IdentityDbContext<ApplicationUser>
    {

        public FoodContext(DbContextOptions<FoodContext> options) : base(options)
        {

        }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<DialyLog> DailyLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Relationships & Foreign Keys
            modelBuilder.Entity<DialyLog>()
                .HasOne(d => d.user)
                .WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DialyLog>()
                .HasOne(d => d.food)
                .WithMany()
                .HasForeignKey(d => d.FoodId)
                .OnDelete(DeleteBehavior.Restrict);

            // 2. Seed Data (Nutrition values per 100g)

            // Seed Data (Nutrition values per 100g)
            modelBuilder.Entity<FoodItem>().HasData(
                // --- Proteins ---
                new FoodItem { Id = 1, Name = "Grilled Chicken Breast", calorie = 165, protein = 31.0, carb = 0.0, fat = 3.6 },
                new FoodItem { Id = 2, Name = "Boiled Egg", calorie = 155, protein = 13.0, carb = 1.1, fat = 11.0 },
                new FoodItem { Id = 3, Name = "Egg Whites", calorie = 52, protein = 11.0, carb = 0.7, fat = 0.2 },
                new FoodItem { Id = 4, Name = "Canned Tuna in Water", calorie = 116, protein = 26.0, carb = 0.0, fat = 1.0 },
                new FoodItem { Id = 5, Name = "Grilled Salmon", calorie = 206, protein = 22.0, carb = 0.0, fat = 12.0 },
                new FoodItem { Id = 6, Name = "Lean Ground Beef (90/10)", calorie = 215, protein = 26.0, carb = 0.0, fat = 12.0 },
                new FoodItem { Id = 7, Name = "Cottage Cheese (Low Fat)", calorie = 72, protein = 12.4, carb = 2.7, fat = 1.0 },
                new FoodItem { Id = 8, Name = "Greek Yogurt (0% Fat)", calorie = 59, protein = 10.0, carb = 3.6, fat = 0.4 },
                new FoodItem { Id = 9, Name = "Whey Protein Powder", calorie = 380, protein = 80.0, carb = 6.0, fat = 3.5 },
                new FoodItem { Id = 10, Name = "Tofu (Firm)", calorie = 76, protein = 8.0, carb = 1.9, fat = 4.8 },

                // --- Carbohydrates ---
                new FoodItem { Id = 11, Name = "Cooked White Rice", calorie = 130, protein = 2.7, carb = 28.2, fat = 0.3 },
                new FoodItem { Id = 12, Name = "Cooked Brown Rice", calorie = 112, protein = 2.6, carb = 23.5, fat = 0.9 },
                new FoodItem { Id = 13, Name = "Raw Oats", calorie = 389, protein = 16.9, carb = 66.3, fat = 6.9 },
                new FoodItem { Id = 14, Name = "Boiled Sweet Potato", calorie = 86, protein = 1.6, carb = 20.1, fat = 0.1 },
                new FoodItem { Id = 15, Name = "Boiled White Potato", calorie = 87, protein = 1.9, carb = 20.1, fat = 0.1 },
                new FoodItem { Id = 16, Name = "Cooked Pasta (White)", calorie = 158, protein = 5.8, carb = 30.9, fat = 0.9 },
                new FoodItem { Id = 17, Name = "Cooked Whole Wheat Pasta", calorie = 124, protein = 5.3, carb = 26.5, fat = 0.5 },
                new FoodItem { Id = 18, Name = "Cooked Lentils", calorie = 116, protein = 9.0, carb = 20.0, fat = 0.4 },
                new FoodItem { Id = 19, Name = "Cooked Chickpeas", calorie = 164, protein = 8.9, carb = 27.4, fat = 2.6 },
                new FoodItem { Id = 20, Name = "Whole Wheat Bread (100g)", calorie = 247, protein = 13.0, carb = 41.0, fat = 3.4 },

                // --- Healthy Fats & Nuts ---
                new FoodItem { Id = 21, Name = "Peanut Butter", calorie = 588, protein = 25.0, carb = 20.0, fat = 50.0 },
                new FoodItem { Id = 22, Name = "Raw Almonds", calorie = 579, protein = 21.2, carb = 21.6, fat = 49.9 },
                new FoodItem { Id = 23, Name = "Raw Walnuts", calorie = 654, protein = 15.2, carb = 13.7, fat = 65.2 },
                new FoodItem { Id = 24, Name = "Fresh Avocado", calorie = 160, protein = 2.0, carb = 8.5, fat = 14.7 },
                new FoodItem { Id = 25, Name = "Olive Oil", calorie = 884, protein = 0.0, carb = 0.0, fat = 100.0 },

                // --- Fruits & Vegetables ---
                new FoodItem { Id = 26, Name = "Banana", calorie = 89, protein = 1.1, carb = 22.8, fat = 0.3 },
                new FoodItem { Id = 27, Name = "Apple", calorie = 52, protein = 0.3, carb = 13.8, fat = 0.2 },
                new FoodItem { Id = 28, Name = "Fresh Strawberries", calorie = 32, protein = 0.7, carb = 7.7, fat = 0.3 },
                new FoodItem { Id = 29, Name = "Steamed Broccoli", calorie = 35, protein = 2.4, carb = 7.2, fat = 0.4 },
                new FoodItem { Id = 30, Name = "Raw Spinach", calorie = 23, protein = 2.9, carb = 3.6, fat = 0.4 }
            );
        }


    }
}
