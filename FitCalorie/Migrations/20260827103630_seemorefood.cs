using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitCalorie.Migrations
{
    /// <inheritdoc />
    public partial class seemorefood : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "calorie", "carb", "fat", "protein" },
                values: new object[] { "Boiled Egg", 155.0, 1.1000000000000001, 11.0, 13.0 });

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "calorie", "carb", "fat", "protein" },
                values: new object[] { "Egg Whites", 52.0, 0.69999999999999996, 0.20000000000000001, 11.0 });

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "calorie", "carb", "fat", "protein" },
                values: new object[] { "Canned Tuna in Water", 116.0, 0.0, 1.0, 26.0 });

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "calorie", "carb", "fat", "protein" },
                values: new object[] { "Grilled Salmon", 206.0, 0.0, 12.0, 22.0 });

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "calorie", "fat" },
                values: new object[] { "Lean Ground Beef (90/10)", 215.0, 12.0 });

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Name", "calorie", "carb", "fat", "protein" },
                values: new object[] { "Cottage Cheese (Low Fat)", 72.0, 2.7000000000000002, 1.0, 12.4 });

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Name", "calorie", "carb", "fat", "protein" },
                values: new object[] { "Greek Yogurt (0% Fat)", 59.0, 3.6000000000000001, 0.40000000000000002, 10.0 });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "Id", "Name", "calorie", "carb", "fat", "protein" },
                values: new object[,]
                {
                    { 9, "Whey Protein Powder", 380.0, 6.0, 3.5, 80.0 },
                    { 10, "Tofu (Firm)", 76.0, 1.8999999999999999, 4.7999999999999998, 8.0 },
                    { 11, "Cooked White Rice", 130.0, 28.199999999999999, 0.29999999999999999, 2.7000000000000002 },
                    { 12, "Cooked Brown Rice", 112.0, 23.5, 0.90000000000000002, 2.6000000000000001 },
                    { 13, "Raw Oats", 389.0, 66.299999999999997, 6.9000000000000004, 16.899999999999999 },
                    { 14, "Boiled Sweet Potato", 86.0, 20.100000000000001, 0.10000000000000001, 1.6000000000000001 },
                    { 15, "Boiled White Potato", 87.0, 20.100000000000001, 0.10000000000000001, 1.8999999999999999 },
                    { 16, "Cooked Pasta (White)", 158.0, 30.899999999999999, 0.90000000000000002, 5.7999999999999998 },
                    { 17, "Cooked Whole Wheat Pasta", 124.0, 26.5, 0.5, 5.2999999999999998 },
                    { 18, "Cooked Lentils", 116.0, 20.0, 0.40000000000000002, 9.0 },
                    { 19, "Cooked Chickpeas", 164.0, 27.399999999999999, 2.6000000000000001, 8.9000000000000004 },
                    { 20, "Whole Wheat Bread (100g)", 247.0, 41.0, 3.3999999999999999, 13.0 },
                    { 21, "Peanut Butter", 588.0, 20.0, 50.0, 25.0 },
                    { 22, "Raw Almonds", 579.0, 21.600000000000001, 49.899999999999999, 21.199999999999999 },
                    { 23, "Raw Walnuts", 654.0, 13.699999999999999, 65.200000000000003, 15.199999999999999 },
                    { 24, "Fresh Avocado", 160.0, 8.5, 14.699999999999999, 2.0 },
                    { 25, "Olive Oil", 884.0, 0.0, 100.0, 0.0 },
                    { 26, "Banana", 89.0, 22.800000000000001, 0.29999999999999999, 1.1000000000000001 },
                    { 27, "Apple", 52.0, 13.800000000000001, 0.20000000000000001, 0.29999999999999999 },
                    { 28, "Fresh Strawberries", 32.0, 7.7000000000000002, 0.29999999999999999, 0.69999999999999996 },
                    { 29, "Steamed Broccoli", 35.0, 7.2000000000000002, 0.40000000000000002, 2.3999999999999999 },
                    { 30, "Raw Spinach", 23.0, 3.6000000000000001, 0.40000000000000002, 2.8999999999999999 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "calorie", "carb", "fat", "protein" },
                values: new object[] { "Cooked White Rice", 130.0, 28.199999999999999, 0.29999999999999999, 2.7000000000000002 });

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "calorie", "carb", "fat", "protein" },
                values: new object[] { "Raw Oats", 389.0, 66.299999999999997, 6.9000000000000004, 16.899999999999999 });

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "calorie", "carb", "fat", "protein" },
                values: new object[] { "Boiled Egg", 155.0, 1.1000000000000001, 11.0, 13.0 });

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "calorie", "carb", "fat", "protein" },
                values: new object[] { "Peanut Butter", 588.0, 20.0, 50.0, 25.0 });

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "calorie", "fat" },
                values: new object[] { "Canned Tuna in Water", 116.0, 1.0 });

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Name", "calorie", "carb", "fat", "protein" },
                values: new object[] { "Banana", 89.0, 22.800000000000001, 0.29999999999999999, 1.1000000000000001 });

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Name", "calorie", "carb", "fat", "protein" },
                values: new object[] { "Boiled Sweet Potato", 86.0, 20.100000000000001, 0.10000000000000001, 1.6000000000000001 });
        }
    }
}
