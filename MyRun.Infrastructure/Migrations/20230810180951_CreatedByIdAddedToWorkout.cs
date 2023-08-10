using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyRun.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatedByIdAddedToWorkout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Workouts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_CreatedById",
                table: "Workouts",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_AspNetUsers_CreatedById",
                table: "Workouts",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_AspNetUsers_CreatedById",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_CreatedById",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Workouts");
        }
    }
}
