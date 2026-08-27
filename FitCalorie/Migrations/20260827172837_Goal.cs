using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitCalorie.Migrations
{
    /// <inheritdoc />
    public partial class Goal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FitnessGoal",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FitnessGoal",
                table: "AspNetUsers");
        }
    }
}
