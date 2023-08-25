using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TataGamedomWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class addShippingFeeColumn_adjustShipmentMethodId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__BackendMe__Backe__2B0A656D",
                table: "BackendMembers");

            migrationBuilder.DropForeignKey(
                name: "FK__BackendMe__Backe__2BFE89A6",
                table: "BackendMembersRolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK__BackendMe__Backe__2CF2ADDF",
                table: "BackendMembersRolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK__Boards__CreatedB__2DE6D218",
                table: "Boards");

            migrationBuilder.DropForeignKey(
                name: "FK__Boards__GameId__2EDAF651",
                table: "Boards");

            migrationBuilder.DropForeignKey(
                name: "FK__BoardsMod__Board__2FCF1A8A",
                table: "BoardsModerators");

            migrationBuilder.DropForeignKey(
                name: "FK__BoardsMod__Moder__30C33EC3",
                table: "BoardsModerators");

            migrationBuilder.DropForeignKey(
                name: "FK__BoardsMod__Appro__31B762FC",
                table: "BoardsModeratorsApplications");

            migrationBuilder.DropForeignKey(
                name: "FK__BoardsMod__Backe__32AB8735",
                table: "BoardsModeratorsApplications");

            migrationBuilder.DropForeignKey(
                name: "FK__BoardsMod__Board__339FAB6E",
                table: "BoardsModeratorsApplications");

            migrationBuilder.DropForeignKey(
                name: "FK__BoardsMod__Membe__3493CFA7",
                table: "BoardsModeratorsApplications");

            migrationBuilder.DropForeignKey(
                name: "FK__BucketLog__Backe__3587F3E0",
                table: "BucketLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__BucketLog__Board__367C1819",
                table: "BucketLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__BucketLog__Bucke__37703C52",
                table: "BucketLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__BucketLog__Moder__3864608B",
                table: "BucketLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__Carts__MemberId__395884C4",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK__Carts__ProductId__3A4CA8FD",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK__Coupons__Created__3B40CD36",
                table: "Coupons");

            migrationBuilder.DropForeignKey(
                name: "FK__Coupons__Discoun__3C34F16F",
                table: "Coupons");

            migrationBuilder.DropForeignKey(
                name: "FK__Coupons__Modifie__3D2915A8",
                table: "Coupons");

            migrationBuilder.DropForeignKey(
                name: "FK__CouponsPr__Coupo__3E1D39E1",
                table: "CouponsProducts");

            migrationBuilder.DropForeignKey(
                name: "FK__CouponsPr__Produ__3F115E1A",
                table: "CouponsProducts");

            migrationBuilder.DropForeignKey(
                name: "FK__FAQ__IssueTypeId__40058253",
                table: "FAQ");

            migrationBuilder.DropForeignKey(
                name: "FK__GameClass__GameC__40F9A68C",
                table: "GameClassificationGames");

            migrationBuilder.DropForeignKey(
                name: "FK__GameClass__GameI__41EDCAC5",
                table: "GameClassificationGames");

            migrationBuilder.DropForeignKey(
                name: "FK__GameComme__Delet__42E1EEFE",
                table: "GameComments");

            migrationBuilder.DropForeignKey(
                name: "FK__GameComme__GameI__43D61337",
                table: "GameComments");

            migrationBuilder.DropForeignKey(
                name: "FK__GameComme__Membe__44CA3770",
                table: "GameComments");

            migrationBuilder.DropForeignKey(
                name: "FK__Games__CreatedBa__45BE5BA9",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK__Games__ModifiedB__46B27FE2",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK__Inventory__Produ__47A6A41B",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK__Inventory__Stock__489AC854",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK__Issues__IssueTyp__498EEC8D",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK__Issues__MemberId__4A8310C6",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK__Issues__Status__4B7734FF",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK__MemberPro__Membe__4C6B5938",
                table: "MemberProductViews");

            migrationBuilder.DropForeignKey(
                name: "FK__MemberPro__Produ__4D5F7D71",
                table: "MemberProductViews");

            migrationBuilder.DropForeignKey(
                name: "FK__MembersBo__Board__4E53A1AA",
                table: "MembersBoards");

            migrationBuilder.DropForeignKey(
                name: "FK__MembersBo__Membe__4F47C5E3",
                table: "MembersBoards");

            migrationBuilder.DropForeignKey(
                name: "FK__News__BackendMem__503BEA1C",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK__News__DeleteBack__51300E55",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK__News__GamesId__5224328E",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK__News__NewsCatego__531856C7",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsComme__Delet__540C7B00",
                table: "NewsComments");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsComme__Delet__55009F39",
                table: "NewsComments");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsComme__Membe__55F4C372",
                table: "NewsComments");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsComme__NewsI__56E8E7AB",
                table: "NewsComments");

            migrationBuilder.DropForeignKey(
                name: "FK__Newslette__Addre__57DD0BE4",
                table: "NewsletterLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__Newslette__Newsl__58D1301D",
                table: "NewsletterLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__Newslette__Backe__59C55456",
                table: "Newsletters");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsLikes__Membe__5AB9788F",
                table: "NewsLikes");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsLikes__NewsI__5BAD9CC8",
                table: "NewsLikes");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsViews__Membe__5CA1C101",
                table: "NewsViews");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsViews__NewsI__5D95E53A",
                table: "NewsViews");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderItem__Order__5E8A0973",
                table: "OrderItemReturns");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderItem__Inven__5F7E2DAC",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderItem__Order__607251E5",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderItem__Coupo__625A9A57",
                table: "OrderItemsCoupons");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderItem__Order__634EBE90",
                table: "OrderItemsCoupons");

            migrationBuilder.DropForeignKey(
                name: "FK__Orders__MemberId__6442E2C9",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK__Orders__OrderSta__65370702",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK__Orders__PaymentS__662B2B3B",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK__Orders__Shipmemt__671F4F74",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK__Orders__Shipment__681373AD",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Membe__690797E6",
                table: "PostCommentReports");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__PostC__69FBBC1F",
                table: "PostCommentReports");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Revie__6AEFE058",
                table: "PostCommentReports");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Delet__6BE40491",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Delet__6CD828CA",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Membe__6DCC4D03",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Paren__6EC0713C",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__PostI__6FB49575",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Membe__70A8B9AE",
                table: "PostCommentUpDownVotes");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__PostC__719CDDE7",
                table: "PostCommentUpDownVotes");

            migrationBuilder.DropForeignKey(
                name: "FK__PostEditL__PostI__72910220",
                table: "PostEditLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__PostRepor__Membe__73852659",
                table: "PostReports");

            migrationBuilder.DropForeignKey(
                name: "FK__PostRepor__PostI__74794A92",
                table: "PostReports");

            migrationBuilder.DropForeignKey(
                name: "FK__PostRepor__Revie__756D6ECB",
                table: "PostReports");

            migrationBuilder.DropForeignKey(
                name: "FK__Posts__BoardId__76619304",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK__Posts__DeleteBac__7755B73D",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK__Posts__DeleteMem__7849DB76",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK__Posts__MemberId__793DFFAF",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK__PostUpDow__Membe__7A3223E8",
                table: "PostUpDownVotes");

            migrationBuilder.DropForeignKey(
                name: "FK__PostUpDow__PostI__7B264821",
                table: "PostUpDownVotes");

            migrationBuilder.DropForeignKey(
                name: "FK__ProductIm__Produ__7C1A6C5A",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK__Products__Create__7D0E9093",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK__Products__GameId__7E02B4CC",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK__Products__GamePl__7EF6D905",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK__Products__Modifi__7FEAFD3E",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK__Products__Produc__00DF2177",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK__Replies__Backend__01D345B0",
                table: "Replies");

            migrationBuilder.DropForeignKey(
                name: "FK__Replies__IssueId__02C769E9",
                table: "Replies");

            migrationBuilder.DropForeignKey(
                name: "FK__StandardP__Produ__03BB8E22",
                table: "StandardProducts");

            migrationBuilder.DropForeignKey(
                name: "FK__StockInSh__Stock__04AFB25B",
                table: "StockInSheets");

            migrationBuilder.DropForeignKey(
                name: "FK__StockInSh__Suppl__05A3D694",
                table: "StockInSheets");

            migrationBuilder.DropTable(
                name: "AggregatedCounter",
                schema: "HangFire");

            migrationBuilder.DropTable(
                name: "Counter",
                schema: "HangFire");

            migrationBuilder.DropTable(
                name: "Hash",
                schema: "HangFire");

            migrationBuilder.DropTable(
                name: "JobParameter",
                schema: "HangFire");

            migrationBuilder.DropTable(
                name: "JobQueue",
                schema: "HangFire");

            migrationBuilder.DropTable(
                name: "List",
                schema: "HangFire");

            migrationBuilder.DropTable(
                name: "Schema",
                schema: "HangFire");

            migrationBuilder.DropTable(
                name: "Server",
                schema: "HangFire");

            migrationBuilder.DropTable(
                name: "Set",
                schema: "HangFire");

            migrationBuilder.DropTable(
                name: "State",
                schema: "HangFire");

            migrationBuilder.DropTable(
                name: "Job",
                schema: "HangFire");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Supplier__3214EC077973F9DE",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK__StockInS__3214EC07EEDC7769",
                table: "StockInStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__StockInS__3214EC07405F71E2",
                table: "StockInSheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Standard__3214EC07394EA72A",
                table: "StandardProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Shipment__3214EC0783E040BB",
                table: "ShipmentStatusesCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Shipmemt__3214EC072A3C39EB",
                table: "ShipmemtMethods");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Replies__3214EC07E0D2B380",
                table: "Replies");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ProductS__3214EC07202FDD88",
                table: "ProductStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Products__3214EC07507639E1",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ProductI__3214EC07C114CDBC",
                table: "ProductImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostUpDo__3214EC0798F19DA5",
                table: "PostUpDownVotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Posts__3214EC070101E7C8",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostRepo__3214EC07837449D8",
                table: "PostReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostEdit__3214EC0739372863",
                table: "PostEditLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostComm__3214EC0768F595DB",
                table: "PostCommentUpDownVotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostComm__3214EC0735E155C2",
                table: "PostComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostComm__3214EC07BC4E1A13",
                table: "PostCommentReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PaymentS__3214EC073A00A45F",
                table: "PaymentStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__OrderSta__3214EC07116072B2",
                table: "OrderStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Orders__3214EC07DF813A2D",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShipmemtMethodId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK__OrderIte__3214EC07028DD9F0",
                table: "OrderItemsCoupons");

            migrationBuilder.DropPrimaryKey(
                name: "PK__OrderIte__3214EC070746D7D1",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "UQ__OrderIte__9A5B622987053FBF",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK__OrderIte__3214EC07BAF73361",
                table: "OrderItemReturns");

            migrationBuilder.DropIndex(
                name: "UQ__OrderIte__9A5B622998CBDD5F",
                table: "OrderItemReturns");

            migrationBuilder.DropPrimaryKey(
                name: "PK__NewsView__3214EC071B0EB1D3",
                table: "NewsViews");

            migrationBuilder.DropPrimaryKey(
                name: "PK__NewsLike__3214EC079C5BAFB7",
                table: "NewsLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Newslett__3214EC07B74A28C2",
                table: "Newsletters");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Newslett__3214EC075560C131",
                table: "NewsletterLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK__NewsComm__3214EC07B86D4C6D",
                table: "NewsComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__NewsCate__3214EC07149DD1A7",
                table: "NewsCategoryCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__News__3214EC077971DE77",
                table: "News");

            migrationBuilder.DropPrimaryKey(
                name: "PK__MembersB__3214EC07DF629D3A",
                table: "MembersBoards");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Members__3214EC0760DA1704",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK__MemberPr__3214EC07122BAD8E",
                table: "MemberProductViews");

            migrationBuilder.DropIndex(
                name: "UcMemberFollow",
                table: "MemberFollows");

            migrationBuilder.DropPrimaryKey(
                name: "PK__IssueTyp__3214EC073A96082D",
                table: "IssueTypesCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__IssueSta__3214EC0732E24D0D",
                table: "IssueStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Issues__3214EC07E064CBDC",
                table: "Issues");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Inventor__3214EC07D55DED24",
                table: "InventoryItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Games__3214EC073A5B26DD",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GamePlat__3214EC07726ACF89",
                table: "GamePlatformsCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GameComm__3214EC0735481931",
                table: "GameComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GameClas__3214EC071F6A6303",
                table: "GameClassificationsCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GameClas__3214EC0701057A73",
                table: "GameClassificationGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK__FAQ__3214EC07877B16E5",
                table: "FAQ");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Discount__3214EC077F687773",
                table: "DiscountTypeCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__CouponsP__3214EC07C88DE8CA",
                table: "CouponsProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Coupons__3214EC070BBE66AE",
                table: "Coupons");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Carts__3214EC0737297441",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BucketLo__3214EC0744D24644",
                table: "BucketLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BoardsMo__3214EC075E99A5C9",
                table: "BoardsModeratorsApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BoardsMo__3214EC0799961D35",
                table: "BoardsModerators");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Boards__3214EC07ABB99035",
                table: "Boards");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BackendM__3214EC07B83CD97C",
                table: "BackendMembersRolesCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BackendM__3214EC0729845EFD",
                table: "BackendMembersRolePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BackendM__3214EC07DF219F93",
                table: "BackendMembersPermissionsCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BackendM__3214EC07E57DEEED",
                table: "BackendMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Approval__3214EC07EB753EFC",
                table: "ApprovalStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Announce__3214EC074FD2771D",
                table: "Announcement");

            migrationBuilder.RenameIndex(
                name: "UQ__StockInS__9A5B62291521DBDE",
                table: "StockInSheets",
                newName: "UQ__StockInS__9A5B62297753599F");

            migrationBuilder.RenameIndex(
                name: "UQ__Shipmemt__737584F60A26FFD2",
                table: "ShipmemtMethods",
                newName: "UQ__Shipmemt__737584F6A6227A50");

            migrationBuilder.RenameIndex(
                name: "UQ__Products__9A5B6229FEB5BAD5",
                table: "Products",
                newName: "UQ__Products__9A5B6229D5BCEABA");

            migrationBuilder.RenameColumn(
                name: "ShipmemtMethodId",
                table: "Orders",
                newName: "ShippingFee");

            migrationBuilder.RenameIndex(
                name: "UQ__Orders__9A5B622990CDB978",
                table: "Orders",
                newName: "UQ__Orders__9A5B62299A9DCB7B");

            migrationBuilder.RenameIndex(
                name: "UQ__OrderIte__3BB2AC81B62FFB01",
                table: "OrderItems",
                newName: "UQ__OrderIte__3BB2AC81819DD448");

            migrationBuilder.RenameIndex(
                name: "UQ__OrderIte__57ED068035C18F11",
                table: "OrderItemReturns",
                newName: "UQ__OrderIte__57ED0680FBF10CC1");

            migrationBuilder.RenameIndex(
                name: "UQ__Inventor__9A5B622972C68AC9",
                table: "InventoryItems",
                newName: "UQ__Inventor__9A5B622901E60557");

            migrationBuilder.AlterColumn<string>(
                name: "ToAddress",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Index",
                table: "Orders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<int>(
                name: "ShipmentMethodId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Index",
                table: "OrderItems",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Supplier__3214EC075D35F1A7",
                table: "Suppliers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__StockInS__3214EC07CE3D2F4B",
                table: "StockInStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__StockInS__3214EC07451B5458",
                table: "StockInSheets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Standard__3214EC07F90F23CF",
                table: "StandardProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Shipment__3214EC07B6593D83",
                table: "ShipmentStatusesCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Shipmemt__3214EC0798A22433",
                table: "ShipmemtMethods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Replies__3214EC073FF45844",
                table: "Replies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ProductS__3214EC077E0F732B",
                table: "ProductStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Products__3214EC07D025225F",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ProductI__3214EC0790A3C058",
                table: "ProductImages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostUpDo__3214EC07E318FA24",
                table: "PostUpDownVotes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Posts__3214EC07B6970EB8",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostRepo__3214EC076E8A0162",
                table: "PostReports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostEdit__3214EC073B0728BB",
                table: "PostEditLogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostComm__3214EC07566423D2",
                table: "PostCommentUpDownVotes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostComm__3214EC078141FA43",
                table: "PostComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostComm__3214EC07578E7724",
                table: "PostCommentReports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PaymentS__3214EC077DE348A0",
                table: "PaymentStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__OrderSta__3214EC078374750A",
                table: "OrderStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Orders__3214EC0743A819E5",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__OrderIte__3214EC07B268D456",
                table: "OrderItemsCoupons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__OrderIte__3214EC07A2DE618F",
                table: "OrderItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__OrderIte__3214EC07661B879E",
                table: "OrderItemReturns",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__NewsView__3214EC072421AD95",
                table: "NewsViews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__NewsLike__3214EC07FA3D0592",
                table: "NewsLikes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Newslett__3214EC07D17703F2",
                table: "Newsletters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Newslett__3214EC07A074AF56",
                table: "NewsletterLogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__NewsComm__3214EC07D8BCCD4E",
                table: "NewsComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__NewsCate__3214EC07FBFA876E",
                table: "NewsCategoryCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__News__3214EC0731D7F77E",
                table: "News",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__MembersB__3214EC07B1ED6A41",
                table: "MembersBoards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Members__3214EC070EDCD496",
                table: "Members",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__MemberPr__3214EC070F38C7D0",
                table: "MemberProductViews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__IssueTyp__3214EC0795528B63",
                table: "IssueTypesCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__IssueSta__3214EC07F66ED952",
                table: "IssueStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Issues__3214EC0706CA3A80",
                table: "Issues",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Inventor__3214EC072349E96D",
                table: "InventoryItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Games__3214EC0720EF07B1",
                table: "Games",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GamePlat__3214EC0717264051",
                table: "GamePlatformsCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GameComm__3214EC07A9D5AF1B",
                table: "GameComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GameClas__3214EC070465DA72",
                table: "GameClassificationsCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GameClas__3214EC0767D415B9",
                table: "GameClassificationGames",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__FAQ__3214EC07017B8F0A",
                table: "FAQ",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Discount__3214EC07CD3A91A4",
                table: "DiscountTypeCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__CouponsP__3214EC0773784635",
                table: "CouponsProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Coupons__3214EC07B2D24C1C",
                table: "Coupons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Carts__3214EC074368D617",
                table: "Carts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BucketLo__3214EC07D98AE89A",
                table: "BucketLogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BoardsMo__3214EC07EDE45AF3",
                table: "BoardsModeratorsApplications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BoardsMo__3214EC07A3EEEF55",
                table: "BoardsModerators",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Boards__3214EC072A2E93A0",
                table: "Boards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BackendM__3214EC07B421B667",
                table: "BackendMembersRolesCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BackendM__3214EC07E8CB4E9D",
                table: "BackendMembersRolePermissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BackendM__3214EC07595F3723",
                table: "BackendMembersPermissionsCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BackendM__3214EC072F7D7E6F",
                table: "BackendMembers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Approval__3214EC0754FC873C",
                table: "ApprovalStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Announce__3214EC0791CEBBD7",
                table: "Announcement",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BranchesOfSeven",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    StoreName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Branches__3214EC27C5E9490C", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipmentMethodId",
                table: "Orders",
                column: "ShipmentMethodId");

            migrationBuilder.CreateIndex(
                name: "UQ__OrderIte__9A5B62295905CB9C",
                table: "OrderItems",
                column: "Index",
                unique: true,
                filter: "[Index] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__OrderIte__9A5B6229DB395A7A",
                table: "OrderItemReturns",
                column: "Index",
                unique: true,
                filter: "[Index] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MemberFollows_FollowerMemberId",
                table: "MemberFollows",
                column: "FollowerMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK__BackendMe__Backe__1EA48E88",
                table: "BackendMembers",
                column: "BackendMembersRoleId",
                principalTable: "BackendMembersRolesCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BackendMe__Backe__1F98B2C1",
                table: "BackendMembersRolePermissions",
                column: "BackendMembersRoleId",
                principalTable: "BackendMembersRolesCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BackendMe__Backe__208CD6FA",
                table: "BackendMembersRolePermissions",
                column: "BackendMemberPermissionId",
                principalTable: "BackendMembersPermissionsCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Boards__CreatedB__2180FB33",
                table: "Boards",
                column: "CreatedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Boards__GameId__22751F6C",
                table: "Boards",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BoardsMod__Board__236943A5",
                table: "BoardsModerators",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BoardsMod__Moder__245D67DE",
                table: "BoardsModerators",
                column: "ModeratorMemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BoardsMod__Appro__25518C17",
                table: "BoardsModeratorsApplications",
                column: "ApprovalStatusId",
                principalTable: "ApprovalStatusCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BoardsMod__Backe__2645B050",
                table: "BoardsModeratorsApplications",
                column: "BackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BoardsMod__Board__2739D489",
                table: "BoardsModeratorsApplications",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BoardsMod__Membe__282DF8C2",
                table: "BoardsModeratorsApplications",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BucketLog__Backe__29221CFB",
                table: "BucketLogs",
                column: "BackendMmemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BucketLog__Board__2A164134",
                table: "BucketLogs",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BucketLog__Bucke__2B0A656D",
                table: "BucketLogs",
                column: "BucketMemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BucketLog__Moder__2BFE89A6",
                table: "BucketLogs",
                column: "ModeratorMemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Carts__MemberId__2CF2ADDF",
                table: "Carts",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Carts__ProductId__2DE6D218",
                table: "Carts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Coupons__Created__30C33EC3",
                table: "Coupons",
                column: "CreatedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Coupons__Discoun__31B762FC",
                table: "Coupons",
                column: "DiscountTypeId",
                principalTable: "DiscountTypeCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Coupons__Modifie__32AB8735",
                table: "Coupons",
                column: "ModifiedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__CouponsPr__Coupo__339FAB6E",
                table: "CouponsProducts",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__CouponsPr__Produ__3493CFA7",
                table: "CouponsProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__FAQ__IssueTypeId__3587F3E0",
                table: "FAQ",
                column: "IssueTypeId",
                principalTable: "IssueTypesCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__GameClass__GameC__367C1819",
                table: "GameClassificationGames",
                column: "GameClassificationId",
                principalTable: "GameClassificationsCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__GameClass__GameI__37703C52",
                table: "GameClassificationGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__GameComme__Delet__3864608B",
                table: "GameComments",
                column: "DeleteBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__GameComme__GameI__395884C4",
                table: "GameComments",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__GameComme__Membe__3A4CA8FD",
                table: "GameComments",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Games__CreatedBa__3B40CD36",
                table: "Games",
                column: "CreatedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Games__ModifiedB__3C34F16F",
                table: "Games",
                column: "ModifiedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Inventory__Produ__3D2915A8",
                table: "InventoryItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Inventory__Stock__3E1D39E1",
                table: "InventoryItems",
                column: "StockInSheetId",
                principalTable: "StockInSheets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Issues__IssueTyp__3F115E1A",
                table: "Issues",
                column: "IssueTypeId",
                principalTable: "IssueTypesCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Issues__MemberId__40058253",
                table: "Issues",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Issues__Status__40F9A68C",
                table: "Issues",
                column: "Status",
                principalTable: "IssueStatusCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MemberPro__Membe__43D61337",
                table: "MemberProductViews",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MemberPro__Produ__44CA3770",
                table: "MemberProductViews",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MembersBo__Board__45BE5BA9",
                table: "MembersBoards",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MembersBo__Membe__46B27FE2",
                table: "MembersBoards",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__News__BackendMem__47A6A41B",
                table: "News",
                column: "BackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__News__DeleteBack__489AC854",
                table: "News",
                column: "DeleteBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__News__GamesId__498EEC8D",
                table: "News",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__News__NewsCatego__4A8310C6",
                table: "News",
                column: "NewsCategoryId",
                principalTable: "NewsCategoryCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsComme__Delet__4B7734FF",
                table: "NewsComments",
                column: "DeleteMemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsComme__Delet__4C6B5938",
                table: "NewsComments",
                column: "DeleteBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsComme__Membe__4D5F7D71",
                table: "NewsComments",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsComme__NewsI__4E53A1AA",
                table: "NewsComments",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Newslette__Addre__4F47C5E3",
                table: "NewsletterLogs",
                column: "AddresseeMemberID",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Newslette__Newsl__503BEA1C",
                table: "NewsletterLogs",
                column: "NewsletterId",
                principalTable: "Newsletters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Newslette__Backe__51300E55",
                table: "Newsletters",
                column: "BackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsLikes__Membe__5224328E",
                table: "NewsLikes",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsLikes__NewsI__531856C7",
                table: "NewsLikes",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsViews__Membe__540C7B00",
                table: "NewsViews",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsViews__NewsI__55009F39",
                table: "NewsViews",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderItem__Order__4B7734FF",
                table: "OrderItemReturns",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__OrderItem__Inven__4C6B5938",
                table: "OrderItems",
                column: "InventoryItemId",
                principalTable: "InventoryItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderItem__Order__4D5F7D71",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderItem__Coupo__59C55456",
                table: "OrderItemsCoupons",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderItem__Order__503BEA1C",
                table: "OrderItemsCoupons",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Orders__MemberId__51300E55",
                table: "Orders",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Orders__OrderSta__5224328E",
                table: "Orders",
                column: "OrderStatusId",
                principalTable: "OrderStatusCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Orders__PaymentS__531856C7",
                table: "Orders",
                column: "PaymentStatusId",
                principalTable: "PaymentStatusCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Orders__Shipmemt__540C7B00",
                table: "Orders",
                column: "ShipmentMethodId",
                principalTable: "ShipmemtMethods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Orders__Shipment__55009F39",
                table: "Orders",
                column: "ShipmentStatusId",
                principalTable: "ShipmentStatusesCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Membe__607251E5",
                table: "PostCommentReports",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__PostC__6166761E",
                table: "PostCommentReports",
                column: "PostCommentId",
                principalTable: "PostComments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Revie__625A9A57",
                table: "PostCommentReports",
                column: "ReviewerBackenMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Delet__634EBE90",
                table: "PostComments",
                column: "DeleteMemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Delet__6442E2C9",
                table: "PostComments",
                column: "DeleteBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Membe__65370702",
                table: "PostComments",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Paren__662B2B3B",
                table: "PostComments",
                column: "ParentId",
                principalTable: "PostComments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__PostI__671F4F74",
                table: "PostComments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Membe__681373AD",
                table: "PostCommentUpDownVotes",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__PostC__690797E6",
                table: "PostCommentUpDownVotes",
                column: "PostCommentId",
                principalTable: "PostComments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostEditL__PostI__69FBBC1F",
                table: "PostEditLogs",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostRepor__Membe__6AEFE058",
                table: "PostReports",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostRepor__PostI__6BE40491",
                table: "PostReports",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostRepor__Revie__6CD828CA",
                table: "PostReports",
                column: "ReviewerBackenMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Posts__BoardId__6DCC4D03",
                table: "Posts",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Posts__DeleteBac__6EC0713C",
                table: "Posts",
                column: "DeleteBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Posts__DeleteMem__6FB49575",
                table: "Posts",
                column: "DeleteMemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Posts__MemberId__70A8B9AE",
                table: "Posts",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostUpDow__Membe__719CDDE7",
                table: "PostUpDownVotes",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostUpDow__PostI__72910220",
                table: "PostUpDownVotes",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__ProductIm__Produ__73852659",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Products__Create__74794A92",
                table: "Products",
                column: "CreatedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Products__GameId__756D6ECB",
                table: "Products",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Products__GamePl__76619304",
                table: "Products",
                column: "GamePlatformId",
                principalTable: "GamePlatformsCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Products__Modifi__7755B73D",
                table: "Products",
                column: "ModifiedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Products__Produc__7849DB76",
                table: "Products",
                column: "ProductStatusId",
                principalTable: "ProductStatusCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Replies__Backend__793DFFAF",
                table: "Replies",
                column: "BackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Replies__IssueId__7A3223E8",
                table: "Replies",
                column: "IssueId",
                principalTable: "Issues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__StandardP__Produ__7B264821",
                table: "StandardProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__StockInSh__Stock__7C1A6C5A",
                table: "StockInSheets",
                column: "StockInStatusId",
                principalTable: "StockInStatusCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__StockInSh__Suppl__7D0E9093",
                table: "StockInSheets",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__BackendMe__Backe__1EA48E88",
                table: "BackendMembers");

            migrationBuilder.DropForeignKey(
                name: "FK__BackendMe__Backe__1F98B2C1",
                table: "BackendMembersRolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK__BackendMe__Backe__208CD6FA",
                table: "BackendMembersRolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK__Boards__CreatedB__2180FB33",
                table: "Boards");

            migrationBuilder.DropForeignKey(
                name: "FK__Boards__GameId__22751F6C",
                table: "Boards");

            migrationBuilder.DropForeignKey(
                name: "FK__BoardsMod__Board__236943A5",
                table: "BoardsModerators");

            migrationBuilder.DropForeignKey(
                name: "FK__BoardsMod__Moder__245D67DE",
                table: "BoardsModerators");

            migrationBuilder.DropForeignKey(
                name: "FK__BoardsMod__Appro__25518C17",
                table: "BoardsModeratorsApplications");

            migrationBuilder.DropForeignKey(
                name: "FK__BoardsMod__Backe__2645B050",
                table: "BoardsModeratorsApplications");

            migrationBuilder.DropForeignKey(
                name: "FK__BoardsMod__Board__2739D489",
                table: "BoardsModeratorsApplications");

            migrationBuilder.DropForeignKey(
                name: "FK__BoardsMod__Membe__282DF8C2",
                table: "BoardsModeratorsApplications");

            migrationBuilder.DropForeignKey(
                name: "FK__BucketLog__Backe__29221CFB",
                table: "BucketLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__BucketLog__Board__2A164134",
                table: "BucketLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__BucketLog__Bucke__2B0A656D",
                table: "BucketLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__BucketLog__Moder__2BFE89A6",
                table: "BucketLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__Carts__MemberId__2CF2ADDF",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK__Carts__ProductId__2DE6D218",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK__Coupons__Created__30C33EC3",
                table: "Coupons");

            migrationBuilder.DropForeignKey(
                name: "FK__Coupons__Discoun__31B762FC",
                table: "Coupons");

            migrationBuilder.DropForeignKey(
                name: "FK__Coupons__Modifie__32AB8735",
                table: "Coupons");

            migrationBuilder.DropForeignKey(
                name: "FK__CouponsPr__Coupo__339FAB6E",
                table: "CouponsProducts");

            migrationBuilder.DropForeignKey(
                name: "FK__CouponsPr__Produ__3493CFA7",
                table: "CouponsProducts");

            migrationBuilder.DropForeignKey(
                name: "FK__FAQ__IssueTypeId__3587F3E0",
                table: "FAQ");

            migrationBuilder.DropForeignKey(
                name: "FK__GameClass__GameC__367C1819",
                table: "GameClassificationGames");

            migrationBuilder.DropForeignKey(
                name: "FK__GameClass__GameI__37703C52",
                table: "GameClassificationGames");

            migrationBuilder.DropForeignKey(
                name: "FK__GameComme__Delet__3864608B",
                table: "GameComments");

            migrationBuilder.DropForeignKey(
                name: "FK__GameComme__GameI__395884C4",
                table: "GameComments");

            migrationBuilder.DropForeignKey(
                name: "FK__GameComme__Membe__3A4CA8FD",
                table: "GameComments");

            migrationBuilder.DropForeignKey(
                name: "FK__Games__CreatedBa__3B40CD36",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK__Games__ModifiedB__3C34F16F",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK__Inventory__Produ__3D2915A8",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK__Inventory__Stock__3E1D39E1",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK__Issues__IssueTyp__3F115E1A",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK__Issues__MemberId__40058253",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK__Issues__Status__40F9A68C",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK__MemberPro__Membe__43D61337",
                table: "MemberProductViews");

            migrationBuilder.DropForeignKey(
                name: "FK__MemberPro__Produ__44CA3770",
                table: "MemberProductViews");

            migrationBuilder.DropForeignKey(
                name: "FK__MembersBo__Board__45BE5BA9",
                table: "MembersBoards");

            migrationBuilder.DropForeignKey(
                name: "FK__MembersBo__Membe__46B27FE2",
                table: "MembersBoards");

            migrationBuilder.DropForeignKey(
                name: "FK__News__BackendMem__47A6A41B",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK__News__DeleteBack__489AC854",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK__News__GamesId__498EEC8D",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK__News__NewsCatego__4A8310C6",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsComme__Delet__4B7734FF",
                table: "NewsComments");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsComme__Delet__4C6B5938",
                table: "NewsComments");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsComme__Membe__4D5F7D71",
                table: "NewsComments");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsComme__NewsI__4E53A1AA",
                table: "NewsComments");

            migrationBuilder.DropForeignKey(
                name: "FK__Newslette__Addre__4F47C5E3",
                table: "NewsletterLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__Newslette__Newsl__503BEA1C",
                table: "NewsletterLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__Newslette__Backe__51300E55",
                table: "Newsletters");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsLikes__Membe__5224328E",
                table: "NewsLikes");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsLikes__NewsI__531856C7",
                table: "NewsLikes");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsViews__Membe__540C7B00",
                table: "NewsViews");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsViews__NewsI__55009F39",
                table: "NewsViews");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderItem__Order__4B7734FF",
                table: "OrderItemReturns");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderItem__Inven__4C6B5938",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderItem__Order__4D5F7D71",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderItem__Coupo__59C55456",
                table: "OrderItemsCoupons");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderItem__Order__503BEA1C",
                table: "OrderItemsCoupons");

            migrationBuilder.DropForeignKey(
                name: "FK__Orders__MemberId__51300E55",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK__Orders__OrderSta__5224328E",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK__Orders__PaymentS__531856C7",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK__Orders__Shipmemt__540C7B00",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK__Orders__Shipment__55009F39",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Membe__607251E5",
                table: "PostCommentReports");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__PostC__6166761E",
                table: "PostCommentReports");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Revie__625A9A57",
                table: "PostCommentReports");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Delet__634EBE90",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Delet__6442E2C9",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Membe__65370702",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Paren__662B2B3B",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__PostI__671F4F74",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Membe__681373AD",
                table: "PostCommentUpDownVotes");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__PostC__690797E6",
                table: "PostCommentUpDownVotes");

            migrationBuilder.DropForeignKey(
                name: "FK__PostEditL__PostI__69FBBC1F",
                table: "PostEditLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__PostRepor__Membe__6AEFE058",
                table: "PostReports");

            migrationBuilder.DropForeignKey(
                name: "FK__PostRepor__PostI__6BE40491",
                table: "PostReports");

            migrationBuilder.DropForeignKey(
                name: "FK__PostRepor__Revie__6CD828CA",
                table: "PostReports");

            migrationBuilder.DropForeignKey(
                name: "FK__Posts__BoardId__6DCC4D03",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK__Posts__DeleteBac__6EC0713C",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK__Posts__DeleteMem__6FB49575",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK__Posts__MemberId__70A8B9AE",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK__PostUpDow__Membe__719CDDE7",
                table: "PostUpDownVotes");

            migrationBuilder.DropForeignKey(
                name: "FK__PostUpDow__PostI__72910220",
                table: "PostUpDownVotes");

            migrationBuilder.DropForeignKey(
                name: "FK__ProductIm__Produ__73852659",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK__Products__Create__74794A92",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK__Products__GameId__756D6ECB",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK__Products__GamePl__76619304",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK__Products__Modifi__7755B73D",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK__Products__Produc__7849DB76",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK__Replies__Backend__793DFFAF",
                table: "Replies");

            migrationBuilder.DropForeignKey(
                name: "FK__Replies__IssueId__7A3223E8",
                table: "Replies");

            migrationBuilder.DropForeignKey(
                name: "FK__StandardP__Produ__7B264821",
                table: "StandardProducts");

            migrationBuilder.DropForeignKey(
                name: "FK__StockInSh__Stock__7C1A6C5A",
                table: "StockInSheets");

            migrationBuilder.DropForeignKey(
                name: "FK__StockInSh__Suppl__7D0E9093",
                table: "StockInSheets");

            migrationBuilder.DropTable(
                name: "BranchesOfSeven");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Supplier__3214EC075D35F1A7",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK__StockInS__3214EC07CE3D2F4B",
                table: "StockInStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__StockInS__3214EC07451B5458",
                table: "StockInSheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Standard__3214EC07F90F23CF",
                table: "StandardProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Shipment__3214EC07B6593D83",
                table: "ShipmentStatusesCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Shipmemt__3214EC0798A22433",
                table: "ShipmemtMethods");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Replies__3214EC073FF45844",
                table: "Replies");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ProductS__3214EC077E0F732B",
                table: "ProductStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Products__3214EC07D025225F",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ProductI__3214EC0790A3C058",
                table: "ProductImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostUpDo__3214EC07E318FA24",
                table: "PostUpDownVotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Posts__3214EC07B6970EB8",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostRepo__3214EC076E8A0162",
                table: "PostReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostEdit__3214EC073B0728BB",
                table: "PostEditLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostComm__3214EC07566423D2",
                table: "PostCommentUpDownVotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostComm__3214EC078141FA43",
                table: "PostComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostComm__3214EC07578E7724",
                table: "PostCommentReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PaymentS__3214EC077DE348A0",
                table: "PaymentStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__OrderSta__3214EC078374750A",
                table: "OrderStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Orders__3214EC0743A819E5",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShipmentMethodId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK__OrderIte__3214EC07B268D456",
                table: "OrderItemsCoupons");

            migrationBuilder.DropPrimaryKey(
                name: "PK__OrderIte__3214EC07A2DE618F",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "UQ__OrderIte__9A5B62295905CB9C",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK__OrderIte__3214EC07661B879E",
                table: "OrderItemReturns");

            migrationBuilder.DropIndex(
                name: "UQ__OrderIte__9A5B6229DB395A7A",
                table: "OrderItemReturns");

            migrationBuilder.DropPrimaryKey(
                name: "PK__NewsView__3214EC072421AD95",
                table: "NewsViews");

            migrationBuilder.DropPrimaryKey(
                name: "PK__NewsLike__3214EC07FA3D0592",
                table: "NewsLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Newslett__3214EC07D17703F2",
                table: "Newsletters");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Newslett__3214EC07A074AF56",
                table: "NewsletterLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK__NewsComm__3214EC07D8BCCD4E",
                table: "NewsComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__NewsCate__3214EC07FBFA876E",
                table: "NewsCategoryCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__News__3214EC0731D7F77E",
                table: "News");

            migrationBuilder.DropPrimaryKey(
                name: "PK__MembersB__3214EC07B1ED6A41",
                table: "MembersBoards");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Members__3214EC070EDCD496",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK__MemberPr__3214EC070F38C7D0",
                table: "MemberProductViews");

            migrationBuilder.DropIndex(
                name: "IX_MemberFollows_FollowerMemberId",
                table: "MemberFollows");

            migrationBuilder.DropPrimaryKey(
                name: "PK__IssueTyp__3214EC0795528B63",
                table: "IssueTypesCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__IssueSta__3214EC07F66ED952",
                table: "IssueStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Issues__3214EC0706CA3A80",
                table: "Issues");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Inventor__3214EC072349E96D",
                table: "InventoryItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Games__3214EC0720EF07B1",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GamePlat__3214EC0717264051",
                table: "GamePlatformsCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GameComm__3214EC07A9D5AF1B",
                table: "GameComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GameClas__3214EC070465DA72",
                table: "GameClassificationsCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GameClas__3214EC0767D415B9",
                table: "GameClassificationGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK__FAQ__3214EC07017B8F0A",
                table: "FAQ");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Discount__3214EC07CD3A91A4",
                table: "DiscountTypeCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__CouponsP__3214EC0773784635",
                table: "CouponsProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Coupons__3214EC07B2D24C1C",
                table: "Coupons");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Carts__3214EC074368D617",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BucketLo__3214EC07D98AE89A",
                table: "BucketLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BoardsMo__3214EC07EDE45AF3",
                table: "BoardsModeratorsApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BoardsMo__3214EC07A3EEEF55",
                table: "BoardsModerators");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Boards__3214EC072A2E93A0",
                table: "Boards");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BackendM__3214EC07B421B667",
                table: "BackendMembersRolesCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BackendM__3214EC07E8CB4E9D",
                table: "BackendMembersRolePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BackendM__3214EC07595F3723",
                table: "BackendMembersPermissionsCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BackendM__3214EC072F7D7E6F",
                table: "BackendMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Approval__3214EC0754FC873C",
                table: "ApprovalStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Announce__3214EC0791CEBBD7",
                table: "Announcement");

            migrationBuilder.DropColumn(
                name: "ShipmentMethodId",
                table: "Orders");

            migrationBuilder.EnsureSchema(
                name: "HangFire");

            migrationBuilder.RenameIndex(
                name: "UQ__StockInS__9A5B62297753599F",
                table: "StockInSheets",
                newName: "UQ__StockInS__9A5B62291521DBDE");

            migrationBuilder.RenameIndex(
                name: "UQ__Shipmemt__737584F6A6227A50",
                table: "ShipmemtMethods",
                newName: "UQ__Shipmemt__737584F60A26FFD2");

            migrationBuilder.RenameIndex(
                name: "UQ__Products__9A5B6229D5BCEABA",
                table: "Products",
                newName: "UQ__Products__9A5B6229FEB5BAD5");

            migrationBuilder.RenameColumn(
                name: "ShippingFee",
                table: "Orders",
                newName: "ShipmemtMethodId");

            migrationBuilder.RenameIndex(
                name: "UQ__Orders__9A5B62299A9DCB7B",
                table: "Orders",
                newName: "UQ__Orders__9A5B622990CDB978");

            migrationBuilder.RenameIndex(
                name: "UQ__OrderIte__3BB2AC81819DD448",
                table: "OrderItems",
                newName: "UQ__OrderIte__3BB2AC81B62FFB01");

            migrationBuilder.RenameIndex(
                name: "UQ__OrderIte__57ED0680FBF10CC1",
                table: "OrderItemReturns",
                newName: "UQ__OrderIte__57ED068035C18F11");

            migrationBuilder.RenameIndex(
                name: "UQ__Inventor__9A5B622901E60557",
                table: "InventoryItems",
                newName: "UQ__Inventor__9A5B622972C68AC9");

            migrationBuilder.AlterColumn<string>(
                name: "ToAddress",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Index",
                table: "Orders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Index",
                table: "OrderItems",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Supplier__3214EC077973F9DE",
                table: "Suppliers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__StockInS__3214EC07EEDC7769",
                table: "StockInStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__StockInS__3214EC07405F71E2",
                table: "StockInSheets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Standard__3214EC07394EA72A",
                table: "StandardProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Shipment__3214EC0783E040BB",
                table: "ShipmentStatusesCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Shipmemt__3214EC072A3C39EB",
                table: "ShipmemtMethods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Replies__3214EC07E0D2B380",
                table: "Replies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ProductS__3214EC07202FDD88",
                table: "ProductStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Products__3214EC07507639E1",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ProductI__3214EC07C114CDBC",
                table: "ProductImages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostUpDo__3214EC0798F19DA5",
                table: "PostUpDownVotes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Posts__3214EC070101E7C8",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostRepo__3214EC07837449D8",
                table: "PostReports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostEdit__3214EC0739372863",
                table: "PostEditLogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostComm__3214EC0768F595DB",
                table: "PostCommentUpDownVotes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostComm__3214EC0735E155C2",
                table: "PostComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostComm__3214EC07BC4E1A13",
                table: "PostCommentReports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PaymentS__3214EC073A00A45F",
                table: "PaymentStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__OrderSta__3214EC07116072B2",
                table: "OrderStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Orders__3214EC07DF813A2D",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__OrderIte__3214EC07028DD9F0",
                table: "OrderItemsCoupons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__OrderIte__3214EC070746D7D1",
                table: "OrderItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__OrderIte__3214EC07BAF73361",
                table: "OrderItemReturns",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__NewsView__3214EC071B0EB1D3",
                table: "NewsViews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__NewsLike__3214EC079C5BAFB7",
                table: "NewsLikes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Newslett__3214EC07B74A28C2",
                table: "Newsletters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Newslett__3214EC075560C131",
                table: "NewsletterLogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__NewsComm__3214EC07B86D4C6D",
                table: "NewsComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__NewsCate__3214EC07149DD1A7",
                table: "NewsCategoryCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__News__3214EC077971DE77",
                table: "News",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__MembersB__3214EC07DF629D3A",
                table: "MembersBoards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Members__3214EC0760DA1704",
                table: "Members",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__MemberPr__3214EC07122BAD8E",
                table: "MemberProductViews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__IssueTyp__3214EC073A96082D",
                table: "IssueTypesCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__IssueSta__3214EC0732E24D0D",
                table: "IssueStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Issues__3214EC07E064CBDC",
                table: "Issues",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Inventor__3214EC07D55DED24",
                table: "InventoryItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Games__3214EC073A5B26DD",
                table: "Games",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GamePlat__3214EC07726ACF89",
                table: "GamePlatformsCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GameComm__3214EC0735481931",
                table: "GameComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GameClas__3214EC071F6A6303",
                table: "GameClassificationsCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GameClas__3214EC0701057A73",
                table: "GameClassificationGames",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__FAQ__3214EC07877B16E5",
                table: "FAQ",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Discount__3214EC077F687773",
                table: "DiscountTypeCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__CouponsP__3214EC07C88DE8CA",
                table: "CouponsProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Coupons__3214EC070BBE66AE",
                table: "Coupons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Carts__3214EC0737297441",
                table: "Carts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BucketLo__3214EC0744D24644",
                table: "BucketLogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BoardsMo__3214EC075E99A5C9",
                table: "BoardsModeratorsApplications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BoardsMo__3214EC0799961D35",
                table: "BoardsModerators",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Boards__3214EC07ABB99035",
                table: "Boards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BackendM__3214EC07B83CD97C",
                table: "BackendMembersRolesCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BackendM__3214EC0729845EFD",
                table: "BackendMembersRolePermissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BackendM__3214EC07DF219F93",
                table: "BackendMembersPermissionsCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BackendM__3214EC07E57DEEED",
                table: "BackendMembers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Approval__3214EC07EB753EFC",
                table: "ApprovalStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Announce__3214EC074FD2771D",
                table: "Announcement",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AggregatedCounter",
                schema: "HangFire",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Value = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangFire_CounterAggregated", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Counter",
                schema: "HangFire",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpireAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangFire_Counter", x => new { x.Key, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "Hash",
                schema: "HangFire",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Field = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangFire_Hash", x => new { x.Key, x.Field });
                });

            migrationBuilder.CreateTable(
                name: "Job",
                schema: "HangFire",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Arguments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    InvocationData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateId = table.Column<long>(type: "bigint", nullable: true),
                    StateName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangFire_Job", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobQueue",
                schema: "HangFire",
                columns: table => new
                {
                    Queue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FetchedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    JobId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangFire_JobQueue", x => new { x.Queue, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "List",
                schema: "HangFire",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpireAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangFire_List", x => new { x.Key, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "Schema",
                schema: "HangFire",
                columns: table => new
                {
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangFire_Schema", x => x.Version);
                });

            migrationBuilder.CreateTable(
                name: "Server",
                schema: "HangFire",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastHeartbeat = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangFire_Server", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Set",
                schema: "HangFire",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Score = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangFire_Set", x => new { x.Key, x.Value });
                });

            migrationBuilder.CreateTable(
                name: "JobParameter",
                schema: "HangFire",
                columns: table => new
                {
                    JobId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangFire_JobParameter", x => new { x.JobId, x.Name });
                    table.ForeignKey(
                        name: "FK_HangFire_JobParameter_Job",
                        column: x => x.JobId,
                        principalSchema: "HangFire",
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "State",
                schema: "HangFire",
                columns: table => new
                {
                    JobId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangFire_State", x => new { x.JobId, x.Id });
                    table.ForeignKey(
                        name: "FK_HangFire_State_Job",
                        column: x => x.JobId,
                        principalSchema: "HangFire",
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipmemtMethodId",
                table: "Orders",
                column: "ShipmemtMethodId");

            migrationBuilder.CreateIndex(
                name: "UQ__OrderIte__9A5B622987053FBF",
                table: "OrderItems",
                column: "Index",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__OrderIte__9A5B622998CBDD5F",
                table: "OrderItemReturns",
                column: "Index",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UcMemberFollow",
                table: "MemberFollows",
                columns: new[] { "FollowerMemberId", "FollowedMemberId" },
                unique: true,
                filter: "[FollowerMemberId] IS NOT NULL AND [FollowedMemberId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HangFire_AggregatedCounter_ExpireAt",
                schema: "HangFire",
                table: "AggregatedCounter",
                column: "ExpireAt",
                filter: "([ExpireAt] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_HangFire_Hash_ExpireAt",
                schema: "HangFire",
                table: "Hash",
                column: "ExpireAt",
                filter: "([ExpireAt] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_HangFire_Job_ExpireAt",
                schema: "HangFire",
                table: "Job",
                column: "ExpireAt",
                filter: "([ExpireAt] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_HangFire_Job_StateName",
                schema: "HangFire",
                table: "Job",
                column: "StateName",
                filter: "([StateName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_HangFire_List_ExpireAt",
                schema: "HangFire",
                table: "List",
                column: "ExpireAt",
                filter: "([ExpireAt] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_HangFire_Server_LastHeartbeat",
                schema: "HangFire",
                table: "Server",
                column: "LastHeartbeat");

            migrationBuilder.CreateIndex(
                name: "IX_HangFire_Set_ExpireAt",
                schema: "HangFire",
                table: "Set",
                column: "ExpireAt",
                filter: "([ExpireAt] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_HangFire_Set_Score",
                schema: "HangFire",
                table: "Set",
                columns: new[] { "Key", "Score" });

            migrationBuilder.CreateIndex(
                name: "IX_HangFire_State_CreatedAt",
                schema: "HangFire",
                table: "State",
                column: "CreatedAt");

            migrationBuilder.AddForeignKey(
                name: "FK__BackendMe__Backe__2B0A656D",
                table: "BackendMembers",
                column: "BackendMembersRoleId",
                principalTable: "BackendMembersRolesCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BackendMe__Backe__2BFE89A6",
                table: "BackendMembersRolePermissions",
                column: "BackendMembersRoleId",
                principalTable: "BackendMembersRolesCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BackendMe__Backe__2CF2ADDF",
                table: "BackendMembersRolePermissions",
                column: "BackendMemberPermissionId",
                principalTable: "BackendMembersPermissionsCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Boards__CreatedB__2DE6D218",
                table: "Boards",
                column: "CreatedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Boards__GameId__2EDAF651",
                table: "Boards",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BoardsMod__Board__2FCF1A8A",
                table: "BoardsModerators",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BoardsMod__Moder__30C33EC3",
                table: "BoardsModerators",
                column: "ModeratorMemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BoardsMod__Appro__31B762FC",
                table: "BoardsModeratorsApplications",
                column: "ApprovalStatusId",
                principalTable: "ApprovalStatusCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BoardsMod__Backe__32AB8735",
                table: "BoardsModeratorsApplications",
                column: "BackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BoardsMod__Board__339FAB6E",
                table: "BoardsModeratorsApplications",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BoardsMod__Membe__3493CFA7",
                table: "BoardsModeratorsApplications",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BucketLog__Backe__3587F3E0",
                table: "BucketLogs",
                column: "BackendMmemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BucketLog__Board__367C1819",
                table: "BucketLogs",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BucketLog__Bucke__37703C52",
                table: "BucketLogs",
                column: "BucketMemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BucketLog__Moder__3864608B",
                table: "BucketLogs",
                column: "ModeratorMemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Carts__MemberId__395884C4",
                table: "Carts",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Carts__ProductId__3A4CA8FD",
                table: "Carts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Coupons__Created__3B40CD36",
                table: "Coupons",
                column: "CreatedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Coupons__Discoun__3C34F16F",
                table: "Coupons",
                column: "DiscountTypeId",
                principalTable: "DiscountTypeCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Coupons__Modifie__3D2915A8",
                table: "Coupons",
                column: "ModifiedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__CouponsPr__Coupo__3E1D39E1",
                table: "CouponsProducts",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__CouponsPr__Produ__3F115E1A",
                table: "CouponsProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__FAQ__IssueTypeId__40058253",
                table: "FAQ",
                column: "IssueTypeId",
                principalTable: "IssueTypesCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__GameClass__GameC__40F9A68C",
                table: "GameClassificationGames",
                column: "GameClassificationId",
                principalTable: "GameClassificationsCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__GameClass__GameI__41EDCAC5",
                table: "GameClassificationGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__GameComme__Delet__42E1EEFE",
                table: "GameComments",
                column: "DeleteBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__GameComme__GameI__43D61337",
                table: "GameComments",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__GameComme__Membe__44CA3770",
                table: "GameComments",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Games__CreatedBa__45BE5BA9",
                table: "Games",
                column: "CreatedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Games__ModifiedB__46B27FE2",
                table: "Games",
                column: "ModifiedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Inventory__Produ__47A6A41B",
                table: "InventoryItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Inventory__Stock__489AC854",
                table: "InventoryItems",
                column: "StockInSheetId",
                principalTable: "StockInSheets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Issues__IssueTyp__498EEC8D",
                table: "Issues",
                column: "IssueTypeId",
                principalTable: "IssueTypesCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Issues__MemberId__4A8310C6",
                table: "Issues",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Issues__Status__4B7734FF",
                table: "Issues",
                column: "Status",
                principalTable: "IssueStatusCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MemberPro__Membe__4C6B5938",
                table: "MemberProductViews",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MemberPro__Produ__4D5F7D71",
                table: "MemberProductViews",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MembersBo__Board__4E53A1AA",
                table: "MembersBoards",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MembersBo__Membe__4F47C5E3",
                table: "MembersBoards",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__News__BackendMem__503BEA1C",
                table: "News",
                column: "BackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__News__DeleteBack__51300E55",
                table: "News",
                column: "DeleteBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__News__GamesId__5224328E",
                table: "News",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__News__NewsCatego__531856C7",
                table: "News",
                column: "NewsCategoryId",
                principalTable: "NewsCategoryCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsComme__Delet__540C7B00",
                table: "NewsComments",
                column: "DeleteMemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsComme__Delet__55009F39",
                table: "NewsComments",
                column: "DeleteBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsComme__Membe__55F4C372",
                table: "NewsComments",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsComme__NewsI__56E8E7AB",
                table: "NewsComments",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Newslette__Addre__57DD0BE4",
                table: "NewsletterLogs",
                column: "AddresseeMemberID",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Newslette__Newsl__58D1301D",
                table: "NewsletterLogs",
                column: "NewsletterId",
                principalTable: "Newsletters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Newslette__Backe__59C55456",
                table: "Newsletters",
                column: "BackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsLikes__Membe__5AB9788F",
                table: "NewsLikes",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsLikes__NewsI__5BAD9CC8",
                table: "NewsLikes",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsViews__Membe__5CA1C101",
                table: "NewsViews",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsViews__NewsI__5D95E53A",
                table: "NewsViews",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderItem__Order__5E8A0973",
                table: "OrderItemReturns",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderItem__Inven__5F7E2DAC",
                table: "OrderItems",
                column: "InventoryItemId",
                principalTable: "InventoryItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderItem__Order__607251E5",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderItem__Coupo__625A9A57",
                table: "OrderItemsCoupons",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderItem__Order__634EBE90",
                table: "OrderItemsCoupons",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Orders__MemberId__6442E2C9",
                table: "Orders",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Orders__OrderSta__65370702",
                table: "Orders",
                column: "OrderStatusId",
                principalTable: "OrderStatusCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Orders__PaymentS__662B2B3B",
                table: "Orders",
                column: "PaymentStatusId",
                principalTable: "PaymentStatusCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Orders__Shipmemt__671F4F74",
                table: "Orders",
                column: "ShipmemtMethodId",
                principalTable: "ShipmemtMethods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Orders__Shipment__681373AD",
                table: "Orders",
                column: "ShipmentStatusId",
                principalTable: "ShipmentStatusesCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Membe__690797E6",
                table: "PostCommentReports",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__PostC__69FBBC1F",
                table: "PostCommentReports",
                column: "PostCommentId",
                principalTable: "PostComments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Revie__6AEFE058",
                table: "PostCommentReports",
                column: "ReviewerBackenMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Delet__6BE40491",
                table: "PostComments",
                column: "DeleteMemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Delet__6CD828CA",
                table: "PostComments",
                column: "DeleteBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Membe__6DCC4D03",
                table: "PostComments",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Paren__6EC0713C",
                table: "PostComments",
                column: "ParentId",
                principalTable: "PostComments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__PostI__6FB49575",
                table: "PostComments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Membe__70A8B9AE",
                table: "PostCommentUpDownVotes",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__PostC__719CDDE7",
                table: "PostCommentUpDownVotes",
                column: "PostCommentId",
                principalTable: "PostComments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostEditL__PostI__72910220",
                table: "PostEditLogs",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostRepor__Membe__73852659",
                table: "PostReports",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostRepor__PostI__74794A92",
                table: "PostReports",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostRepor__Revie__756D6ECB",
                table: "PostReports",
                column: "ReviewerBackenMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Posts__BoardId__76619304",
                table: "Posts",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Posts__DeleteBac__7755B73D",
                table: "Posts",
                column: "DeleteBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Posts__DeleteMem__7849DB76",
                table: "Posts",
                column: "DeleteMemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Posts__MemberId__793DFFAF",
                table: "Posts",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostUpDow__Membe__7A3223E8",
                table: "PostUpDownVotes",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostUpDow__PostI__7B264821",
                table: "PostUpDownVotes",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__ProductIm__Produ__7C1A6C5A",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Products__Create__7D0E9093",
                table: "Products",
                column: "CreatedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Products__GameId__7E02B4CC",
                table: "Products",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Products__GamePl__7EF6D905",
                table: "Products",
                column: "GamePlatformId",
                principalTable: "GamePlatformsCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Products__Modifi__7FEAFD3E",
                table: "Products",
                column: "ModifiedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Products__Produc__00DF2177",
                table: "Products",
                column: "ProductStatusId",
                principalTable: "ProductStatusCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Replies__Backend__01D345B0",
                table: "Replies",
                column: "BackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Replies__IssueId__02C769E9",
                table: "Replies",
                column: "IssueId",
                principalTable: "Issues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__StandardP__Produ__03BB8E22",
                table: "StandardProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__StockInSh__Stock__04AFB25B",
                table: "StockInSheets",
                column: "StockInStatusId",
                principalTable: "StockInStatusCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__StockInSh__Suppl__05A3D694",
                table: "StockInSheets",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }
    }
}
