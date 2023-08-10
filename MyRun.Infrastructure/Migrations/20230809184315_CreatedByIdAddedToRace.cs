using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyRun.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatedByIdAddedToRace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Races",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Races_CreatedById",
                table: "Races",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Races_AspNetUsers_CreatedById",
                table: "Races",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Races_AspNetUsers_CreatedById",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Races_CreatedById",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Races");        
        }
    }
}
