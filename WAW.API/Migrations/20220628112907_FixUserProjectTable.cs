using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAW.API.Migrations
{
    public partial class FixUserProjectTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "f_k_user_project_users_user_id",
                table: "user_project");

            migrationBuilder.AlterColumn<long>(
                name: "user_id",
                table: "user_project",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "f_k_user_project_users_user_id",
                table: "user_project",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "f_k_user_project_users_user_id",
                table: "user_project");

            migrationBuilder.AlterColumn<long>(
                name: "user_id",
                table: "user_project",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "f_k_user_project_users_user_id",
                table: "user_project",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");
        }
    }
}
