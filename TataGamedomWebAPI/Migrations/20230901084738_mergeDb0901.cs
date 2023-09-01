using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TataGamedomWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class mergeDb0901 : Migration
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
                name: "FK__BoardNoti__Recip__12FDD1B2",
                table: "BoardNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK__BoardNoti__Relat__13F1F5EB",
                table: "BoardNotifications");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK__Supplier__3214EC07ED6B2D25",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK__StockInS__3214EC0788C2A6F6",
                table: "StockInStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__StockInS__3214EC07B6621000",
                table: "StockInSheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Standard__3214EC071BB537EE",
                table: "StandardProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Shipment__3214EC078B72396F",
                table: "ShipmentStatusesCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Shipment__3214EC07E1141C6E",
                table: "ShipmentMethods");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Replies__3214EC070CF56DD0",
                table: "Replies");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ProductS__3214EC07C14FFAF8",
                table: "ProductStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Products__3214EC07BAC5B516",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ProductI__3214EC07E7384DEC",
                table: "ProductImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostUpDo__3214EC07A058B208",
                table: "PostUpDownVotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Posts__3214EC07C26390BD",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostRepo__3214EC072A8ABC8B",
                table: "PostReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostEdit__3214EC07343C82E2",
                table: "PostEditLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostComm__3214EC074267062C",
                table: "PostCommentUpDownVotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostComm__3214EC07A9733582",
                table: "PostComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostComm__3214EC0799CB6C71",
                table: "PostCommentReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PaymentS__3214EC075D6CB7DC",
                table: "PaymentStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__OrderSta__3214EC07952A10B2",
                table: "OrderStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__OrderIte__3214EC07E3F3C5D1",
                table: "OrderItemsCoupons");

            migrationBuilder.DropPrimaryKey(
                name: "PK__NewsView__3214EC07352CDFC7",
                table: "NewsViews");

            migrationBuilder.DropPrimaryKey(
                name: "PK__NewsLike__3214EC07E57BC79F",
                table: "NewsLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Newslett__3214EC0792AA70DC",
                table: "Newsletters");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Newslett__3214EC071E25CD1B",
                table: "NewsletterLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK__NewsComm__3214EC0745D8AFF3",
                table: "NewsComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__NewsCate__3214EC07D7DA3360",
                table: "NewsCategoryCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__News__3214EC072805D32D",
                table: "News");

            migrationBuilder.DropPrimaryKey(
                name: "PK__MembersB__3214EC07AA9843E5",
                table: "MembersBoards");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Members__3214EC07A0EF5946",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK__MemberPr__3214EC07F4BC6C91",
                table: "MemberProductViews");

            migrationBuilder.DropPrimaryKey(
                name: "PK__IssueTyp__3214EC07A66F78ED",
                table: "IssueTypesCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__IssueSta__3214EC07500EC9C7",
                table: "IssueStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Issues__3214EC07BEAB16AE",
                table: "Issues");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Inventor__3214EC07E8BC3018",
                table: "InventoryItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Games__3214EC07B395A3A1",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GamePlat__3214EC0775A0A90E",
                table: "GamePlatformsCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GameComm__3214EC07CFC64F0F",
                table: "GameComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GameClas__3214EC07C21188D4",
                table: "GameClassificationsCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GameClas__3214EC078805B357",
                table: "GameClassificationGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK__FAQ__3214EC07FB5C37EA",
                table: "FAQ");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Discount__3214EC07C67564D2",
                table: "DiscountTypeCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__CouponsP__3214EC077E66DF5C",
                table: "CouponsProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Coupons__3214EC07F07EEF01",
                table: "Coupons");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Carts__3214EC07DBB283D1",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BucketLo__3214EC0767229FBE",
                table: "BucketLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BoardsMo__3214EC0761791E79",
                table: "BoardsModeratorsApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BoardsMo__3214EC07E2B49EAC",
                table: "BoardsModerators");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Boards__3214EC07B343FDA0",
                table: "Boards");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BoardNot__3214EC07B93E99E1",
                table: "BoardNotifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BackendM__3214EC0730DB16DB",
                table: "BackendMembersRolesCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BackendM__3214EC070AEBF753",
                table: "BackendMembersRolePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BackendM__3214EC07E07734C6",
                table: "BackendMembersPermissionsCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BackendM__3214EC070E1DCA6B",
                table: "BackendMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Approval__3214EC079FC91ED1",
                table: "ApprovalStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Announce__3214EC0763A63E98",
                table: "Announcement");

            migrationBuilder.RenameIndex(
                name: "UQ__StockInS__9A5B622993624B6E",
                table: "StockInSheets",
                newName: "UQ__StockInS__9A5B6229E7D883F6");

            migrationBuilder.RenameIndex(
                name: "UQ__Shipment__737584F6BEB8CB05",
                table: "ShipmentMethods",
                newName: "UQ__Shipment__737584F6B6AF7673");

            migrationBuilder.RenameIndex(
                name: "UQ__Products__9A5B62297C65B6B2",
                table: "Products",
                newName: "UQ__Products__9A5B6229472FA608");

            migrationBuilder.RenameIndex(
                name: "UQ__Inventor__9A5B622933105438",
                table: "InventoryItems",
                newName: "UQ__Inventor__9A5B6229CD5F4232");

            migrationBuilder.AlterColumn<string>(
                name: "StoreName",
                table: "BranchesOfSeven",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "BranchesOfSeven",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "BranchesOfSeven",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BoardNotifications",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Supplier__3214EC07E28E979C",
                table: "Suppliers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__StockInS__3214EC07949296B8",
                table: "StockInStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__StockInS__3214EC07D2A8A9A6",
                table: "StockInSheets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Standard__3214EC07B64BCAE2",
                table: "StandardProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Shipment__3214EC07D1AF6803",
                table: "ShipmentStatusesCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Shipment__3214EC077102F5EE",
                table: "ShipmentMethods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Replies__3214EC07481E6804",
                table: "Replies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ProductS__3214EC070F37D389",
                table: "ProductStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Products__3214EC0767EFA990",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ProductI__3214EC07407D9158",
                table: "ProductImages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostUpDo__3214EC079587D452",
                table: "PostUpDownVotes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Posts__3214EC07A3E1B90E",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostRepo__3214EC073E0745F0",
                table: "PostReports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostEdit__3214EC0769ED29F0",
                table: "PostEditLogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostComm__3214EC0753FBD51E",
                table: "PostCommentUpDownVotes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostComm__3214EC07FCFA855B",
                table: "PostComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostComm__3214EC07C7D0AFF2",
                table: "PostCommentReports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PaymentS__3214EC0730C62161",
                table: "PaymentStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__OrderSta__3214EC07E2D61407",
                table: "OrderStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__OrderIte__3214EC0702F3CDE8",
                table: "OrderItemsCoupons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__NewsView__3214EC079FD7F871",
                table: "NewsViews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__NewsLike__3214EC07044AA50B",
                table: "NewsLikes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Newslett__3214EC07F878E2D2",
                table: "Newsletters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Newslett__3214EC070FD16253",
                table: "NewsletterLogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__NewsComm__3214EC07729D7C3C",
                table: "NewsComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__NewsCate__3214EC07BC09FB35",
                table: "NewsCategoryCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__News__3214EC075CD020AF",
                table: "News",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__MembersB__3214EC0722C26A0F",
                table: "MembersBoards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Members__3214EC0736F3FBB5",
                table: "Members",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__MemberPr__3214EC0798123D46",
                table: "MemberProductViews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__IssueTyp__3214EC07FF2FD873",
                table: "IssueTypesCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__IssueSta__3214EC07B4FCEC40",
                table: "IssueStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Issues__3214EC07E4ED33A4",
                table: "Issues",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Inventor__3214EC075A19205E",
                table: "InventoryItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Games__3214EC07B53506EC",
                table: "Games",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GamePlat__3214EC07FAA8C7FB",
                table: "GamePlatformsCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GameComm__3214EC07E30BB237",
                table: "GameComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GameClas__3214EC07584A953C",
                table: "GameClassificationsCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GameClas__3214EC0761104BF6",
                table: "GameClassificationGames",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__FAQ__3214EC07FA1D62E6",
                table: "FAQ",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Discount__3214EC07AC2D9EA2",
                table: "DiscountTypeCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__CouponsP__3214EC073DC40B9C",
                table: "CouponsProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Coupons__3214EC075CD04BDE",
                table: "Coupons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Carts__3214EC078E14EBF0",
                table: "Carts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BucketLo__3214EC07C9ABCABA",
                table: "BucketLogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BoardsMo__3214EC07AADD5607",
                table: "BoardsModeratorsApplications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BoardsMo__3214EC07F00B997F",
                table: "BoardsModerators",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Boards__3214EC0761FD7D22",
                table: "Boards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BoardNot__3214EC0748936389",
                table: "BoardNotifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BackendM__3214EC078B6CB23B",
                table: "BackendMembersRolesCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BackendM__3214EC07D45AEC4A",
                table: "BackendMembersRolePermissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BackendM__3214EC07FDE6893A",
                table: "BackendMembersPermissionsCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BackendM__3214EC072584FB50",
                table: "BackendMembers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Approval__3214EC074C226787",
                table: "ApprovalStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Announce__3214EC07EA18C016",
                table: "Announcement",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BackendMe__Backe__245D67DE",
                table: "BackendMembers",
                column: "BackendMembersRoleId",
                principalTable: "BackendMembersRolesCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BackendMe__Backe__25518C17",
                table: "BackendMembersRolePermissions",
                column: "BackendMembersRoleId",
                principalTable: "BackendMembersRolesCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BackendMe__Backe__2645B050",
                table: "BackendMembersRolePermissions",
                column: "BackendMemberPermissionId",
                principalTable: "BackendMembersPermissionsCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BoardNoti__Recip__2739D489",
                table: "BoardNotifications",
                column: "RecipientMemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BoardNoti__Relat__282DF8C2",
                table: "BoardNotifications",
                column: "RelationMemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Boards__CreatedB__2A164134",
                table: "Boards",
                column: "CreatedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Boards__GameId__2B0A656D",
                table: "Boards",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BoardsMod__Board__2BFE89A6",
                table: "BoardsModerators",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BoardsMod__Moder__2CF2ADDF",
                table: "BoardsModerators",
                column: "ModeratorMemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BoardsMod__Appro__2DE6D218",
                table: "BoardsModeratorsApplications",
                column: "ApprovalStatusId",
                principalTable: "ApprovalStatusCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BoardsMod__Backe__2EDAF651",
                table: "BoardsModeratorsApplications",
                column: "BackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BoardsMod__Board__2FCF1A8A",
                table: "BoardsModeratorsApplications",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BoardsMod__Membe__30C33EC3",
                table: "BoardsModeratorsApplications",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BucketLog__Backe__31B762FC",
                table: "BucketLogs",
                column: "BackendMmemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BucketLog__Board__32AB8735",
                table: "BucketLogs",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BucketLog__Bucke__339FAB6E",
                table: "BucketLogs",
                column: "BucketMemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BucketLog__Moder__3493CFA7",
                table: "BucketLogs",
                column: "ModeratorMemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Carts__MemberId__3587F3E0",
                table: "Carts",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Carts__ProductId__367C1819",
                table: "Carts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Coupons__Created__3864608B",
                table: "Coupons",
                column: "CreatedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Coupons__Discoun__395884C4",
                table: "Coupons",
                column: "DiscountTypeId",
                principalTable: "DiscountTypeCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Coupons__Modifie__3A4CA8FD",
                table: "Coupons",
                column: "ModifiedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__CouponsPr__Coupo__3B40CD36",
                table: "CouponsProducts",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__CouponsPr__Produ__3C34F16F",
                table: "CouponsProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__FAQ__IssueTypeId__3D2915A8",
                table: "FAQ",
                column: "IssueTypeId",
                principalTable: "IssueTypesCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__GameClass__GameC__3E1D39E1",
                table: "GameClassificationGames",
                column: "GameClassificationId",
                principalTable: "GameClassificationsCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__GameClass__GameI__3F115E1A",
                table: "GameClassificationGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__GameComme__Delet__40058253",
                table: "GameComments",
                column: "DeleteBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__GameComme__GameI__40F9A68C",
                table: "GameComments",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__GameComme__Membe__41EDCAC5",
                table: "GameComments",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Games__CreatedBa__42E1EEFE",
                table: "Games",
                column: "CreatedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Games__ModifiedB__43D61337",
                table: "Games",
                column: "ModifiedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Inventory__Produ__44CA3770",
                table: "InventoryItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Inventory__Stock__45BE5BA9",
                table: "InventoryItems",
                column: "StockInSheetId",
                principalTable: "StockInSheets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Issues__IssueTyp__46B27FE2",
                table: "Issues",
                column: "IssueTypeId",
                principalTable: "IssueTypesCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Issues__MemberId__47A6A41B",
                table: "Issues",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Issues__Status__489AC854",
                table: "Issues",
                column: "Status",
                principalTable: "IssueStatusCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MemberPro__Membe__4B7734FF",
                table: "MemberProductViews",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MemberPro__Produ__4C6B5938",
                table: "MemberProductViews",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MembersBo__Board__4D5F7D71",
                table: "MembersBoards",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MembersBo__Membe__4E53A1AA",
                table: "MembersBoards",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__News__BackendMem__4F47C5E3",
                table: "News",
                column: "BackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__News__DeleteBack__503BEA1C",
                table: "News",
                column: "DeleteBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__News__GamesId__51300E55",
                table: "News",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__News__NewsCatego__5224328E",
                table: "News",
                column: "NewsCategoryId",
                principalTable: "NewsCategoryCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsComme__Delet__531856C7",
                table: "NewsComments",
                column: "DeleteMemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsComme__Delet__540C7B00",
                table: "NewsComments",
                column: "DeleteBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsComme__Membe__55009F39",
                table: "NewsComments",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsComme__NewsI__55F4C372",
                table: "NewsComments",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Newslette__Addre__56E8E7AB",
                table: "NewsletterLogs",
                column: "AddresseeMemberID",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Newslette__Newsl__57DD0BE4",
                table: "NewsletterLogs",
                column: "NewsletterId",
                principalTable: "Newsletters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Newslette__Backe__58D1301D",
                table: "Newsletters",
                column: "BackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsLikes__Membe__59C55456",
                table: "NewsLikes",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsLikes__NewsI__5AB9788F",
                table: "NewsLikes",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsViews__Membe__5BAD9CC8",
                table: "NewsViews",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__NewsViews__NewsI__5CA1C101",
                table: "NewsViews",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderItem__Coupo__6166761E",
                table: "OrderItemsCoupons",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Membe__681373AD",
                table: "PostCommentReports",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Revie__69FBBC1F",
                table: "PostCommentReports",
                column: "ReviewerBackenMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Delet__6AEFE058",
                table: "PostComments",
                column: "DeleteMemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Delet__6BE40491",
                table: "PostComments",
                column: "DeleteBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Membe__6CD828CA",
                table: "PostComments",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Paren__6DCC4D03",
                table: "PostComments",
                column: "ParentId",
                principalTable: "PostComments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__PostI__6EC0713C",
                table: "PostComments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__Membe__6FB49575",
                table: "PostCommentUpDownVotes",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostComme__PostC__70A8B9AE",
                table: "PostCommentUpDownVotes",
                column: "PostCommentId",
                principalTable: "PostComments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostEditL__PostI__719CDDE7",
                table: "PostEditLogs",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostRepor__Membe__72910220",
                table: "PostReports",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostRepor__PostI__73852659",
                table: "PostReports",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostRepor__Revie__74794A92",
                table: "PostReports",
                column: "ReviewerBackenMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Posts__BoardId__756D6ECB",
                table: "Posts",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Posts__DeleteBac__76619304",
                table: "Posts",
                column: "DeleteBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Posts__DeleteMem__7755B73D",
                table: "Posts",
                column: "DeleteMemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Posts__MemberId__7849DB76",
                table: "Posts",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostUpDow__Membe__793DFFAF",
                table: "PostUpDownVotes",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__PostUpDow__PostI__7A3223E8",
                table: "PostUpDownVotes",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__ProductIm__Produ__7B264821",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Products__Create__7C1A6C5A",
                table: "Products",
                column: "CreatedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Products__GameId__7D0E9093",
                table: "Products",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Products__GamePl__7E02B4CC",
                table: "Products",
                column: "GamePlatformId",
                principalTable: "GamePlatformsCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Products__Modifi__7EF6D905",
                table: "Products",
                column: "ModifiedBackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Products__Produc__7FEAFD3E",
                table: "Products",
                column: "ProductStatusId",
                principalTable: "ProductStatusCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Replies__Backend__00DF2177",
                table: "Replies",
                column: "BackendMemberId",
                principalTable: "BackendMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Replies__IssueId__01D345B0",
                table: "Replies",
                column: "IssueId",
                principalTable: "Issues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__StandardP__Produ__02C769E9",
                table: "StandardProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__StockInSh__Stock__03BB8E22",
                table: "StockInSheets",
                column: "StockInStatusId",
                principalTable: "StockInStatusCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__StockInSh__Suppl__04AFB25B",
                table: "StockInSheets",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__BackendMe__Backe__245D67DE",
                table: "BackendMembers");

            migrationBuilder.DropForeignKey(
                name: "FK__BackendMe__Backe__25518C17",
                table: "BackendMembersRolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK__BackendMe__Backe__2645B050",
                table: "BackendMembersRolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK__BoardNoti__Recip__2739D489",
                table: "BoardNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK__BoardNoti__Relat__282DF8C2",
                table: "BoardNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK__Boards__CreatedB__2A164134",
                table: "Boards");

            migrationBuilder.DropForeignKey(
                name: "FK__Boards__GameId__2B0A656D",
                table: "Boards");

            migrationBuilder.DropForeignKey(
                name: "FK__BoardsMod__Board__2BFE89A6",
                table: "BoardsModerators");

            migrationBuilder.DropForeignKey(
                name: "FK__BoardsMod__Moder__2CF2ADDF",
                table: "BoardsModerators");

            migrationBuilder.DropForeignKey(
                name: "FK__BoardsMod__Appro__2DE6D218",
                table: "BoardsModeratorsApplications");

            migrationBuilder.DropForeignKey(
                name: "FK__BoardsMod__Backe__2EDAF651",
                table: "BoardsModeratorsApplications");

            migrationBuilder.DropForeignKey(
                name: "FK__BoardsMod__Board__2FCF1A8A",
                table: "BoardsModeratorsApplications");

            migrationBuilder.DropForeignKey(
                name: "FK__BoardsMod__Membe__30C33EC3",
                table: "BoardsModeratorsApplications");

            migrationBuilder.DropForeignKey(
                name: "FK__BucketLog__Backe__31B762FC",
                table: "BucketLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__BucketLog__Board__32AB8735",
                table: "BucketLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__BucketLog__Bucke__339FAB6E",
                table: "BucketLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__BucketLog__Moder__3493CFA7",
                table: "BucketLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__Carts__MemberId__3587F3E0",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK__Carts__ProductId__367C1819",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK__Coupons__Created__3864608B",
                table: "Coupons");

            migrationBuilder.DropForeignKey(
                name: "FK__Coupons__Discoun__395884C4",
                table: "Coupons");

            migrationBuilder.DropForeignKey(
                name: "FK__Coupons__Modifie__3A4CA8FD",
                table: "Coupons");

            migrationBuilder.DropForeignKey(
                name: "FK__CouponsPr__Coupo__3B40CD36",
                table: "CouponsProducts");

            migrationBuilder.DropForeignKey(
                name: "FK__CouponsPr__Produ__3C34F16F",
                table: "CouponsProducts");

            migrationBuilder.DropForeignKey(
                name: "FK__FAQ__IssueTypeId__3D2915A8",
                table: "FAQ");

            migrationBuilder.DropForeignKey(
                name: "FK__GameClass__GameC__3E1D39E1",
                table: "GameClassificationGames");

            migrationBuilder.DropForeignKey(
                name: "FK__GameClass__GameI__3F115E1A",
                table: "GameClassificationGames");

            migrationBuilder.DropForeignKey(
                name: "FK__GameComme__Delet__40058253",
                table: "GameComments");

            migrationBuilder.DropForeignKey(
                name: "FK__GameComme__GameI__40F9A68C",
                table: "GameComments");

            migrationBuilder.DropForeignKey(
                name: "FK__GameComme__Membe__41EDCAC5",
                table: "GameComments");

            migrationBuilder.DropForeignKey(
                name: "FK__Games__CreatedBa__42E1EEFE",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK__Games__ModifiedB__43D61337",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK__Inventory__Produ__44CA3770",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK__Inventory__Stock__45BE5BA9",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK__Issues__IssueTyp__46B27FE2",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK__Issues__MemberId__47A6A41B",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK__Issues__Status__489AC854",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK__MemberPro__Membe__4B7734FF",
                table: "MemberProductViews");

            migrationBuilder.DropForeignKey(
                name: "FK__MemberPro__Produ__4C6B5938",
                table: "MemberProductViews");

            migrationBuilder.DropForeignKey(
                name: "FK__MembersBo__Board__4D5F7D71",
                table: "MembersBoards");

            migrationBuilder.DropForeignKey(
                name: "FK__MembersBo__Membe__4E53A1AA",
                table: "MembersBoards");

            migrationBuilder.DropForeignKey(
                name: "FK__News__BackendMem__4F47C5E3",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK__News__DeleteBack__503BEA1C",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK__News__GamesId__51300E55",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK__News__NewsCatego__5224328E",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsComme__Delet__531856C7",
                table: "NewsComments");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsComme__Delet__540C7B00",
                table: "NewsComments");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsComme__Membe__55009F39",
                table: "NewsComments");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsComme__NewsI__55F4C372",
                table: "NewsComments");

            migrationBuilder.DropForeignKey(
                name: "FK__Newslette__Addre__56E8E7AB",
                table: "NewsletterLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__Newslette__Newsl__57DD0BE4",
                table: "NewsletterLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__Newslette__Backe__58D1301D",
                table: "Newsletters");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsLikes__Membe__59C55456",
                table: "NewsLikes");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsLikes__NewsI__5AB9788F",
                table: "NewsLikes");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsViews__Membe__5BAD9CC8",
                table: "NewsViews");

            migrationBuilder.DropForeignKey(
                name: "FK__NewsViews__NewsI__5CA1C101",
                table: "NewsViews");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderItem__Coupo__6166761E",
                table: "OrderItemsCoupons");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Membe__681373AD",
                table: "PostCommentReports");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Revie__69FBBC1F",
                table: "PostCommentReports");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Delet__6AEFE058",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Delet__6BE40491",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Membe__6CD828CA",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Paren__6DCC4D03",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__PostI__6EC0713C",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__Membe__6FB49575",
                table: "PostCommentUpDownVotes");

            migrationBuilder.DropForeignKey(
                name: "FK__PostComme__PostC__70A8B9AE",
                table: "PostCommentUpDownVotes");

            migrationBuilder.DropForeignKey(
                name: "FK__PostEditL__PostI__719CDDE7",
                table: "PostEditLogs");

            migrationBuilder.DropForeignKey(
                name: "FK__PostRepor__Membe__72910220",
                table: "PostReports");

            migrationBuilder.DropForeignKey(
                name: "FK__PostRepor__PostI__73852659",
                table: "PostReports");

            migrationBuilder.DropForeignKey(
                name: "FK__PostRepor__Revie__74794A92",
                table: "PostReports");

            migrationBuilder.DropForeignKey(
                name: "FK__Posts__BoardId__756D6ECB",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK__Posts__DeleteBac__76619304",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK__Posts__DeleteMem__7755B73D",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK__Posts__MemberId__7849DB76",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK__PostUpDow__Membe__793DFFAF",
                table: "PostUpDownVotes");

            migrationBuilder.DropForeignKey(
                name: "FK__PostUpDow__PostI__7A3223E8",
                table: "PostUpDownVotes");

            migrationBuilder.DropForeignKey(
                name: "FK__ProductIm__Produ__7B264821",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK__Products__Create__7C1A6C5A",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK__Products__GameId__7D0E9093",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK__Products__GamePl__7E02B4CC",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK__Products__Modifi__7EF6D905",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK__Products__Produc__7FEAFD3E",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK__Replies__Backend__00DF2177",
                table: "Replies");

            migrationBuilder.DropForeignKey(
                name: "FK__Replies__IssueId__01D345B0",
                table: "Replies");

            migrationBuilder.DropForeignKey(
                name: "FK__StandardP__Produ__02C769E9",
                table: "StandardProducts");

            migrationBuilder.DropForeignKey(
                name: "FK__StockInSh__Stock__03BB8E22",
                table: "StockInSheets");

            migrationBuilder.DropForeignKey(
                name: "FK__StockInSh__Suppl__04AFB25B",
                table: "StockInSheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Supplier__3214EC07E28E979C",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK__StockInS__3214EC07949296B8",
                table: "StockInStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__StockInS__3214EC07D2A8A9A6",
                table: "StockInSheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Standard__3214EC07B64BCAE2",
                table: "StandardProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Shipment__3214EC07D1AF6803",
                table: "ShipmentStatusesCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Shipment__3214EC077102F5EE",
                table: "ShipmentMethods");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Replies__3214EC07481E6804",
                table: "Replies");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ProductS__3214EC070F37D389",
                table: "ProductStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Products__3214EC0767EFA990",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ProductI__3214EC07407D9158",
                table: "ProductImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostUpDo__3214EC079587D452",
                table: "PostUpDownVotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Posts__3214EC07A3E1B90E",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostRepo__3214EC073E0745F0",
                table: "PostReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostEdit__3214EC0769ED29F0",
                table: "PostEditLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostComm__3214EC0753FBD51E",
                table: "PostCommentUpDownVotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostComm__3214EC07FCFA855B",
                table: "PostComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PostComm__3214EC07C7D0AFF2",
                table: "PostCommentReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PaymentS__3214EC0730C62161",
                table: "PaymentStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__OrderSta__3214EC07E2D61407",
                table: "OrderStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__OrderIte__3214EC0702F3CDE8",
                table: "OrderItemsCoupons");

            migrationBuilder.DropPrimaryKey(
                name: "PK__NewsView__3214EC079FD7F871",
                table: "NewsViews");

            migrationBuilder.DropPrimaryKey(
                name: "PK__NewsLike__3214EC07044AA50B",
                table: "NewsLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Newslett__3214EC07F878E2D2",
                table: "Newsletters");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Newslett__3214EC070FD16253",
                table: "NewsletterLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK__NewsComm__3214EC07729D7C3C",
                table: "NewsComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__NewsCate__3214EC07BC09FB35",
                table: "NewsCategoryCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__News__3214EC075CD020AF",
                table: "News");

            migrationBuilder.DropPrimaryKey(
                name: "PK__MembersB__3214EC0722C26A0F",
                table: "MembersBoards");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Members__3214EC0736F3FBB5",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK__MemberPr__3214EC0798123D46",
                table: "MemberProductViews");

            migrationBuilder.DropPrimaryKey(
                name: "PK__IssueTyp__3214EC07FF2FD873",
                table: "IssueTypesCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__IssueSta__3214EC07B4FCEC40",
                table: "IssueStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Issues__3214EC07E4ED33A4",
                table: "Issues");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Inventor__3214EC075A19205E",
                table: "InventoryItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Games__3214EC07B53506EC",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GamePlat__3214EC07FAA8C7FB",
                table: "GamePlatformsCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GameComm__3214EC07E30BB237",
                table: "GameComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GameClas__3214EC07584A953C",
                table: "GameClassificationsCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GameClas__3214EC0761104BF6",
                table: "GameClassificationGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK__FAQ__3214EC07FA1D62E6",
                table: "FAQ");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Discount__3214EC07AC2D9EA2",
                table: "DiscountTypeCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__CouponsP__3214EC073DC40B9C",
                table: "CouponsProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Coupons__3214EC075CD04BDE",
                table: "Coupons");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Carts__3214EC078E14EBF0",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BucketLo__3214EC07C9ABCABA",
                table: "BucketLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BoardsMo__3214EC07AADD5607",
                table: "BoardsModeratorsApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BoardsMo__3214EC07F00B997F",
                table: "BoardsModerators");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Boards__3214EC0761FD7D22",
                table: "Boards");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BoardNot__3214EC0748936389",
                table: "BoardNotifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BackendM__3214EC078B6CB23B",
                table: "BackendMembersRolesCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BackendM__3214EC07D45AEC4A",
                table: "BackendMembersRolePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BackendM__3214EC07FDE6893A",
                table: "BackendMembersPermissionsCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BackendM__3214EC072584FB50",
                table: "BackendMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Approval__3214EC074C226787",
                table: "ApprovalStatusCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Announce__3214EC07EA18C016",
                table: "Announcement");

            migrationBuilder.RenameIndex(
                name: "UQ__StockInS__9A5B6229E7D883F6",
                table: "StockInSheets",
                newName: "UQ__StockInS__9A5B622993624B6E");

            migrationBuilder.RenameIndex(
                name: "UQ__Shipment__737584F6B6AF7673",
                table: "ShipmentMethods",
                newName: "UQ__Shipment__737584F6BEB8CB05");

            migrationBuilder.RenameIndex(
                name: "UQ__Products__9A5B6229472FA608",
                table: "Products",
                newName: "UQ__Products__9A5B62297C65B6B2");

            migrationBuilder.RenameIndex(
                name: "UQ__Inventor__9A5B6229CD5F4232",
                table: "InventoryItems",
                newName: "UQ__Inventor__9A5B622933105438");

            migrationBuilder.AlterColumn<string>(
                name: "StoreName",
                table: "BranchesOfSeven",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "BranchesOfSeven",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "BranchesOfSeven",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BoardNotifications",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Supplier__3214EC07ED6B2D25",
                table: "Suppliers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__StockInS__3214EC0788C2A6F6",
                table: "StockInStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__StockInS__3214EC07B6621000",
                table: "StockInSheets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Standard__3214EC071BB537EE",
                table: "StandardProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Shipment__3214EC078B72396F",
                table: "ShipmentStatusesCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Shipment__3214EC07E1141C6E",
                table: "ShipmentMethods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Replies__3214EC070CF56DD0",
                table: "Replies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ProductS__3214EC07C14FFAF8",
                table: "ProductStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Products__3214EC07BAC5B516",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ProductI__3214EC07E7384DEC",
                table: "ProductImages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostUpDo__3214EC07A058B208",
                table: "PostUpDownVotes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Posts__3214EC07C26390BD",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostRepo__3214EC072A8ABC8B",
                table: "PostReports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostEdit__3214EC07343C82E2",
                table: "PostEditLogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostComm__3214EC074267062C",
                table: "PostCommentUpDownVotes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostComm__3214EC07A9733582",
                table: "PostComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PostComm__3214EC0799CB6C71",
                table: "PostCommentReports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PaymentS__3214EC075D6CB7DC",
                table: "PaymentStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__OrderSta__3214EC07952A10B2",
                table: "OrderStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__OrderIte__3214EC07E3F3C5D1",
                table: "OrderItemsCoupons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__NewsView__3214EC07352CDFC7",
                table: "NewsViews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__NewsLike__3214EC07E57BC79F",
                table: "NewsLikes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Newslett__3214EC0792AA70DC",
                table: "Newsletters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Newslett__3214EC071E25CD1B",
                table: "NewsletterLogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__NewsComm__3214EC0745D8AFF3",
                table: "NewsComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__NewsCate__3214EC07D7DA3360",
                table: "NewsCategoryCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__News__3214EC072805D32D",
                table: "News",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__MembersB__3214EC07AA9843E5",
                table: "MembersBoards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Members__3214EC07A0EF5946",
                table: "Members",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__MemberPr__3214EC07F4BC6C91",
                table: "MemberProductViews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__IssueTyp__3214EC07A66F78ED",
                table: "IssueTypesCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__IssueSta__3214EC07500EC9C7",
                table: "IssueStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Issues__3214EC07BEAB16AE",
                table: "Issues",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Inventor__3214EC07E8BC3018",
                table: "InventoryItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Games__3214EC07B395A3A1",
                table: "Games",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GamePlat__3214EC0775A0A90E",
                table: "GamePlatformsCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GameComm__3214EC07CFC64F0F",
                table: "GameComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GameClas__3214EC07C21188D4",
                table: "GameClassificationsCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GameClas__3214EC078805B357",
                table: "GameClassificationGames",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__FAQ__3214EC07FB5C37EA",
                table: "FAQ",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Discount__3214EC07C67564D2",
                table: "DiscountTypeCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__CouponsP__3214EC077E66DF5C",
                table: "CouponsProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Coupons__3214EC07F07EEF01",
                table: "Coupons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Carts__3214EC07DBB283D1",
                table: "Carts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BucketLo__3214EC0767229FBE",
                table: "BucketLogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BoardsMo__3214EC0761791E79",
                table: "BoardsModeratorsApplications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BoardsMo__3214EC07E2B49EAC",
                table: "BoardsModerators",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Boards__3214EC07B343FDA0",
                table: "Boards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BoardNot__3214EC07B93E99E1",
                table: "BoardNotifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BackendM__3214EC0730DB16DB",
                table: "BackendMembersRolesCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BackendM__3214EC070AEBF753",
                table: "BackendMembersRolePermissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BackendM__3214EC07E07734C6",
                table: "BackendMembersPermissionsCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BackendM__3214EC070E1DCA6B",
                table: "BackendMembers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Approval__3214EC079FC91ED1",
                table: "ApprovalStatusCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Announce__3214EC0763A63E98",
                table: "Announcement",
                column: "Id");

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
                name: "FK__BoardNoti__Recip__12FDD1B2",
                table: "BoardNotifications",
                column: "RecipientMemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BoardNoti__Relat__13F1F5EB",
                table: "BoardNotifications",
                column: "RelationMemberId",
                principalTable: "Members",
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
