using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TataGamedomWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class adjustOrderItemReturnIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__OrderItem__Order__4B7734FF",
                table: "OrderItemReturns");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderItem__Order__503BEA1C",
                table: "OrderItemsCoupons");

            migrationBuilder.AlterColumn<string>(
                name: "Index",
                table: "OrderItemReturns",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK__OrderItem__Order__4B7734FF",
                table: "OrderItemReturns",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__OrderItem__Order__503BEA1C",
                table: "OrderItemsCoupons",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__OrderItem__Order__4B7734FF",
                table: "OrderItemReturns");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderItem__Order__503BEA1C",
                table: "OrderItemsCoupons");

            migrationBuilder.AlterColumn<string>(
                name: "Index",
                table: "OrderItemReturns",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK__OrderItem__Order__4B7734FF",
                table: "OrderItemReturns",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderItem__Order__503BEA1C",
                table: "OrderItemsCoupons",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id");
        }
    }
}
