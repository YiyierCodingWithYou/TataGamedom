using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TataGamedomWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class addTableNameToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__Supplier__3214EC071E0ECE7A",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK__StockInS__3214EC0731E1574F",
                table: "StockInStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__StockInS__3214EC07A41062FC",
                table: "StockInSheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Standard__3214EC07A40D737B",
                table: "StandardProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Shipment__3214EC076EA9FEAE",
                table: "ShipmentStatusesCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Shipmemt__3214EC0763A0B057",
                table: "ShipmentMethods");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Replies__3214EC074B9A9A83",
                table: "Replies");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ProductS__3214EC07DB83691D",
                table: "ProductStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Products__3214EC07916D4DB4",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ProductI__3214EC073EB6B989",
                table: "ProductImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostUpDo__3214EC07937F75DF",
                table: "PostUpDownVotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Posts__3214EC07F15C6972",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostRepo__3214EC07A7F1263E",
                table: "PostReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostEdit__3214EC07774665DF",
                table: "PostEditLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostComm__3214EC07DC2373CD",
                table: "PostCommentUpDownVotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostComm__3214EC07400CC101",
                table: "PostComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostComm__3214EC0782150AB6",
                table: "PostCommentReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PaymentS__3214EC0765B81A5B",
                table: "PaymentStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__OrderSta__3214EC075F549049",
                table: "OrderStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__OrderIte__3214EC07B33CBCA7",
                table: "OrderItemsCoupons");

            migrationBuilder.DropPrimaryKey(
                name: "PK__NewsView__3214EC07B5842579",
                table: "NewsViews");

            migrationBuilder.DropPrimaryKey(
                name: "PK__NewsLike__3214EC0740267417",
                table: "NewsLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Newslett__3214EC07B846C1D3",
                table: "Newsletters");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Newslett__3214EC074CBDBCE9",
                table: "NewsletterLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK__NewsComm__3214EC07515E7128",
                table: "NewsComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__NewsCate__3214EC07905E4A6D",
                table: "NewsCategoryCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__News__3214EC0787BD3004",
                table: "News");

            migrationBuilder.DropPrimaryKey(
                name: "PK__MembersB__3214EC07DA83D7F8",
                table: "MembersBoards");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Members__3214EC07112A0E72",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK__MemberPr__3214EC0771A30F39",
                table: "MemberProductViews");

            migrationBuilder.DropPrimaryKey(
                name: "PK__IssueTyp__3214EC0799F19FF2",
                table: "IssueTypesCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__IssueSta__3214EC0765E1F5D1",
                table: "IssueStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Issues__3214EC0721609CFC",
                table: "Issues");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Inventor__3214EC07923A7932",
                table: "InventoryItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Games__3214EC078BAEC25E",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GamePlat__3214EC0730FA21EB",
                table: "GamePlatformsCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GameComm__3214EC07DDEB32B4",
                table: "GameComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GameClas__3214EC07B56DDF94",
                table: "GameClassificationsCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GameClas__3214EC07D7845EF0",
                table: "GameClassificationGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK__FAQ__3214EC07614C899C",
                table: "FAQ");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Discount__3214EC079C378CCE",
                table: "DiscountTypeCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__CouponsP__3214EC07DD5DC5A2",
                table: "CouponsProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Coupons__3214EC07FF2D136B",
                table: "Coupons");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Carts__3214EC07C40BFBE8",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BucketLo__3214EC077EE12514",
                table: "BucketLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BoardsMo__3214EC07776C656E",
                table: "BoardsModeratorsApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BoardsMo__3214EC070C64C1B9",
                table: "BoardsModerators");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Boards__3214EC07329A44EB",
                table: "Boards");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BackendM__3214EC07F873DD27",
                table: "BackendMembersRolesCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BackendM__3214EC079BBBF0AE",
                table: "BackendMembersRolePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BackendM__3214EC075F957BE6",
                table: "BackendMembersPermissionsCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BackendM__3214EC0780AC3355",
                table: "BackendMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Approval__3214EC0729D71086",
                table: "ApprovalStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Announce__3214EC07E9AD234E",
                table: "Announcement");

            migrationBuilder.RenameIndex(
                name: "UQ__StockInS__9A5B6229BFDC8634",
                table: "StockInSheets",
                newName: "UQ__StockInS__9A5B6229675C7B7A");

            migrationBuilder.RenameIndex(
                name: "UQ__Shipmemt__737584F6BB624A36",
                table: "ShipmentMethods",
                newName: "UQ__Shipment__737584F648DA1223");

            migrationBuilder.RenameIndex(
                name: "UQ__Products__9A5B622984F05647",
                table: "Products",
                newName: "UQ__Products__9A5B6229C482EC11");

            migrationBuilder.RenameIndex(
                name: "UQ__Inventor__9A5B62292F47BB4A",
                table: "InventoryItems",
                newName: "UQ__Inventor__9A5B62294C645919");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Posts",
                type: "nvarchar(2500)",
                maxLength: 2500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1500)",
                oldMaxLength: 1500);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Supplier__3214EC07FE6A35E8",
                table: "Suppliers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__StockInS__3214EC07B784C350",
                table: "StockInStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__StockInS__3214EC077E825A4B",
                table: "StockInSheets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Standard__3214EC07D813FA45",
                table: "StandardProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Shipment__3214EC0734AB0240",
                table: "ShipmentStatusesCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Shipment__3214EC074B245F0F",
                table: "ShipmentMethods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Replies__3214EC07CB859A87",
                table: "Replies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ProductS__3214EC0784487DC2",
                table: "ProductStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Products__3214EC075E8B639E",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ProductI__3214EC0741607EC1",
                table: "ProductImages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostUpDo__3214EC077FE9978F",
                table: "PostUpDownVotes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Posts__3214EC076E77EF7E",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostRepo__3214EC0705C499B1",
                table: "PostReports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostEdit__3214EC076ED9F9EF",
                table: "PostEditLogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostComm__3214EC0729AAEC27",
                table: "PostCommentUpDownVotes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostComm__3214EC07F2A63DB6",
                table: "PostComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostComm__3214EC0796BCA603",
                table: "PostCommentReports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PaymentS__3214EC07965D7DE8",
                table: "PaymentStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__OrderSta__3214EC07F15A0C82",
                table: "OrderStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__OrderIte__3214EC0731D8548A",
                table: "OrderItemsCoupons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__NewsView__3214EC07E9BE321C",
                table: "NewsViews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__NewsLike__3214EC0776580830",
                table: "NewsLikes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Newslett__3214EC071CF82921",
                table: "Newsletters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Newslett__3214EC07BEF43A29",
                table: "NewsletterLogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__NewsComm__3214EC0737D03377",
                table: "NewsComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__NewsCate__3214EC07B24872E7",
                table: "NewsCategoryCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__News__3214EC077203D085",
                table: "News",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__MembersB__3214EC07C43EF7C1",
                table: "MembersBoards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Members__3214EC0778002C7C",
                table: "Members",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__MemberPr__3214EC077559485B",
                table: "MemberProductViews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__IssueTyp__3214EC07ABF1223E",
                table: "IssueTypesCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__IssueSta__3214EC07F657854B",
                table: "IssueStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Issues__3214EC0738E0B862",
                table: "Issues",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Inventor__3214EC07FA093884",
                table: "InventoryItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Games__3214EC07910EE496",
                table: "Games",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GamePlat__3214EC073939C40B",
                table: "GamePlatformsCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GameComm__3214EC07F0F653A3",
                table: "GameComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GameClas__3214EC0703AE2206",
                table: "GameClassificationsCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GameClas__3214EC07937EDA89",
                table: "GameClassificationGames",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__FAQ__3214EC0793C43210",
                table: "FAQ",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Discount__3214EC07D1CAC334",
                table: "DiscountTypeCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__CouponsP__3214EC075422D933",
                table: "CouponsProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Coupons__3214EC077F547B4A",
                table: "Coupons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Carts__3214EC07043F272B",
                table: "Carts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BucketLo__3214EC07C6A4089E",
                table: "BucketLogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BoardsMo__3214EC0731B3BE65",
                table: "BoardsModeratorsApplications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BoardsMo__3214EC07A16E5371",
                table: "BoardsModerators",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Boards__3214EC07DA7263D0",
                table: "Boards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BackendM__3214EC07C7C2B550",
                table: "BackendMembersRolesCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BackendM__3214EC07A6F6518D",
                table: "BackendMembersRolePermissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BackendM__3214EC070B9E4477",
                table: "BackendMembersPermissionsCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BackendM__3214EC072C24AF65",
                table: "BackendMembers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Approval__3214EC07AE8ADA97",
                table: "ApprovalStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Announce__3214EC0744CB17D5",
                table: "Announcement",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BoardNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    RecipientMemberId = table.Column<int>(type: "int", nullable: false),
                    RelationMemberId = table.Column<int>(type: "int", nullable: true),
                    RelationPostId = table.Column<int>(type: "int", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Link = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    isReaded = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ReadTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BoardNot__3214EC07B93E99E1", x => x.Id);
                    table.ForeignKey(
                        name: "FK__BoardNoti__Recip__12FDD1B2",
                        column: x => x.RecipientMemberId,
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__BoardNoti__Relat__13F1F5EB",
                        column: x => x.RelationMemberId,
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__BoardNoti__Relat__14E61A24",
                        column: x => x.RelationPostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardNotifications_RecipientMemberId",
                table: "BoardNotifications",
                column: "RecipientMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardNotifications_RelationMemberId",
                table: "BoardNotifications",
                column: "RelationMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardNotifications_RelationPostId",
                table: "BoardNotifications",
                column: "RelationPostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardNotifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Supplier__3214EC07FE6A35E8",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK__StockInS__3214EC07B784C350",
                table: "StockInStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__StockInS__3214EC077E825A4B",
                table: "StockInSheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Standard__3214EC07D813FA45",
                table: "StandardProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Shipment__3214EC0734AB0240",
                table: "ShipmentStatusesCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Shipment__3214EC074B245F0F",
                table: "ShipmentMethods");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Replies__3214EC07CB859A87",
                table: "Replies");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ProductS__3214EC0784487DC2",
                table: "ProductStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Products__3214EC075E8B639E",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ProductI__3214EC0741607EC1",
                table: "ProductImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostUpDo__3214EC077FE9978F",
                table: "PostUpDownVotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Posts__3214EC076E77EF7E",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostRepo__3214EC0705C499B1",
                table: "PostReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostEdit__3214EC076ED9F9EF",
                table: "PostEditLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostComm__3214EC0729AAEC27",
                table: "PostCommentUpDownVotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostComm__3214EC07F2A63DB6",
                table: "PostComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostComm__3214EC0796BCA603",
                table: "PostCommentReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PaymentS__3214EC07965D7DE8",
                table: "PaymentStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__OrderSta__3214EC07F15A0C82",
                table: "OrderStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__OrderIte__3214EC0731D8548A",
                table: "OrderItemsCoupons");

            migrationBuilder.DropPrimaryKey(
                name: "PK__NewsView__3214EC07E9BE321C",
                table: "NewsViews");

            migrationBuilder.DropPrimaryKey(
                name: "PK__NewsLike__3214EC0776580830",
                table: "NewsLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Newslett__3214EC071CF82921",
                table: "Newsletters");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Newslett__3214EC07BEF43A29",
                table: "NewsletterLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK__NewsComm__3214EC0737D03377",
                table: "NewsComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__NewsCate__3214EC07B24872E7",
                table: "NewsCategoryCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__News__3214EC077203D085",
                table: "News");

            migrationBuilder.DropPrimaryKey(
                name: "PK__MembersB__3214EC07C43EF7C1",
                table: "MembersBoards");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Members__3214EC0778002C7C",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK__MemberPr__3214EC077559485B",
                table: "MemberProductViews");

            migrationBuilder.DropPrimaryKey(
                name: "PK__IssueTyp__3214EC07ABF1223E",
                table: "IssueTypesCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__IssueSta__3214EC07F657854B",
                table: "IssueStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Issues__3214EC0738E0B862",
                table: "Issues");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Inventor__3214EC07FA093884",
                table: "InventoryItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Games__3214EC07910EE496",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GamePlat__3214EC073939C40B",
                table: "GamePlatformsCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GameComm__3214EC07F0F653A3",
                table: "GameComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GameClas__3214EC0703AE2206",
                table: "GameClassificationsCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GameClas__3214EC07937EDA89",
                table: "GameClassificationGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK__FAQ__3214EC0793C43210",
                table: "FAQ");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Discount__3214EC07D1CAC334",
                table: "DiscountTypeCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__CouponsP__3214EC075422D933",
                table: "CouponsProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Coupons__3214EC077F547B4A",
                table: "Coupons");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Carts__3214EC07043F272B",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BucketLo__3214EC07C6A4089E",
                table: "BucketLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BoardsMo__3214EC0731B3BE65",
                table: "BoardsModeratorsApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BoardsMo__3214EC07A16E5371",
                table: "BoardsModerators");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Boards__3214EC07DA7263D0",
                table: "Boards");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BackendM__3214EC07C7C2B550",
                table: "BackendMembersRolesCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BackendM__3214EC07A6F6518D",
                table: "BackendMembersRolePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BackendM__3214EC070B9E4477",
                table: "BackendMembersPermissionsCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BackendM__3214EC072C24AF65",
                table: "BackendMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Approval__3214EC07AE8ADA97",
                table: "ApprovalStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Announce__3214EC0744CB17D5",
                table: "Announcement");

            migrationBuilder.RenameIndex(
                name: "UQ__StockInS__9A5B6229675C7B7A",
                table: "StockInSheets",
                newName: "UQ__StockInS__9A5B6229BFDC8634");

            migrationBuilder.RenameIndex(
                name: "UQ__Shipment__737584F648DA1223",
                table: "ShipmentMethods",
                newName: "UQ__Shipmemt__737584F6BB624A36");

            migrationBuilder.RenameIndex(
                name: "UQ__Products__9A5B6229C482EC11",
                table: "Products",
                newName: "UQ__Products__9A5B622984F05647");

            migrationBuilder.RenameIndex(
                name: "UQ__Inventor__9A5B62294C645919",
                table: "InventoryItems",
                newName: "UQ__Inventor__9A5B62292F47BB4A");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Posts",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2500)",
                oldMaxLength: 2500);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Supplier__3214EC071E0ECE7A",
                table: "Suppliers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__StockInS__3214EC0731E1574F",
                table: "StockInStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__StockInS__3214EC07A41062FC",
                table: "StockInSheets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Standard__3214EC07A40D737B",
                table: "StandardProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Shipment__3214EC076EA9FEAE",
                table: "ShipmentStatusesCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Shipmemt__3214EC0763A0B057",
                table: "ShipmentMethods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Replies__3214EC074B9A9A83",
                table: "Replies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ProductS__3214EC07DB83691D",
                table: "ProductStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Products__3214EC07916D4DB4",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ProductI__3214EC073EB6B989",
                table: "ProductImages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostUpDo__3214EC07937F75DF",
                table: "PostUpDownVotes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Posts__3214EC07F15C6972",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostRepo__3214EC07A7F1263E",
                table: "PostReports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostEdit__3214EC07774665DF",
                table: "PostEditLogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostComm__3214EC07DC2373CD",
                table: "PostCommentUpDownVotes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostComm__3214EC07400CC101",
                table: "PostComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostComm__3214EC0782150AB6",
                table: "PostCommentReports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PaymentS__3214EC0765B81A5B",
                table: "PaymentStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__OrderSta__3214EC075F549049",
                table: "OrderStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__OrderIte__3214EC07B33CBCA7",
                table: "OrderItemsCoupons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__NewsView__3214EC07B5842579",
                table: "NewsViews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__NewsLike__3214EC0740267417",
                table: "NewsLikes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Newslett__3214EC07B846C1D3",
                table: "Newsletters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Newslett__3214EC074CBDBCE9",
                table: "NewsletterLogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__NewsComm__3214EC07515E7128",
                table: "NewsComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__NewsCate__3214EC07905E4A6D",
                table: "NewsCategoryCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__News__3214EC0787BD3004",
                table: "News",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__MembersB__3214EC07DA83D7F8",
                table: "MembersBoards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Members__3214EC07112A0E72",
                table: "Members",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__MemberPr__3214EC0771A30F39",
                table: "MemberProductViews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__IssueTyp__3214EC0799F19FF2",
                table: "IssueTypesCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__IssueSta__3214EC0765E1F5D1",
                table: "IssueStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Issues__3214EC0721609CFC",
                table: "Issues",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Inventor__3214EC07923A7932",
                table: "InventoryItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Games__3214EC078BAEC25E",
                table: "Games",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GamePlat__3214EC0730FA21EB",
                table: "GamePlatformsCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GameComm__3214EC07DDEB32B4",
                table: "GameComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GameClas__3214EC07B56DDF94",
                table: "GameClassificationsCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GameClas__3214EC07D7845EF0",
                table: "GameClassificationGames",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__FAQ__3214EC07614C899C",
                table: "FAQ",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Discount__3214EC079C378CCE",
                table: "DiscountTypeCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__CouponsP__3214EC07DD5DC5A2",
                table: "CouponsProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Coupons__3214EC07FF2D136B",
                table: "Coupons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Carts__3214EC07C40BFBE8",
                table: "Carts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BucketLo__3214EC077EE12514",
                table: "BucketLogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BoardsMo__3214EC07776C656E",
                table: "BoardsModeratorsApplications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BoardsMo__3214EC070C64C1B9",
                table: "BoardsModerators",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Boards__3214EC07329A44EB",
                table: "Boards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BackendM__3214EC07F873DD27",
                table: "BackendMembersRolesCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BackendM__3214EC079BBBF0AE",
                table: "BackendMembersRolePermissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BackendM__3214EC075F957BE6",
                table: "BackendMembersPermissionsCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BackendM__3214EC0780AC3355",
                table: "BackendMembers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Approval__3214EC0729D71086",
                table: "ApprovalStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Announce__3214EC07E9AD234E",
                table: "Announcement",
                column: "Id");
        }
    }
}
