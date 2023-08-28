using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TataGamedomWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddLinePayConfirmResponseToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK__OrderItem__Coupo__59C55456",
                table: "OrderItemsCoupons");

            migrationBuilder.DropForeignKey(
                name: "FK__Orders__Shipmemt__540C7B00",
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
                name: "ShipmemtMethods");

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
                name: "PK__OrderIte__3214EC07B268D456",
                table: "OrderItemsCoupons");

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

            migrationBuilder.RenameIndex(
                name: "UQ__StockInS__9A5B62297753599F",
                table: "StockInSheets",
                newName: "UQ__StockInS__9A5B6229BFDC8634");

            migrationBuilder.RenameIndex(
                name: "UQ__Products__9A5B6229D5BCEABA",
                table: "Products",
                newName: "UQ__Products__9A5B622984F05647");

            migrationBuilder.RenameIndex(
                name: "UQ__Inventor__9A5B622901E60557",
                table: "InventoryItems",
                newName: "UQ__Inventor__9A5B62292F47BB4A");

            migrationBuilder.AddColumn<string>(
                name: "LinePayTransactionId",
                table: "Orders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaskedCreditCardNumber",
                table: "Orders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaidAt",
                table: "Orders",
                type: "datetime",
                nullable: true);

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

            migrationBuilder.CreateTable(
                name: "ShipmentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(8,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Shipmemt__3214EC0763A0B057", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Shipmemt__737584F6BB624A36",
                table: "ShipmentMethods",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK__BackendMe__Backe__31B762FC",
                table: "BackendMembers",
                column: "BackendMembersRoleId",
                principalTable: "BackendMembersRolesCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BackendMe__Backe__32AB8735",
                table: "BackendMembersRolePermissions",
                column: "BackendMembersRoleId",
                principalTable: "BackendMembersRolesCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BackendMe__Backe__339FAB6E",
                table: "BackendMembersRolePermissions",
                column: "BackendMemberPermissionId",
                principalTable: "BackendMembersPermissionsCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Boards__CreatedB__3493CFA7",
                table: "Boards",
                column: "CreatedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Boards__GameId__3587F3E0",
                table: "Boards",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BoardsMod__Board__367C1819",
                table: "BoardsModerators",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BoardsMod__Moder__37703C52",
                table: "BoardsModerators",
                column: "ModeratorMemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BoardsMod__Appro__3864608B",
                table: "BoardsModeratorsApplications",
                column: "ApprovalStatusId",
                principalTable: "ApprovalStatusCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BoardsMod__Backe__395884C4",
                table: "BoardsModeratorsApplications",
                column: "BackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BoardsMod__Board__3A4CA8FD",
                table: "BoardsModeratorsApplications",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BoardsMod__Membe__3B40CD36",
                table: "BoardsModeratorsApplications",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BucketLog__Backe__3C34F16F",
                table: "BucketLogs",
                column: "BackendMmemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BucketLog__Board__3D2915A8",
                table: "BucketLogs",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BucketLog__Bucke__3E1D39E1",
                table: "BucketLogs",
                column: "BucketMemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BucketLog__Moder__3F115E1A",
                table: "BucketLogs",
                column: "ModeratorMemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Carts__MemberId__40058253",
                table: "Carts",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Carts__ProductId__40F9A68C",
                table: "Carts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Coupons__Created__43D61337",
                table: "Coupons",
                column: "CreatedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Coupons__Discoun__44CA3770",
                table: "Coupons",
                column: "DiscountTypeId",
                principalTable: "DiscountTypeCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Coupons__Modifie__45BE5BA9",
                table: "Coupons",
                column: "ModifiedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__CouponsPr__Coupo__46B27FE2",
                table: "CouponsProducts",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__CouponsPr__Produ__47A6A41B",
                table: "CouponsProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__FAQ__IssueTypeId__489AC854",
                table: "FAQ",
                column: "IssueTypeId",
                principalTable: "IssueTypesCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__GameClass__GameC__498EEC8D",
                table: "GameClassificationGames",
                column: "GameClassificationId",
                principalTable: "GameClassificationsCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__GameClass__GameI__4A8310C6",
                table: "GameClassificationGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__GameComme__Delet__4B7734FF",
                table: "GameComments",
                column: "DeleteBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__GameComme__GameI__4C6B5938",
                table: "GameComments",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__GameComme__Membe__4D5F7D71",
                table: "GameComments",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Games__CreatedBa__4E53A1AA",
                table: "Games",
                column: "CreatedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Games__ModifiedB__4F47C5E3",
                table: "Games",
                column: "ModifiedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Inventory__Produ__503BEA1C",
                table: "InventoryItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Inventory__Stock__51300E55",
                table: "InventoryItems",
                column: "StockInSheetId",
                principalTable: "StockInSheets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Issues__IssueTyp__5224328E",
                table: "Issues",
                column: "IssueTypeId",
                principalTable: "IssueTypesCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Issues__MemberId__531856C7",
                table: "Issues",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Issues__Status__540C7B00",
                table: "Issues",
                column: "Status",
                principalTable: "IssueStatusCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MemberPro__Membe__56E8E7AB",
                table: "MemberProductViews",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MemberPro__Produ__57DD0BE4",
                table: "MemberProductViews",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MembersBo__Board__58D1301D",
                table: "MembersBoards",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MembersBo__Membe__59C55456",
                table: "MembersBoards",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__News__BackendMem__5AB9788F",
                table: "News",
                column: "BackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__News__DeleteBack__5BAD9CC8",
                table: "News",
                column: "DeleteBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__News__GamesId__5CA1C101",
                table: "News",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__News__NewsCatego__5D95E53A",
                table: "News",
                column: "NewsCategoryId",
                principalTable: "NewsCategoryCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsComme__Delet__5E8A0973",
                table: "NewsComments",
                column: "DeleteMemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsComme__Delet__5F7E2DAC",
                table: "NewsComments",
                column: "DeleteBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsComme__Membe__607251E5",
                table: "NewsComments",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsComme__NewsI__6166761E",
                table: "NewsComments",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Newslette__Addre__625A9A57",
                table: "NewsletterLogs",
                column: "AddresseeMemberID",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Newslette__Newsl__634EBE90",
                table: "NewsletterLogs",
                column: "NewsletterId",
                principalTable: "Newsletters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Newslette__Backe__6442E2C9",
                table: "Newsletters",
                column: "BackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsLikes__Membe__65370702",
                table: "NewsLikes",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsLikes__NewsI__662B2B3B",
                table: "NewsLikes",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsViews__Membe__671F4F74",
                table: "NewsViews",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsViews__NewsI__681373AD",
                table: "NewsViews",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderItem__Coupo__6CD828CA",
                table: "OrderItemsCoupons",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Orders__Shipmemt__540C7B00",
                table: "Orders",
                column: "ShipmentMethodId",
                principalTable: "ShipmentMethods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Membe__73852659",
                table: "PostCommentReports",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__PostC__74794A92",
                table: "PostCommentReports",
                column: "PostCommentId",
                principalTable: "PostComments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Revie__756D6ECB",
                table: "PostCommentReports",
                column: "ReviewerBackenMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Delet__76619304",
                table: "PostComments",
                column: "DeleteMemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Delet__7755B73D",
                table: "PostComments",
                column: "DeleteBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Membe__7849DB76",
                table: "PostComments",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Paren__793DFFAF",
                table: "PostComments",
                column: "ParentId",
                principalTable: "PostComments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__PostI__7A3223E8",
                table: "PostComments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Membe__7B264821",
                table: "PostCommentUpDownVotes",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__PostC__7C1A6C5A",
                table: "PostCommentUpDownVotes",
                column: "PostCommentId",
                principalTable: "PostComments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostEditL__PostI__7D0E9093",
                table: "PostEditLogs",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostRepor__Membe__7E02B4CC",
                table: "PostReports",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostRepor__PostI__7EF6D905",
                table: "PostReports",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostRepor__Revie__7FEAFD3E",
                table: "PostReports",
                column: "ReviewerBackenMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Posts__BoardId__00DF2177",
                table: "Posts",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Posts__DeleteBac__01D345B0",
                table: "Posts",
                column: "DeleteBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Posts__DeleteMem__02C769E9",
                table: "Posts",
                column: "DeleteMemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Posts__MemberId__03BB8E22",
                table: "Posts",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostUpDow__Membe__04AFB25B",
                table: "PostUpDownVotes",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostUpDow__PostI__05A3D694",
                table: "PostUpDownVotes",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__ProductIm__Produ__0697FACD",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Products__Create__078C1F06",
                table: "Products",
                column: "CreatedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Products__GameId__0880433F",
                table: "Products",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Products__GamePl__09746778",
                table: "Products",
                column: "GamePlatformId",
                principalTable: "GamePlatformsCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Products__Modifi__0A688BB1",
                table: "Products",
                column: "ModifiedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Products__Produc__0B5CAFEA",
                table: "Products",
                column: "ProductStatusId",
                principalTable: "ProductStatusCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Replies__Backend__0C50D423",
                table: "Replies",
                column: "BackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Replies__IssueId__0D44F85C",
                table: "Replies",
                column: "IssueId",
                principalTable: "Issues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__StandardP__Produ__0E391C95",
                table: "StandardProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__StockInSh__Stock__0F2D40CE",
                table: "StockInSheets",
                column: "StockInStatusId",
                principalTable: "StockInStatusCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__StockInSh__Suppl__10216507",
                table: "StockInSheets",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__BackendMe__Backe__31B762FC",
                table: "BackendMembers");

            migrationBuilder.DropForeignKey(
                name: "FK__BackendMe__Backe__32AB8735",
                table: "BackendMembersRolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK__BackendMe__Backe__339FAB6E",
                table: "BackendMembersRolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK__Boards__CreatedB__3493CFA7",
                table: "Boards");

            migrationBuilder.DropForeignKey(
                name: "FK__Boards__GameId__3587F3E0",
                table: "Boards");

            migrationBuilder.DropForeignKey(
                name: "FK__BoardsMod__Board__367C1819",
                table: "BoardsModerators");

            migrationBuilder.DropForeignKey(
                name: "FK__BoardsMod__Moder__37703C52",
                table: "BoardsModerators");

            migrationBuilder.DropForeignKey(
                name: "FK__BoardsMod__Appro__3864608B",
                table: "BoardsModeratorsApplications");

            migrationBuilder.DropForeignKey(
                name: "FK__BoardsMod__Backe__395884C4",
                table: "BoardsModeratorsApplications");

            migrationBuilder.DropForeignKey(
                name: "FK__BoardsMod__Board__3A4CA8FD",
                table: "BoardsModeratorsApplications");

            migrationBuilder.DropForeignKey(
                name: "FK__BoardsMod__Membe__3B40CD36",
                table: "BoardsModeratorsApplications");

            migrationBuilder.DropForeignKey(
                name: "FK__BucketLog__Backe__3C34F16F",
                table: "BucketLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__BucketLog__Board__3D2915A8",
                table: "BucketLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__BucketLog__Bucke__3E1D39E1",
                table: "BucketLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__BucketLog__Moder__3F115E1A",
                table: "BucketLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__Carts__MemberId__40058253",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK__Carts__ProductId__40F9A68C",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK__Coupons__Created__43D61337",
                table: "Coupons");

            migrationBuilder.DropForeignKey(
                name: "FK__Coupons__Discoun__44CA3770",
                table: "Coupons");

            migrationBuilder.DropForeignKey(
                name: "FK__Coupons__Modifie__45BE5BA9",
                table: "Coupons");

            migrationBuilder.DropForeignKey(
                name: "FK__CouponsPr__Coupo__46B27FE2",
                table: "CouponsProducts");

            migrationBuilder.DropForeignKey(
                name: "FK__CouponsPr__Produ__47A6A41B",
                table: "CouponsProducts");

            migrationBuilder.DropForeignKey(
                name: "FK__FAQ__IssueTypeId__489AC854",
                table: "FAQ");

            migrationBuilder.DropForeignKey(
                name: "FK__GameClass__GameC__498EEC8D",
                table: "GameClassificationGames");

            migrationBuilder.DropForeignKey(
                name: "FK__GameClass__GameI__4A8310C6",
                table: "GameClassificationGames");

            migrationBuilder.DropForeignKey(
                name: "FK__GameComme__Delet__4B7734FF",
                table: "GameComments");

            migrationBuilder.DropForeignKey(
                name: "FK__GameComme__GameI__4C6B5938",
                table: "GameComments");

            migrationBuilder.DropForeignKey(
                name: "FK__GameComme__Membe__4D5F7D71",
                table: "GameComments");

            migrationBuilder.DropForeignKey(
                name: "FK__Games__CreatedBa__4E53A1AA",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK__Games__ModifiedB__4F47C5E3",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK__Inventory__Produ__503BEA1C",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK__Inventory__Stock__51300E55",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK__Issues__IssueTyp__5224328E",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK__Issues__MemberId__531856C7",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK__Issues__Status__540C7B00",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK__MemberPro__Membe__56E8E7AB",
                table: "MemberProductViews");

            migrationBuilder.DropForeignKey(
                name: "FK__MemberPro__Produ__57DD0BE4",
                table: "MemberProductViews");

            migrationBuilder.DropForeignKey(
                name: "FK__MembersBo__Board__58D1301D",
                table: "MembersBoards");

            migrationBuilder.DropForeignKey(
                name: "FK__MembersBo__Membe__59C55456",
                table: "MembersBoards");

            migrationBuilder.DropForeignKey(
                name: "FK__News__BackendMem__5AB9788F",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK__News__DeleteBack__5BAD9CC8",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK__News__GamesId__5CA1C101",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK__News__NewsCatego__5D95E53A",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsComme__Delet__5E8A0973",
                table: "NewsComments");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsComme__Delet__5F7E2DAC",
                table: "NewsComments");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsComme__Membe__607251E5",
                table: "NewsComments");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsComme__NewsI__6166761E",
                table: "NewsComments");

            migrationBuilder.DropForeignKey(
                name: "FK__Newslette__Addre__625A9A57",
                table: "NewsletterLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__Newslette__Newsl__634EBE90",
                table: "NewsletterLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__Newslette__Backe__6442E2C9",
                table: "Newsletters");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsLikes__Membe__65370702",
                table: "NewsLikes");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsLikes__NewsI__662B2B3B",
                table: "NewsLikes");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsViews__Membe__671F4F74",
                table: "NewsViews");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsViews__NewsI__681373AD",
                table: "NewsViews");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderItem__Coupo__6CD828CA",
                table: "OrderItemsCoupons");

            migrationBuilder.DropForeignKey(
                name: "FK__Orders__Shipmemt__540C7B00",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Membe__73852659",
                table: "PostCommentReports");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__PostC__74794A92",
                table: "PostCommentReports");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Revie__756D6ECB",
                table: "PostCommentReports");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Delet__76619304",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Delet__7755B73D",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Membe__7849DB76",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Paren__793DFFAF",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__PostI__7A3223E8",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Membe__7B264821",
                table: "PostCommentUpDownVotes");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__PostC__7C1A6C5A",
                table: "PostCommentUpDownVotes");

            migrationBuilder.DropForeignKey(
                name: "FK__PostEditL__PostI__7D0E9093",
                table: "PostEditLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__PostRepor__Membe__7E02B4CC",
                table: "PostReports");

            migrationBuilder.DropForeignKey(
                name: "FK__PostRepor__PostI__7EF6D905",
                table: "PostReports");

            migrationBuilder.DropForeignKey(
                name: "FK__PostRepor__Revie__7FEAFD3E",
                table: "PostReports");

            migrationBuilder.DropForeignKey(
                name: "FK__Posts__BoardId__00DF2177",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK__Posts__DeleteBac__01D345B0",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK__Posts__DeleteMem__02C769E9",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK__Posts__MemberId__03BB8E22",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK__PostUpDow__Membe__04AFB25B",
                table: "PostUpDownVotes");

            migrationBuilder.DropForeignKey(
                name: "FK__PostUpDow__PostI__05A3D694",
                table: "PostUpDownVotes");

            migrationBuilder.DropForeignKey(
                name: "FK__ProductIm__Produ__0697FACD",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK__Products__Create__078C1F06",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK__Products__GameId__0880433F",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK__Products__GamePl__09746778",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK__Products__Modifi__0A688BB1",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK__Products__Produc__0B5CAFEA",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK__Replies__Backend__0C50D423",
                table: "Replies");

            migrationBuilder.DropForeignKey(
                name: "FK__Replies__IssueId__0D44F85C",
                table: "Replies");

            migrationBuilder.DropForeignKey(
                name: "FK__StandardP__Produ__0E391C95",
                table: "StandardProducts");

            migrationBuilder.DropForeignKey(
                name: "FK__StockInSh__Stock__0F2D40CE",
                table: "StockInSheets");

            migrationBuilder.DropForeignKey(
                name: "FK__StockInSh__Suppl__10216507",
                table: "StockInSheets");

            migrationBuilder.DropTable(
                name: "ShipmentMethods");

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

            migrationBuilder.DropColumn(
                name: "LinePayTransactionId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MaskedCreditCardNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaidAt",
                table: "Orders");

            migrationBuilder.RenameIndex(
                name: "UQ__StockInS__9A5B6229BFDC8634",
                table: "StockInSheets",
                newName: "UQ__StockInS__9A5B62297753599F");

            migrationBuilder.RenameIndex(
                name: "UQ__Products__9A5B622984F05647",
                table: "Products",
                newName: "UQ__Products__9A5B6229D5BCEABA");

            migrationBuilder.RenameIndex(
                name: "UQ__Inventor__9A5B62292F47BB4A",
                table: "InventoryItems",
                newName: "UQ__Inventor__9A5B622901E60557");

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
                name: "PK__OrderIte__3214EC07B268D456",
                table: "OrderItemsCoupons",
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
                name: "ShipmemtMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<decimal>(type: "decimal(8,0)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Shipmemt__3214EC0798A22433", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Shipmemt__737584F6A6227A50",
                table: "ShipmemtMethods",
                column: "Name",
                unique: true);

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
                name: "FK__OrderItem__Coupo__59C55456",
                table: "OrderItemsCoupons",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Orders__Shipmemt__540C7B00",
                table: "Orders",
                column: "ShipmentMethodId",
                principalTable: "ShipmemtMethods",
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
    }
}
