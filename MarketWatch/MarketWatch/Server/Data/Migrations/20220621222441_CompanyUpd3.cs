using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketWatch.Server.Data.Migrations
{
    public partial class CompanyUpd3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Brandings_BrandingId",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "Brandings");

            migrationBuilder.DropIndex(
                name: "IX_Companies_BrandingId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "BrandingId",
                table: "Companies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandingId",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brandings",
                columns: table => new
                {
                    BrandingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brandings", x => x.BrandingId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_BrandingId",
                table: "Companies",
                column: "BrandingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Brandings_BrandingId",
                table: "Companies",
                column: "BrandingId",
                principalTable: "Brandings",
                principalColumn: "BrandingId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
