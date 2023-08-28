using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TataGamedomWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderShipmentInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactEmails",
                table: "Orders",
                newName: "ReceiverEmail");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverCellPhone",
                table: "Orders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverCellPhone",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ReceiverEmail",
                table: "Orders",
                newName: "ContactEmails");
        }
    }
}
