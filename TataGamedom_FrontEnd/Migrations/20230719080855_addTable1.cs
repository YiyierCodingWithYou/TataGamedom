using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TataGamedom_FrontEnd.Migrations
{
    public partial class addTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Table1",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false),
                   Name = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
               },
               constraints: table =>
               {
               });
        }

          

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Table1");
 
        }
    }
}
