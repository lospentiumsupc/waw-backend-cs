using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAW.API.Migrations
{
    public partial class Chat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chat_room",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    creation_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    last_update_date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_chat_room", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "chat_room_user",
                columns: table => new
                {
                    chat_rooms_id = table.Column<long>(type: "bigint", nullable: false),
                    participants_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_chat_room_user", x => new { x.chat_rooms_id, x.participants_id });
                    table.ForeignKey(
                        name: "f_k_chat_room_user__chat_room_chat_rooms_id",
                        column: x => x.chat_rooms_id,
                        principalTable: "chat_room",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "f_k_chat_room_user__users_participants_id",
                        column: x => x.participants_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "message",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    content = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    sender_id = table.Column<long>(type: "bigint", nullable: false),
                    chat_room_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_message", x => x.id);
                    table.ForeignKey(
                        name: "f_k_message_chat_room_chat_room_id",
                        column: x => x.chat_room_id,
                        principalTable: "chat_room",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "f_k_message_users_sender_id",
                        column: x => x.sender_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "i_x_chat_room_user_participants_id",
                table: "chat_room_user",
                column: "participants_id");

            migrationBuilder.CreateIndex(
                name: "i_x_message_chat_room_id",
                table: "message",
                column: "chat_room_id");

            migrationBuilder.CreateIndex(
                name: "i_x_message_sender_id",
                table: "message",
                column: "sender_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chat_room_user");

            migrationBuilder.DropTable(
                name: "message");

            migrationBuilder.DropTable(
                name: "chat_room");
        }
    }
}
