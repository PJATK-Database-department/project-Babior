using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketWatch.Server.Data.Migrations
{
    public partial class UserAndCompanyUpd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Companies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Industry",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ApplicationUserId",
                table: "Companies",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_AspNetUsers_ApplicationUserId",
                table: "Companies",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_ApplicationUserId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_ApplicationUserId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Industry",
                table: "Companies");
        }
    }
}
