using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyRun.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatedByIdAddedToRunnerProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "RunnerProfiles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RunnerProfiles_CreatedById",
                table: "RunnerProfiles",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_RunnerProfiles_AspNetUsers_CreatedById",
                table: "RunnerProfiles",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RunnerProfiles_AspNetUsers_CreatedById",
                table: "RunnerProfiles");

            migrationBuilder.DropIndex(
                name: "IX_RunnerProfiles_CreatedById",
                table: "RunnerProfiles");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "RunnerProfiles");
        }
    }
}
