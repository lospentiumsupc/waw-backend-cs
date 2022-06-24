using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAW.API.Migrations
{
    public partial class UpdateOffersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "p_k_offer",
                table: "offer");

            migrationBuilder.RenameTable(
                name: "offer",
                newName: "offers");

            migrationBuilder.AddPrimaryKey(
                name: "p_k_offers",
                table: "offers",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "p_k_offers",
                table: "offers");

            migrationBuilder.RenameTable(
                name: "offers",
                newName: "offer");

            migrationBuilder.AddPrimaryKey(
                name: "p_k_offer",
                table: "offer",
                column: "id");
        }
    }
}
