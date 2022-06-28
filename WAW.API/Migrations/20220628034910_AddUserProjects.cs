using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAW.API.Migrations
{
    public partial class AddUserProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_projects",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    summary = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    image_id = table.Column<long>(type: "bigint", nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_user_projects", x => x.id);
                    table.ForeignKey(
                        name: "f_k_user_projects_images_image_id",
                        column: x => x.image_id,
                        principalTable: "images",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "f_k_user_projects_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "i_x_user_projects_image_id",
                table: "user_projects",
                column: "image_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "i_x_user_projects_user_id",
                table: "user_projects",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_projects");
        }
    }
}
