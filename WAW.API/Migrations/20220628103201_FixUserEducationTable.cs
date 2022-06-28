using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAW.API.Migrations
{
    public partial class FixUserEducationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "f_k_user_education_users_user_id",
                table: "user_education");

            migrationBuilder.AlterColumn<long>(
                name: "user_id",
                table: "user_education",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "f_k_user_education_users_user_id",
                table: "user_education",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "f_k_user_education_users_user_id",
                table: "user_education");

            migrationBuilder.AlterColumn<long>(
                name: "user_id",
                table: "user_education",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "f_k_user_education_users_user_id",
                table: "user_education",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");
        }
    }
}
