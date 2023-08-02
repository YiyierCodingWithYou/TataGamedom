using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TataGamedomWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.EnsureSchema(
            //    name: "HangFire");

            //migrationBuilder.CreateTable(
            //    name: "AggregatedCounter",
            //    schema: "HangFire",
            //    columns: table => new
            //    {
            //        Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        Value = table.Column<long>(type: "bigint", nullable: false),
            //        ExpireAt = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HangFire_CounterAggregated", x => x.Key);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Announcement",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Announce__3214EC07772BD8A9", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ApprovalStatusCodes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Approval__3214EC07424C6E39", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "BackendMembersPermissionsCodes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__BackendM__3214EC073F80860F", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "BackendMembersRolesCodes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__BackendM__3214EC07D05C6501", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Counter",
            //    schema: "HangFire",
            //    columns: table => new
            //    {
            //        Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Value = table.Column<int>(type: "int", nullable: false),
            //        ExpireAt = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HangFire_Counter", x => new { x.Key, x.Id });
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DiscountTypeCodes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Discount__3214EC07BD4F4D31", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "GameClassificationsCodes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__GameClas__3214EC07C2FF42C3", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "GamePlatformsCodes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__GamePlat__3214EC0760B6B70B", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Hash",
            //    schema: "HangFire",
            //    columns: table => new
            //    {
            //        Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        Field = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HangFire_Hash", x => new { x.Key, x.Field });
            //    });

            //migrationBuilder.CreateTable(
            //    name: "IssueStatusCodes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__IssueSta__3214EC07818E6F76", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "IssueTypesCodes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__IssueTyp__3214EC078CF57BE5", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Job",
            //    schema: "HangFire",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        StateId = table.Column<long>(type: "bigint", nullable: true),
            //        StateName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
            //        InvocationData = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Arguments = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
            //        ExpireAt = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HangFire_Job", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "JobQueue",
            //    schema: "HangFire",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Queue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        JobId = table.Column<long>(type: "bigint", nullable: false),
            //        FetchedAt = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HangFire_JobQueue", x => new { x.Queue, x.Id });
            //    });

            //migrationBuilder.CreateTable(
            //    name: "List",
            //    schema: "HangFire",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ExpireAt = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HangFire_List", x => new { x.Key, x.Id });
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Members",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Account = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        Password = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: false),
            //        Birthday = table.Column<DateTime>(type: "datetime", nullable: false),
            //        Email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
            //        Phone = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
            //        RegistrationDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        IconImg = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            //        IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        ConfirmCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        ActiveFlag = table.Column<bool>(type: "bit", nullable: false),
            //        LastOnlineTime = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Members__3214EC0793CE0501", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "NewsCategoryCodes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__NewsCate__3214EC075CE68004", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OrderStatusCodes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__OrderSta__3214EC07706D8132", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PaymentStatusCodes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__PaymentS__3214EC0769701B62", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProductStatusCodes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__ProductS__3214EC07659FC8DB", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Schema",
            //    schema: "HangFire",
            //    columns: table => new
            //    {
            //        Version = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HangFire_Schema", x => x.Version);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Server",
            //    schema: "HangFire",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        LastHeartbeat = table.Column<DateTime>(type: "datetime", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HangFire_Server", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Set",
            //    schema: "HangFire",
            //    columns: table => new
            //    {
            //        Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        Value = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
            //        Score = table.Column<double>(type: "float", nullable: false),
            //        ExpireAt = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HangFire_Set", x => new { x.Key, x.Value });
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ShipmemtMethods",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        Cost = table.Column<decimal>(type: "decimal(8,0)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Shipmemt__3214EC074780A618", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ShipmentStatusesCodes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Shipment__3214EC079C366F60", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "StockInStatusCodes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__StockInS__3214EC076BDCDB92", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Suppliers",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
            //        Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Supplier__3214EC07FFF3B914", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "BackendMembers",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Account = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        Password = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: false),
            //        Birthday = table.Column<DateTime>(type: "datetime", nullable: false),
            //        Email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
            //        Phone = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
            //        BackendMembersRoleId = table.Column<int>(type: "int", nullable: false),
            //        RegistrationDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        ActiveFlag = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__BackendM__3214EC07BF39E515", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__BackendMe__Backe__2B0A656D",
            //            column: x => x.BackendMembersRoleId,
            //            principalTable: "BackendMembersRolesCodes",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "BackendMembersRolePermissions",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        BackendMembersRoleId = table.Column<int>(type: "int", nullable: false),
            //        BackendMemberPermissionId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__BackendM__3214EC0750786A94", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__BackendMe__Backe__2BFE89A6",
            //            column: x => x.BackendMembersRoleId,
            //            principalTable: "BackendMembersRolesCodes",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__BackendMe__Backe__2CF2ADDF",
            //            column: x => x.BackendMemberPermissionId,
            //            principalTable: "BackendMembersPermissionsCodes",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "FAQ",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
            //        IssueTypeId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__FAQ__3214EC077D2E4FF4", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__FAQ__IssueTypeId__40058253",
            //            column: x => x.IssueTypeId,
            //            principalTable: "IssueTypesCodes",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "JobParameter",
            //    schema: "HangFire",
            //    columns: table => new
            //    {
            //        JobId = table.Column<long>(type: "bigint", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
            //        Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HangFire_JobParameter", x => new { x.JobId, x.Name });
            //        table.ForeignKey(
            //            name: "FK_HangFire_JobParameter_Job",
            //            column: x => x.JobId,
            //            principalSchema: "HangFire",
            //            principalTable: "Job",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "State",
            //    schema: "HangFire",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        JobId = table.Column<long>(type: "bigint", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        Reason = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            //        CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
            //        Data = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HangFire_State", x => new { x.JobId, x.Id });
            //        table.ForeignKey(
            //            name: "FK_HangFire_State_Job",
            //            column: x => x.JobId,
            //            principalSchema: "HangFire",
            //            principalTable: "Job",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Issues",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        MemberId = table.Column<int>(type: "int", nullable: true),
            //        IssueTypeId = table.Column<int>(type: "int", nullable: true),
            //        Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        File = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
            //        CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
            //        Status = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Issues__3214EC074605E77A", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__Issues__IssueTyp__498EEC8D",
            //            column: x => x.IssueTypeId,
            //            principalTable: "IssueTypesCodes",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__Issues__MemberId__4A8310C6",
            //            column: x => x.MemberId,
            //            principalTable: "Members",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__Issues__Status__4B7734FF",
            //            column: x => x.Status,
            //            principalTable: "IssueStatusCodes",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Orders",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Index = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        MemberId = table.Column<int>(type: "int", nullable: false),
            //        OrderStatusId = table.Column<int>(type: "int", nullable: false),
            //        ShipmentStatusId = table.Column<int>(type: "int", nullable: false),
            //        PaymentStatusId = table.Column<int>(type: "int", nullable: false),
            //        CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
            //        CompletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
            //        ShipmemtMethodId = table.Column<int>(type: "int", nullable: true),
            //        RecipientName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
            //        ToAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        SentAt = table.Column<DateTime>(type: "datetime", nullable: true),
            //        DeliveredAt = table.Column<DateTime>(type: "datetime", nullable: true),
            //        TrackingNum = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Orders__3214EC0720C31AD9", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__Orders__MemberId__6442E2C9",
            //            column: x => x.MemberId,
            //            principalTable: "Members",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__Orders__OrderSta__65370702",
            //            column: x => x.OrderStatusId,
            //            principalTable: "OrderStatusCodes",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__Orders__PaymentS__662B2B3B",
            //            column: x => x.PaymentStatusId,
            //            principalTable: "PaymentStatusCodes",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__Orders__Shipmemt__671F4F74",
            //            column: x => x.ShipmemtMethodId,
            //            principalTable: "ShipmemtMethods",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__Orders__Shipment__681373AD",
            //            column: x => x.ShipmentStatusId,
            //            principalTable: "ShipmentStatusesCodes",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "StockInSheets",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Index = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        StockInStatusId = table.Column<int>(type: "int", nullable: false),
            //        SupplierId = table.Column<int>(type: "int", nullable: false),
            //        Quantity = table.Column<int>(type: "int", nullable: false),
            //        OrderRequestDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        ArrivedAt = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__StockInS__3214EC07DF30401A", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__StockInSh__Stock__04AFB25B",
            //            column: x => x.StockInStatusId,
            //            principalTable: "StockInStatusCodes",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__StockInSh__Suppl__05A3D694",
            //            column: x => x.SupplierId,
            //            principalTable: "Suppliers",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Coupons",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        Discount = table.Column<int>(type: "int", nullable: false),
            //        DiscountTypeId = table.Column<int>(type: "int", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
            //        CreatedTime = table.Column<DateTime>(type: "datetime", nullable: false),
            //        CreatedBackendMemberId = table.Column<int>(type: "int", nullable: false),
            //        Threshold = table.Column<int>(type: "int", nullable: false),
            //        StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
            //        EndTime = table.Column<DateTime>(type: "datetime", nullable: false),
            //        ActiveFlag = table.Column<bool>(type: "bit", nullable: false),
            //        ModifiedTime = table.Column<DateTime>(type: "datetime", nullable: true),
            //        ModifiedBackendMemberId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Coupons__3214EC07B9548660", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__Coupons__Created__3B40CD36",
            //            column: x => x.CreatedBackendMemberId,
            //            principalTable: "BackendMembers",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__Coupons__Discoun__3C34F16F",
            //            column: x => x.DiscountTypeId,
            //            principalTable: "DiscountTypeCodes",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__Coupons__Modifie__3D2915A8",
            //            column: x => x.ModifiedBackendMemberId,
            //            principalTable: "BackendMembers",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Games",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ChiName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        EngName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
            //        IsRestrict = table.Column<bool>(type: "bit", nullable: false),
            //        GameCoverImg = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        CreatedTime = table.Column<DateTime>(type: "datetime", nullable: false),
            //        CreatedBackendMemberId = table.Column<int>(type: "int", nullable: false),
            //        ModifiedTime = table.Column<DateTime>(type: "datetime", nullable: true),
            //        ModifiedBackendMemberId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Games__3214EC077B9115B5", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__Games__CreatedBa__45BE5BA9",
            //            column: x => x.CreatedBackendMemberId,
            //            principalTable: "BackendMembers",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__Games__ModifiedB__46B27FE2",
            //            column: x => x.ModifiedBackendMemberId,
            //            principalTable: "BackendMembers",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Newsletters",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        BackendMemberId = table.Column<int>(type: "int", nullable: true),
            //        CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Newslett__3214EC0749C55162", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__Newslette__Backe__59C55456",
            //            column: x => x.BackendMemberId,
            //            principalTable: "BackendMembers",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Replies",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        IssueId = table.Column<int>(type: "int", nullable: true),
            //        BackendMemberId = table.Column<int>(type: "int", nullable: true),
            //        CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
            //        Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Replies__3214EC070E4B66B7", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__Replies__Backend__01D345B0",
            //            column: x => x.BackendMemberId,
            //            principalTable: "BackendMembers",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__Replies__IssueId__02C769E9",
            //            column: x => x.IssueId,
            //            principalTable: "Issues",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Boards",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        GameId = table.Column<int>(type: "int", nullable: true),
            //        BoardAbout = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        BoardHeaderCoverImg = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
            //        CreatedTime = table.Column<DateTime>(type: "datetime", nullable: false),
            //        CreatedBackendMemberId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Boards__3214EC076665FACA", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__Boards__CreatedB__2DE6D218",
            //            column: x => x.CreatedBackendMemberId,
            //            principalTable: "BackendMembers",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__Boards__GameId__2EDAF651",
            //            column: x => x.GameId,
            //            principalTable: "Games",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "GameClassificationGames",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        GameId = table.Column<int>(type: "int", nullable: false),
            //        GameClassificationId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__GameClas__3214EC072C5209EC", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__GameClass__GameC__40F9A68C",
            //            column: x => x.GameClassificationId,
            //            principalTable: "GameClassificationsCodes",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__GameClass__GameI__41EDCAC5",
            //            column: x => x.GameId,
            //            principalTable: "Games",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "GameComments",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        GameId = table.Column<int>(type: "int", nullable: false),
            //        MemberId = table.Column<int>(type: "int", nullable: false),
            //        Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
            //        Score = table.Column<byte>(type: "tinyint", nullable: false),
            //        CreatedTime = table.Column<DateTime>(type: "datetime", nullable: false),
            //        ActiveFlag = table.Column<bool>(type: "bit", nullable: false),
            //        DeleteDatetime = table.Column<DateTime>(type: "datetime", nullable: true),
            //        DeleteBackendMemberId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__GameComm__3214EC071BA02136", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__GameComme__Delet__42E1EEFE",
            //            column: x => x.DeleteBackendMemberId,
            //            principalTable: "BackendMembers",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__GameComme__GameI__43D61337",
            //            column: x => x.GameId,
            //            principalTable: "Games",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__GameComme__Membe__44CA3770",
            //            column: x => x.MemberId,
            //            principalTable: "Members",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "News",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        BackendMemberId = table.Column<int>(type: "int", nullable: false),
            //        NewsCategoryId = table.Column<int>(type: "int", nullable: false),
            //        GamesId = table.Column<int>(type: "int", nullable: true),
            //        CoverImg = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            //        ScheduleDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        ActiveFlag = table.Column<bool>(type: "bit", nullable: false),
            //        EditDatetime = table.Column<DateTime>(type: "datetime", nullable: true),
            //        DeleteDatetime = table.Column<DateTime>(type: "datetime", nullable: true),
            //        DeleteBackendMemberId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__News__3214EC07C29312B4", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__News__BackendMem__503BEA1C",
            //            column: x => x.BackendMemberId,
            //            principalTable: "BackendMembers",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__News__DeleteBack__51300E55",
            //            column: x => x.DeleteBackendMemberId,
            //            principalTable: "BackendMembers",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__News__GamesId__5224328E",
            //            column: x => x.GamesId,
            //            principalTable: "Games",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__News__NewsCatego__531856C7",
            //            column: x => x.NewsCategoryId,
            //            principalTable: "NewsCategoryCodes",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Products",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Index = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        GameId = table.Column<int>(type: "int", nullable: true),
            //        IsVirtual = table.Column<bool>(type: "bit", nullable: false),
            //        Price = table.Column<int>(type: "int", nullable: false),
            //        GamePlatformId = table.Column<int>(type: "int", nullable: false),
            //        SystemRequire = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
            //        ProductStatusId = table.Column<int>(type: "int", nullable: false),
            //        SaleDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        CreatedBackendMemberId = table.Column<int>(type: "int", nullable: false),
            //        CreatedTime = table.Column<DateTime>(type: "datetime", nullable: false),
            //        ModifiedBackendMemberId = table.Column<int>(type: "int", nullable: true),
            //        ModifiedTime = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Products__3214EC07FC67A92C", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__Products__Create__7D0E9093",
            //            column: x => x.CreatedBackendMemberId,
            //            principalTable: "BackendMembers",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__Products__GameId__7E02B4CC",
            //            column: x => x.GameId,
            //            principalTable: "Games",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__Products__GamePl__7EF6D905",
            //            column: x => x.GamePlatformId,
            //            principalTable: "GamePlatformsCodes",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__Products__Modifi__7FEAFD3E",
            //            column: x => x.ModifiedBackendMemberId,
            //            principalTable: "BackendMembers",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__Products__Produc__00DF2177",
            //            column: x => x.ProductStatusId,
            //            principalTable: "ProductStatusCodes",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "NewsletterLogs",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NewsletterId = table.Column<int>(type: "int", nullable: true),
            //        EmailSentDatetime = table.Column<DateTime>(type: "datetime", nullable: false),
            //        AddresseeMemberID = table.Column<int>(type: "int", nullable: false),
            //        AddresseeMemberName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        AddresseeMemberEmail = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Newslett__3214EC0766425F0D", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__Newslette__Addre__57DD0BE4",
            //            column: x => x.AddresseeMemberID,
            //            principalTable: "Members",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__Newslette__Newsl__58D1301D",
            //            column: x => x.NewsletterId,
            //            principalTable: "Newsletters",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "BoardsModerators",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ModeratorMemberId = table.Column<int>(type: "int", nullable: false),
            //        BoardId = table.Column<int>(type: "int", nullable: false),
            //        StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        EndDate = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__BoardsMo__3214EC071BCDFEEC", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__BoardsMod__Board__2FCF1A8A",
            //            column: x => x.BoardId,
            //            principalTable: "Boards",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__BoardsMod__Moder__30C33EC3",
            //            column: x => x.ModeratorMemberId,
            //            principalTable: "Members",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "BoardsModeratorsApplications",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        MemberId = table.Column<int>(type: "int", nullable: false),
            //        BoardId = table.Column<int>(type: "int", nullable: false),
            //        ApplyDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        AddOrRemove = table.Column<bool>(type: "bit", nullable: false),
            //        ApplyReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
            //        ApprovalResult = table.Column<bool>(type: "bit", nullable: true),
            //        BackendMemberId = table.Column<int>(type: "int", nullable: true),
            //        ApprovalStatusDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        ApprovalStatusId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__BoardsMo__3214EC07428F3BBB", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__BoardsMod__Appro__31B762FC",
            //            column: x => x.ApprovalStatusId,
            //            principalTable: "ApprovalStatusCodes",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__BoardsMod__Backe__32AB8735",
            //            column: x => x.BackendMemberId,
            //            principalTable: "BackendMembers",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__BoardsMod__Board__339FAB6E",
            //            column: x => x.BoardId,
            //            principalTable: "Boards",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__BoardsMod__Membe__3493CFA7",
            //            column: x => x.MemberId,
            //            principalTable: "Members",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "BucketLogs",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        BucketMemberId = table.Column<int>(type: "int", nullable: false),
            //        ModeratorMemberId = table.Column<int>(type: "int", nullable: true),
            //        BackendMmemberId = table.Column<int>(type: "int", nullable: true),
            //        BoardId = table.Column<int>(type: "int", nullable: false),
            //        BucketReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
            //        StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
            //        EndTime = table.Column<DateTime>(type: "datetime", nullable: false),
            //        IsNoctified = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__BucketLo__3214EC074E271D78", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__BucketLog__Backe__3587F3E0",
            //            column: x => x.BackendMmemberId,
            //            principalTable: "BackendMembers",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__BucketLog__Board__367C1819",
            //            column: x => x.BoardId,
            //            principalTable: "Boards",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__BucketLog__Bucke__37703C52",
            //            column: x => x.BucketMemberId,
            //            principalTable: "Members",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__BucketLog__Moder__3864608B",
            //            column: x => x.ModeratorMemberId,
            //            principalTable: "Members",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "MembersBoards",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        MemberId = table.Column<int>(type: "int", nullable: false),
            //        BoardId = table.Column<int>(type: "int", nullable: false),
            //        IsFavorite = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__MembersB__3214EC07CF2113DC", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__MembersBo__Board__4E53A1AA",
            //            column: x => x.BoardId,
            //            principalTable: "Boards",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__MembersBo__Membe__4F47C5E3",
            //            column: x => x.MemberId,
            //            principalTable: "Members",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Posts",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        MemberId = table.Column<int>(type: "int", nullable: false),
            //        BoardId = table.Column<int>(type: "int", nullable: true),
            //        Content = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
            //        Datetime = table.Column<DateTime>(type: "datetime", nullable: false),
            //        LastEditDatetime = table.Column<DateTime>(type: "datetime", nullable: false),
            //        ActiveFlag = table.Column<bool>(type: "bit", nullable: false),
            //        DeleteDatetime = table.Column<DateTime>(type: "datetime", nullable: true),
            //        DeleteMemberId = table.Column<int>(type: "int", nullable: true),
            //        DeleteBackendMemberId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Posts__3214EC07648F8F38", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__Posts__BoardId__76619304",
            //            column: x => x.BoardId,
            //            principalTable: "Boards",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__Posts__DeleteBac__7755B73D",
            //            column: x => x.DeleteBackendMemberId,
            //            principalTable: "BackendMembers",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__Posts__DeleteMem__7849DB76",
            //            column: x => x.DeleteMemberId,
            //            principalTable: "Members",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__Posts__MemberId__793DFFAF",
            //            column: x => x.MemberId,
            //            principalTable: "Members",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "NewsComments",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NewsId = table.Column<int>(type: "int", nullable: false),
            //        Content = table.Column<string>(type: "nvarchar(280)", maxLength: 280, nullable: false),
            //        Time = table.Column<DateTime>(type: "datetime", nullable: false),
            //        MemberID = table.Column<int>(type: "int", nullable: false),
            //        ActiveFlag = table.Column<bool>(type: "bit", nullable: false),
            //        DeleteDatetime = table.Column<DateTime>(type: "datetime", nullable: true),
            //        DeleteMemberId = table.Column<int>(type: "int", nullable: true),
            //        DeleteBackendMemberId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__NewsComm__3214EC075A40DB1F", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__NewsComme__Delet__540C7B00",
            //            column: x => x.DeleteMemberId,
            //            principalTable: "Members",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__NewsComme__Delet__55009F39",
            //            column: x => x.DeleteBackendMemberId,
            //            principalTable: "BackendMembers",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__NewsComme__Membe__55F4C372",
            //            column: x => x.MemberID,
            //            principalTable: "Members",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__NewsComme__NewsI__56E8E7AB",
            //            column: x => x.NewsId,
            //            principalTable: "News",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "NewsLikes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NewsId = table.Column<int>(type: "int", nullable: false),
            //        MemberId = table.Column<int>(type: "int", nullable: false),
            //        Time = table.Column<DateTime>(type: "datetime", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__NewsLike__3214EC07AB0623D0", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__NewsLikes__Membe__5AB9788F",
            //            column: x => x.MemberId,
            //            principalTable: "Members",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__NewsLikes__NewsI__5BAD9CC8",
            //            column: x => x.NewsId,
            //            principalTable: "News",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "NewsViews",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NewsId = table.Column<int>(type: "int", nullable: false),
            //        MemberId = table.Column<int>(type: "int", nullable: false),
            //        ViewTime = table.Column<DateTime>(type: "datetime", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__NewsView__3214EC0768904716", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__NewsViews__Membe__5CA1C101",
            //            column: x => x.MemberId,
            //            principalTable: "Members",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__NewsViews__NewsI__5D95E53A",
            //            column: x => x.NewsId,
            //            principalTable: "News",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Carts",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        MemberId = table.Column<int>(type: "int", nullable: false),
            //        ProductId = table.Column<int>(type: "int", nullable: false),
            //        Quantity = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Carts__3214EC07ECE5F7DF", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__Carts__MemberId__395884C4",
            //            column: x => x.MemberId,
            //            principalTable: "Members",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__Carts__ProductId__3A4CA8FD",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CouponsProducts",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CouponId = table.Column<int>(type: "int", nullable: false),
            //        ProductId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__CouponsP__3214EC079AF4DDD8", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__CouponsPr__Coupo__3E1D39E1",
            //            column: x => x.CouponId,
            //            principalTable: "Coupons",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__CouponsPr__Produ__3F115E1A",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "InventoryItems",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Index = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        ProductId = table.Column<int>(type: "int", nullable: false),
            //        StockInSheetId = table.Column<int>(type: "int", nullable: false),
            //        Cost = table.Column<decimal>(type: "decimal(8,0)", nullable: false),
            //        GameKey = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Inventor__3214EC07CDE4EC36", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__Inventory__Produ__47A6A41B",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__Inventory__Stock__489AC854",
            //            column: x => x.StockInSheetId,
            //            principalTable: "StockInSheets",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "MemberProductViews",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        MemberId = table.Column<int>(type: "int", nullable: false),
            //        ProductId = table.Column<int>(type: "int", nullable: false),
            //        ViewTime = table.Column<DateTime>(type: "datetime", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__MemberPr__3214EC074113EC65", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__MemberPro__Membe__4C6B5938",
            //            column: x => x.MemberId,
            //            principalTable: "Members",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__MemberPro__Produ__4D5F7D71",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProductImages",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProductId = table.Column<int>(type: "int", nullable: false),
            //        Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__ProductI__3214EC073FBD74E3", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__ProductIm__Produ__7C1A6C5A",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "StandardProducts",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProductId = table.Column<int>(type: "int", nullable: false),
            //        AutoOrder = table.Column<bool>(type: "bit", nullable: true),
            //        Quantity = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Standard__3214EC07DDA754ED", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__StandardP__Produ__03BB8E22",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PostComments",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        MemberId = table.Column<int>(type: "int", nullable: false),
            //        PostId = table.Column<int>(type: "int", nullable: false),
            //        Content = table.Column<string>(type: "nvarchar(280)", maxLength: 280, nullable: false),
            //        Datetime = table.Column<DateTime>(type: "datetime", nullable: false),
            //        ActiveFlag = table.Column<bool>(type: "bit", nullable: false),
            //        DeleteDatetime = table.Column<DateTime>(type: "datetime", nullable: true),
            //        DeleteMemberId = table.Column<int>(type: "int", nullable: true),
            //        DeleteBackendMemberId = table.Column<int>(type: "int", nullable: true),
            //        ParentId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__PostComm__3214EC0788CB27CF", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__PostComme__Delet__6BE40491",
            //            column: x => x.DeleteMemberId,
            //            principalTable: "Members",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__PostComme__Delet__6CD828CA",
            //            column: x => x.DeleteBackendMemberId,
            //            principalTable: "BackendMembers",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__PostComme__Membe__6DCC4D03",
            //            column: x => x.MemberId,
            //            principalTable: "Members",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__PostComme__Paren__6EC0713C",
            //            column: x => x.ParentId,
            //            principalTable: "PostComments",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__PostComme__PostI__6FB49575",
            //            column: x => x.PostId,
            //            principalTable: "Posts",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PostEditLogs",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PostId = table.Column<int>(type: "int", nullable: false),
            //        ContentBeforeEdit = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
            //        EditDatetime = table.Column<DateTime>(type: "datetime", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__PostEdit__3214EC07B571EAF0", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__PostEditL__PostI__72910220",
            //            column: x => x.PostId,
            //            principalTable: "Posts",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PostReports",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PostId = table.Column<int>(type: "int", nullable: false),
            //        MemberID = table.Column<int>(type: "int", nullable: false),
            //        Datetime = table.Column<DateTime>(type: "datetime", nullable: false),
            //        Reason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
            //        ReviewerBackenMemberId = table.Column<int>(type: "int", nullable: true),
            //        ReviewDatetime = table.Column<DateTime>(type: "datetime", nullable: true),
            //        IsCommit = table.Column<bool>(type: "bit", nullable: false),
            //        ReviewComment = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__PostRepo__3214EC078A5A8B32", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__PostRepor__Membe__73852659",
            //            column: x => x.MemberID,
            //            principalTable: "Members",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__PostRepor__PostI__74794A92",
            //            column: x => x.PostId,
            //            principalTable: "Posts",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__PostRepor__Revie__756D6ECB",
            //            column: x => x.ReviewerBackenMemberId,
            //            principalTable: "BackendMembers",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PostUpDownVotes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        MemberId = table.Column<int>(type: "int", nullable: false),
            //        PostId = table.Column<int>(type: "int", nullable: false),
            //        Date = table.Column<DateTime>(type: "datetime", nullable: false),
            //        Type = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__PostUpDo__3214EC07EA67A124", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__PostUpDow__Membe__7A3223E8",
            //            column: x => x.MemberId,
            //            principalTable: "Members",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__PostUpDow__PostI__7B264821",
            //            column: x => x.PostId,
            //            principalTable: "Posts",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OrderItems",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Index = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        OrderId = table.Column<int>(type: "int", nullable: false),
            //        ProductId = table.Column<int>(type: "int", nullable: false),
            //        ProductPrice = table.Column<decimal>(type: "decimal(8,0)", nullable: false),
            //        InventoryItemId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__OrderIte__3214EC0771411A1A", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__OrderItem__Inven__5F7E2DAC",
            //            column: x => x.InventoryItemId,
            //            principalTable: "InventoryItems",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__OrderItem__Order__607251E5",
            //            column: x => x.OrderId,
            //            principalTable: "Orders",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__OrderItem__Produ__6166761E",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PostCommentReports",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PostCommentId = table.Column<int>(type: "int", nullable: false),
            //        MemberID = table.Column<int>(type: "int", nullable: false),
            //        Datetime = table.Column<DateTime>(type: "datetime", nullable: false),
            //        Reason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
            //        ReviewerBackenMemberId = table.Column<int>(type: "int", nullable: true),
            //        ReviewDatetime = table.Column<DateTime>(type: "datetime", nullable: true),
            //        IsCommit = table.Column<bool>(type: "bit", nullable: false),
            //        ReviewComment = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__PostComm__3214EC0740423DFC", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__PostComme__Membe__690797E6",
            //            column: x => x.MemberID,
            //            principalTable: "Members",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__PostComme__PostC__69FBBC1F",
            //            column: x => x.PostCommentId,
            //            principalTable: "PostComments",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__PostComme__Revie__6AEFE058",
            //            column: x => x.ReviewerBackenMemberId,
            //            principalTable: "BackendMembers",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PostCommentUpDownVotes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        MemberId = table.Column<int>(type: "int", nullable: false),
            //        PostCommentId = table.Column<int>(type: "int", nullable: false),
            //        Date = table.Column<DateTime>(type: "datetime", nullable: false),
            //        Type = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__PostComm__3214EC078AE165A8", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__PostComme__Membe__70A8B9AE",
            //            column: x => x.MemberId,
            //            principalTable: "Members",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__PostComme__PostC__719CDDE7",
            //            column: x => x.PostCommentId,
            //            principalTable: "PostComments",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OrderItemReturns",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Index = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        OrderItemId = table.Column<int>(type: "int", nullable: false),
            //        Reason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
            //        IssuedAt = table.Column<DateTime>(type: "datetime", nullable: false),
            //        CompletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
            //        IsRefunded = table.Column<bool>(type: "bit", nullable: false),
            //        IsReturned = table.Column<bool>(type: "bit", nullable: false),
            //        IsResellable = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__OrderIte__3214EC07773D2964", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__OrderItem__Order__5E8A0973",
            //            column: x => x.OrderItemId,
            //            principalTable: "OrderItems",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OrderItemsCoupons",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        OrderItemId = table.Column<int>(type: "int", nullable: false),
            //        CouponId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__OrderIte__3214EC07D071EEDA", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__OrderItem__Coupo__625A9A57",
            //            column: x => x.CouponId,
            //            principalTable: "Coupons",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__OrderItem__Order__634EBE90",
            //            column: x => x.OrderItemId,
            //            principalTable: "OrderItems",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_HangFire_AggregatedCounter_ExpireAt",
            //    schema: "HangFire",
            //    table: "AggregatedCounter",
            //    column: "ExpireAt",
            //    filter: "([ExpireAt] IS NOT NULL)");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BackendMembers_BackendMembersRoleId",
            //    table: "BackendMembers",
            //    column: "BackendMembersRoleId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BackendMembersRolePermissions_BackendMemberPermissionId",
            //    table: "BackendMembersRolePermissions",
            //    column: "BackendMemberPermissionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BackendMembersRolePermissions_BackendMembersRoleId",
            //    table: "BackendMembersRolePermissions",
            //    column: "BackendMembersRoleId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Boards_CreatedBackendMemberId",
            //    table: "Boards",
            //    column: "CreatedBackendMemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Boards_GameId",
            //    table: "Boards",
            //    column: "GameId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BoardsModerators_BoardId",
            //    table: "BoardsModerators",
            //    column: "BoardId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BoardsModerators_ModeratorMemberId",
            //    table: "BoardsModerators",
            //    column: "ModeratorMemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BoardsModeratorsApplications_ApprovalStatusId",
            //    table: "BoardsModeratorsApplications",
            //    column: "ApprovalStatusId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BoardsModeratorsApplications_BackendMemberId",
            //    table: "BoardsModeratorsApplications",
            //    column: "BackendMemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BoardsModeratorsApplications_BoardId",
            //    table: "BoardsModeratorsApplications",
            //    column: "BoardId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BoardsModeratorsApplications_MemberId",
            //    table: "BoardsModeratorsApplications",
            //    column: "MemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BucketLogs_BackendMmemberId",
            //    table: "BucketLogs",
            //    column: "BackendMmemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BucketLogs_BoardId",
            //    table: "BucketLogs",
            //    column: "BoardId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BucketLogs_BucketMemberId",
            //    table: "BucketLogs",
            //    column: "BucketMemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BucketLogs_ModeratorMemberId",
            //    table: "BucketLogs",
            //    column: "ModeratorMemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Carts_MemberId",
            //    table: "Carts",
            //    column: "MemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Carts_ProductId",
            //    table: "Carts",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Coupons_CreatedBackendMemberId",
            //    table: "Coupons",
            //    column: "CreatedBackendMemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Coupons_DiscountTypeId",
            //    table: "Coupons",
            //    column: "DiscountTypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Coupons_ModifiedBackendMemberId",
            //    table: "Coupons",
            //    column: "ModifiedBackendMemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CouponsProducts_CouponId",
            //    table: "CouponsProducts",
            //    column: "CouponId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CouponsProducts_ProductId",
            //    table: "CouponsProducts",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FAQ_IssueTypeId",
            //    table: "FAQ",
            //    column: "IssueTypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_GameClassificationGames_GameClassificationId",
            //    table: "GameClassificationGames",
            //    column: "GameClassificationId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_GameClassificationGames_GameId",
            //    table: "GameClassificationGames",
            //    column: "GameId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_GameComments_DeleteBackendMemberId",
            //    table: "GameComments",
            //    column: "DeleteBackendMemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_GameComments_GameId",
            //    table: "GameComments",
            //    column: "GameId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_GameComments_MemberId",
            //    table: "GameComments",
            //    column: "MemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Games_CreatedBackendMemberId",
            //    table: "Games",
            //    column: "CreatedBackendMemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Games_ModifiedBackendMemberId",
            //    table: "Games",
            //    column: "ModifiedBackendMemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_HangFire_Hash_ExpireAt",
            //    schema: "HangFire",
            //    table: "Hash",
            //    column: "ExpireAt",
            //    filter: "([ExpireAt] IS NOT NULL)");

            //migrationBuilder.CreateIndex(
            //    name: "IX_InventoryItems_ProductId",
            //    table: "InventoryItems",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_InventoryItems_StockInSheetId",
            //    table: "InventoryItems",
            //    column: "StockInSheetId");

            //migrationBuilder.CreateIndex(
            //    name: "UQ__Inventor__9A5B622904F79815",
            //    table: "InventoryItems",
            //    column: "Index",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Issues_IssueTypeId",
            //    table: "Issues",
            //    column: "IssueTypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Issues_MemberId",
            //    table: "Issues",
            //    column: "MemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Issues_Status",
            //    table: "Issues",
            //    column: "Status");

            //migrationBuilder.CreateIndex(
            //    name: "IX_HangFire_Job_ExpireAt",
            //    schema: "HangFire",
            //    table: "Job",
            //    column: "ExpireAt",
            //    filter: "([ExpireAt] IS NOT NULL)");

            //migrationBuilder.CreateIndex(
            //    name: "IX_HangFire_Job_StateName",
            //    schema: "HangFire",
            //    table: "Job",
            //    column: "StateName",
            //    filter: "([StateName] IS NOT NULL)");

            //migrationBuilder.CreateIndex(
            //    name: "IX_HangFire_List_ExpireAt",
            //    schema: "HangFire",
            //    table: "List",
            //    column: "ExpireAt",
            //    filter: "([ExpireAt] IS NOT NULL)");

            //migrationBuilder.CreateIndex(
            //    name: "IX_MemberProductViews_MemberId",
            //    table: "MemberProductViews",
            //    column: "MemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_MemberProductViews_ProductId",
            //    table: "MemberProductViews",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_MembersBoards_BoardId",
            //    table: "MembersBoards",
            //    column: "BoardId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_MembersBoards_MemberId",
            //    table: "MembersBoards",
            //    column: "MemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_News_BackendMemberId",
            //    table: "News",
            //    column: "BackendMemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_News_DeleteBackendMemberId",
            //    table: "News",
            //    column: "DeleteBackendMemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_News_GamesId",
            //    table: "News",
            //    column: "GamesId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_News_NewsCategoryId",
            //    table: "News",
            //    column: "NewsCategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_NewsComments_DeleteBackendMemberId",
            //    table: "NewsComments",
            //    column: "DeleteBackendMemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_NewsComments_DeleteMemberId",
            //    table: "NewsComments",
            //    column: "DeleteMemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_NewsComments_MemberID",
            //    table: "NewsComments",
            //    column: "MemberID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_NewsComments_NewsId",
            //    table: "NewsComments",
            //    column: "NewsId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_NewsletterLogs_AddresseeMemberID",
            //    table: "NewsletterLogs",
            //    column: "AddresseeMemberID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_NewsletterLogs_NewsletterId",
            //    table: "NewsletterLogs",
            //    column: "NewsletterId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Newsletters_BackendMemberId",
            //    table: "Newsletters",
            //    column: "BackendMemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_NewsLikes_MemberId",
            //    table: "NewsLikes",
            //    column: "MemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_NewsLikes_NewsId",
            //    table: "NewsLikes",
            //    column: "NewsId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_NewsViews_MemberId",
            //    table: "NewsViews",
            //    column: "MemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_NewsViews_NewsId",
            //    table: "NewsViews",
            //    column: "NewsId");

            //migrationBuilder.CreateIndex(
            //    name: "UQ__OrderIte__57ED0680D98C50EF",
            //    table: "OrderItemReturns",
            //    column: "OrderItemId",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "UQ__OrderIte__9A5B62296CCF9FDE",
            //    table: "OrderItemReturns",
            //    column: "Index",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItems_OrderId",
            //    table: "OrderItems",
            //    column: "OrderId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItems_ProductId",
            //    table: "OrderItems",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "UQ__OrderIte__3BB2AC81B8354DC3",
            //    table: "OrderItems",
            //    column: "InventoryItemId",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "UQ__OrderIte__9A5B6229D1B84F3B",
            //    table: "OrderItems",
            //    column: "Index",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItemsCoupons_CouponId",
            //    table: "OrderItemsCoupons",
            //    column: "CouponId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItemsCoupons_OrderItemId",
            //    table: "OrderItemsCoupons",
            //    column: "OrderItemId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_MemberId",
            //    table: "Orders",
            //    column: "MemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_OrderStatusId",
            //    table: "Orders",
            //    column: "OrderStatusId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_PaymentStatusId",
            //    table: "Orders",
            //    column: "PaymentStatusId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_ShipmemtMethodId",
            //    table: "Orders",
            //    column: "ShipmemtMethodId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_ShipmentStatusId",
            //    table: "Orders",
            //    column: "ShipmentStatusId");

            //migrationBuilder.CreateIndex(
            //    name: "UQ__Orders__9A5B6229AB58A638",
            //    table: "Orders",
            //    column: "Index",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_PostCommentReports_MemberID",
            //    table: "PostCommentReports",
            //    column: "MemberID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PostCommentReports_PostCommentId",
            //    table: "PostCommentReports",
            //    column: "PostCommentId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PostCommentReports_ReviewerBackenMemberId",
            //    table: "PostCommentReports",
            //    column: "ReviewerBackenMemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PostComments_DeleteBackendMemberId",
            //    table: "PostComments",
            //    column: "DeleteBackendMemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PostComments_DeleteMemberId",
            //    table: "PostComments",
            //    column: "DeleteMemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PostComments_MemberId",
            //    table: "PostComments",
            //    column: "MemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PostComments_ParentId",
            //    table: "PostComments",
            //    column: "ParentId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PostComments_PostId",
            //    table: "PostComments",
            //    column: "PostId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PostCommentUpDownVotes_MemberId",
            //    table: "PostCommentUpDownVotes",
            //    column: "MemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PostCommentUpDownVotes_PostCommentId",
            //    table: "PostCommentUpDownVotes",
            //    column: "PostCommentId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PostEditLogs_PostId",
            //    table: "PostEditLogs",
            //    column: "PostId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PostReports_MemberID",
            //    table: "PostReports",
            //    column: "MemberID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PostReports_PostId",
            //    table: "PostReports",
            //    column: "PostId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PostReports_ReviewerBackenMemberId",
            //    table: "PostReports",
            //    column: "ReviewerBackenMemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Posts_BoardId",
            //    table: "Posts",
            //    column: "BoardId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Posts_DeleteBackendMemberId",
            //    table: "Posts",
            //    column: "DeleteBackendMemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Posts_DeleteMemberId",
            //    table: "Posts",
            //    column: "DeleteMemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Posts_MemberId",
            //    table: "Posts",
            //    column: "MemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PostUpDownVotes_MemberId",
            //    table: "PostUpDownVotes",
            //    column: "MemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PostUpDownVotes_PostId",
            //    table: "PostUpDownVotes",
            //    column: "PostId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductImages_ProductId",
            //    table: "ProductImages",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_CreatedBackendMemberId",
            //    table: "Products",
            //    column: "CreatedBackendMemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_GameId",
            //    table: "Products",
            //    column: "GameId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_GamePlatformId",
            //    table: "Products",
            //    column: "GamePlatformId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_ModifiedBackendMemberId",
            //    table: "Products",
            //    column: "ModifiedBackendMemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_ProductStatusId",
            //    table: "Products",
            //    column: "ProductStatusId");

            //migrationBuilder.CreateIndex(
            //    name: "UQ__Products__9A5B62299DE684AD",
            //    table: "Products",
            //    column: "Index",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Replies_BackendMemberId",
            //    table: "Replies",
            //    column: "BackendMemberId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Replies_IssueId",
            //    table: "Replies",
            //    column: "IssueId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_HangFire_Server_LastHeartbeat",
            //    schema: "HangFire",
            //    table: "Server",
            //    column: "LastHeartbeat");

            //migrationBuilder.CreateIndex(
            //    name: "IX_HangFire_Set_ExpireAt",
            //    schema: "HangFire",
            //    table: "Set",
            //    column: "ExpireAt",
            //    filter: "([ExpireAt] IS NOT NULL)");

            //migrationBuilder.CreateIndex(
            //    name: "IX_HangFire_Set_Score",
            //    schema: "HangFire",
            //    table: "Set",
            //    columns: new[] { "Key", "Score" });

            //migrationBuilder.CreateIndex(
            //    name: "UQ__Shipmemt__737584F6FDE0FB61",
            //    table: "ShipmemtMethods",
            //    column: "Name",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_StandardProducts_ProductId",
            //    table: "StandardProducts",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_HangFire_State_CreatedAt",
            //    schema: "HangFire",
            //    table: "State",
            //    column: "CreatedAt");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StockInSheets_StockInStatusId",
            //    table: "StockInSheets",
            //    column: "StockInStatusId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StockInSheets_SupplierId",
            //    table: "StockInSheets",
            //    column: "SupplierId");

            //migrationBuilder.CreateIndex(
            //    name: "UQ__StockInS__9A5B6229B398E302",
            //    table: "StockInSheets",
            //    column: "Index",
            //    unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AggregatedCounter",
                schema: "HangFire");

            migrationBuilder.DropTable(
                name: "Announcement");

            migrationBuilder.DropTable(
                name: "BackendMembersRolePermissions");

            migrationBuilder.DropTable(
                name: "BoardsModerators");

            migrationBuilder.DropTable(
                name: "BoardsModeratorsApplications");

            migrationBuilder.DropTable(
                name: "BucketLogs");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Counter",
                schema: "HangFire");

            migrationBuilder.DropTable(
                name: "CouponsProducts");

            migrationBuilder.DropTable(
                name: "FAQ");

            migrationBuilder.DropTable(
                name: "GameClassificationGames");

            migrationBuilder.DropTable(
                name: "GameComments");

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
                name: "MemberProductViews");

            migrationBuilder.DropTable(
                name: "MembersBoards");

            migrationBuilder.DropTable(
                name: "NewsComments");

            migrationBuilder.DropTable(
                name: "NewsletterLogs");

            migrationBuilder.DropTable(
                name: "NewsLikes");

            migrationBuilder.DropTable(
                name: "NewsViews");

            migrationBuilder.DropTable(
                name: "OrderItemReturns");

            migrationBuilder.DropTable(
                name: "OrderItemsCoupons");

            migrationBuilder.DropTable(
                name: "PostCommentReports");

            migrationBuilder.DropTable(
                name: "PostCommentUpDownVotes");

            migrationBuilder.DropTable(
                name: "PostEditLogs");

            migrationBuilder.DropTable(
                name: "PostReports");

            migrationBuilder.DropTable(
                name: "PostUpDownVotes");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Replies");

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
                name: "StandardProducts");

            migrationBuilder.DropTable(
                name: "State",
                schema: "HangFire");

            migrationBuilder.DropTable(
                name: "BackendMembersPermissionsCodes");

            migrationBuilder.DropTable(
                name: "ApprovalStatusCodes");

            migrationBuilder.DropTable(
                name: "GameClassificationsCodes");

            migrationBuilder.DropTable(
                name: "Newsletters");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "PostComments");

            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "Job",
                schema: "HangFire");

            migrationBuilder.DropTable(
                name: "NewsCategoryCodes");

            migrationBuilder.DropTable(
                name: "DiscountTypeCodes");

            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "IssueTypesCodes");

            migrationBuilder.DropTable(
                name: "IssueStatusCodes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "StockInSheets");

            migrationBuilder.DropTable(
                name: "OrderStatusCodes");

            migrationBuilder.DropTable(
                name: "PaymentStatusCodes");

            migrationBuilder.DropTable(
                name: "ShipmemtMethods");

            migrationBuilder.DropTable(
                name: "ShipmentStatusesCodes");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "GamePlatformsCodes");

            migrationBuilder.DropTable(
                name: "ProductStatusCodes");

            migrationBuilder.DropTable(
                name: "StockInStatusCodes");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "BackendMembers");

            migrationBuilder.DropTable(
                name: "BackendMembersRolesCodes");
        }
    }
}
