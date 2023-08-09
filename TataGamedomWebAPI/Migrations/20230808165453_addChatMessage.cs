using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TataGamedomWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class addChatMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatMessage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: true),
                    BackendMemberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ChatMessage_BackendMembers",
                        column: x => x.BackendMemberId,
                        principalTable: "BackendMembers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChatMessage_Members",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_BackendMemberId",
                table: "ChatMessage",
                column: "BackendMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_MemberId",
                table: "ChatMessage",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessage");

        }
    }
}
