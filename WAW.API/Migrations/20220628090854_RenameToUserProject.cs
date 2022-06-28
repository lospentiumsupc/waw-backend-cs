using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAW.API.Migrations {
  public partial class RenameToUserProject : Migration {
    protected override void Up(MigrationBuilder migrationBuilder) {
      migrationBuilder.DropForeignKey(
        name: "f_k_user_projects_images_image_id",
        table: "user_projects");

      migrationBuilder.DropForeignKey(
        name: "f_k_user_projects_users_user_id",
        table: "user_projects");

      migrationBuilder.DropIndex(
        name: "i_x_user_projects_image_id",
        table: "user_projects");

      migrationBuilder.DropIndex(
        name: "i_x_user_projects_user_id",
        table: "user_projects");

      migrationBuilder.RenameTable(
        name: "user_projects",
        newName: "user_project");

      migrationBuilder.CreateIndex(
        name: "i_x_user_project_image_id",
        table: "user_project",
        column: "image_id",
        unique: true);

      migrationBuilder.CreateIndex(
        name: "i_x_user_project_user_id",
        table: "user_project",
        column: "user_id");

      migrationBuilder.AddForeignKey(
        name: "f_k_user_project_images_image_id",
        table: "user_project",
        column: "image_id",
        principalTable: "images",
        principalColumn: "id",
        onDelete: ReferentialAction.Cascade);

      migrationBuilder.AddForeignKey(
        name: "f_k_user_project_users_user_id",
        table: "user_project",
        column: "user_id",
        principalTable: "users",
        principalColumn: "id",
        onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder) {
      migrationBuilder.DropForeignKey(
        name: "f_k_user_project_images_image_id",
        table: "user_project");

      migrationBuilder.DropForeignKey(
        name: "f_k_user_project_users_user_id",
        table: "user_project");

      migrationBuilder.DropIndex(
        name: "i_x_user_project_image_id",
        table: "user_project");

      migrationBuilder.DropIndex(
        name: "i_x_user_project_user_id",
        table: "user_project");

      migrationBuilder.RenameTable(
        name: "user_project",
        newName: "user_projects");

      migrationBuilder.CreateIndex(
        name: "i_x_user_projects_image_id",
        table: "user_projects",
        column: "image_id",
        unique: true);

      migrationBuilder.CreateIndex(
        name: "i_x_user_projects_user_id",
        table: "user_projects",
        column: "user_id");

      migrationBuilder.AddForeignKey(
        name: "f_k_user_projects_images_image_id",
        table: "user_projects",
        column: "image_id",
        principalTable: "images",
        principalColumn: "id",
        onDelete: ReferentialAction.Cascade);

      migrationBuilder.AddForeignKey(
        name: "f_k_user_projects_users_user_id",
        table: "user_projects",
        column: "user_id",
        principalTable: "users",
        principalColumn: "id",
        onDelete: ReferentialAction.Cascade);
    }
  }
}
