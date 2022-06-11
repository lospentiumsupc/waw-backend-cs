using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAW.API.Migrations
{
    public partial class CreateJobs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder) {
          migrationBuilder.CreateTable(
              name: "jobs",
              columns: table => new {
                id = table.Column<long>(type: "bigint", nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                image = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                description = table.Column<string>(type: "longtext", nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                salaryRange = table.Column<string>(type: "varchar(400)",maxLength: 400, nullable: true),
                status = table.Column<bool>(type: "boolean", nullable: false),

              },
              constraints: table => { table.PrimaryKey("p_k_jobs", x => x.id); }
            )
            .Annotation("MySql:Charset", "utf8mb4");

        }

        protected override void Down(MigrationBuilder migrationBuilder) {
          migrationBuilder.DropTable(name: "jobs");
        }
    }
}
