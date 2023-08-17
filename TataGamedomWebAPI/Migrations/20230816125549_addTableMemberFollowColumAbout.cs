using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TataGamedomWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class addTableMemberFollowColumAbout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
            name: "AboutMe",
            table: "Members",
            type: "nvarchar(500)",
            maxLength: 500,
            nullable: true);

            migrationBuilder.CreateTable(
            name: "MemberFollows",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                FollowerMemberId = table.Column<int>(type: "int", nullable: true),
                FollowedMemberId = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK__MemberFo__3213E83FCB3F974F", x => x.Id);
                table.ForeignKey(
                    name: "FK__MemberFol__follo__54CB950F",
                    column: x => x.FollowerMemberId,
                    principalTable: "Members",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK__MemberFol__follo__55BFB948",
                    column: x => x.FollowedMemberId,
                    principalTable: "Members",
                    principalColumn: "Id");
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
            name: "AboutMe",
            table: "Members");


            migrationBuilder.DropTable(
            name: "MemberFollows");
        }
    }
}
