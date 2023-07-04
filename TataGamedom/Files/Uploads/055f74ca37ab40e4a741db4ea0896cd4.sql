CREATE TABLE [Members] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(50) NOT NULL,
  [Account] varchar(30) NOT NULL,
  [Password] varchar(70) NOT NULL,
  [Birthday] datetime NOT NULL,
  [Email] varchar(150) NOT NULL,
  [Phone] varchar(10) NOT NULL,
  [RegistrationDate] datetime NOT NULL,
  [IconImg] nvarchar(100),
  [IsConfirmed] bit NOT NULL,
  [ConfirmCode] varchar(50),
  [ActiveFlag] bit NOT NULL
)
GO

CREATE TABLE [BackendMembers] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(50) NOT NULL,
  [Account] varchar(30) NOT NULL,
  [Password] varchar(70) NOT NULL,
  [Birthday] datetime NOT NULL,
  [Email] varchar(150) NOT NULL,
  [Phone] varchar(10) NOT NULL,
  [BackendMembersRoleId] int NOT NULL,
  [RegistrationDate] datetime,
  [ActiveFlag] bit NOT NULL
)
GO

CREATE TABLE [BackendMembersRolesCodes] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(20) NOT NULL
)
GO

CREATE TABLE [BackendMembersPermissionsCodes] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(20) NOT NULL
)
GO

CREATE TABLE [BackendMembersRolePermissions] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [BackendMembersRoleId] int NOT NULL,
  [BackendMemberPermissionId] int NOT NULL
)
GO

CREATE TABLE [Newsletters] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Title] nvarchar(max) NOT NULL,
  [Content] nvarchar(max) NOT NULL,
  [BackendMemberId] int,
  [CreatedAt] datetime NOT NULL
)
GO

CREATE TABLE [NewsletterLogs] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [NewsletterId] int,
  [EmailSentDatetime] datetime NOT NULL,
  [AddresseeMemberID] int NOT NULL,
  [AddresseeMemberName] nvarchar(50) NOT NULL,
  [AddresseeMemberEmail] varchar(150) NOT NULL
)
GO

CREATE TABLE [Games] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [ChiName] nvarchar(50) NOT NULL,
  [EngName] nvarchar(100) NOT NULL,
  [Description] nvarchar(1500) NOT NULL,
  [IsRestrict] bit NOT NULL,
  [GameCoverImg] nvarchar(100) NOT NULL,
  [CreatedTime] datetime NOT NULL,
  [CreatedBackendMemberId] int NOT NULL,
  [ModifiedTime] datetime,
  [ModifiedBackendMemberId] int
)
GO

CREATE TABLE [Products] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Index] nvarchar(20) UNIQUE NOT NULL,
  [GameId] int,
  [IsVirtual] bit NOT NULL,
  [Price] int NOT NULL,
  [GamePlatformId] int NOT NULL,
  [SystemRequire] nvarchar(1500) NOT NULL,
  [ProductStatusId] int NOT NULL,
  [SaleDate] datetime NOT NULL,
  [CreatedBackendMemberId] int NOT NULL,
  [CreatedTime] datetime NOT NULL,
  [ModifiedBackendMemberId] int,
  [ModifiedTime] datetime
)
GO

CREATE TABLE [Coupons] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(20) NOT NULL,
  [Discount] int NOT NULL,
  [DiscountTypeId] int NOT NULL,
  [Description] nvarchar(30) NOT NULL,
  [CreatedTime] datetime NOT NULL,
  [CreatedBackendMemberId] int NOT NULL,
  [Threshold] int NOT NULL,
  [StartTime] datetime NOT NULL,
  [EndTime] datetime NOT NULL,
  [ActiveFlag] bit NOT NULL,
  [ModifiedTime] datetime,
  [ModifiedBackendMemberId] int
)
GO

CREATE TABLE [DiscountTypeCodes] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(30) NOT NULL
)
GO

CREATE TABLE [CouponsProducts] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [CouponId] int NOT NULL,
  [ProductId] int NOT NULL
)
GO

CREATE TABLE [ProductStatusCodes] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(5) NOT NULL
)
GO

CREATE TABLE [GameClassificationGames] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [GameId] int NOT NULL,
  [GameClassificationId] int NOT NULL
)
GO

CREATE TABLE [GameClassificationsCodes] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(10) NOT NULL
)
GO

CREATE TABLE [GamePlatformsCodes] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(10) NOT NULL
)
GO

CREATE TABLE [GameComments] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [GameId] int NOT NULL,
  [MemberId] int NOT NULL,
  [Content] nvarchar(500) NOT NULL,
  [Score] tinyint NOT NULL,
  [CreatedTime] datetime NOT NULL,
  [ActiveFlag] bit NOT NULL,
  [DeleteDatetime] datetime,
  [DeleteBackendMemberId] int
)
GO

CREATE TABLE [MemberProductViews] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [MemberId] int NOT NULL,
  [ProductId] int NOT NULL,
  [ViewTime] datetime NOT NULL
)
GO

CREATE TABLE [Carts] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [MemberId] int NOT NULL,
  [ProductId] int NOT NULL,
  [Quantity] int NOT NULL
)
GO

CREATE TABLE [ProductImages] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [ProductId] int NOT NULL,
  [Image] nvarchar(100)
)
GO

CREATE TABLE [IssueTypesCodes] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [TypeName] NVARCHAR(50)
)
GO

CREATE TABLE [IssueStatusCodes] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [Name] NVARCHAR(50)
)
GO

CREATE TABLE [Issues] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [MemberId] INT,
  [IssueTypeId] INT,
  [Content] NVARCHAR(MAX) NOT NULL,
  [File] nvarchar(600),
  [CreatedAt] DateTime,
  [Status] INT
)
GO

CREATE TABLE [Replies] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [IssueId] INT,
  [BackendMemberId] INT,
  [CreatedAt] DateTime NOT NULL,
  [Content] NVARCHAR(max) NOT NULL
)
GO

CREATE TABLE [Orders] (
  [Id] INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Index] NVARCHAR(20) UNIQUE NOT NULL,
  [MemberId] INT NOT NULL,
  [OrderStatusId] INT NOT NULL,
  [ShipmentStatusId] INT NOT NULL,
  [PaymentStatusId] INT NOT NULL,
  [CreatedAt] DATETIME NOT NULL,
  [CompletedAt] DATETIME,
  [ShipmemtMethodId] INT NOT NULL,
  [RecipientName] NVARCHAR(20) NOT NULL,
  [ToAddress] NVARCHAR(50) NOT NULL,
  [SentAt] DATETIME,
  [DeliveredAt] DATETIME,
  [TrackingNum] NVARCHAR(20)
)
GO

CREATE TABLE [OrderStatusCodes] (
  [Id] INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Name] NVARCHAR(15) NOT NULL
)
GO

CREATE TABLE [ShipmentStatusesCodes] (
  [Id] INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Name] NVARCHAR(15) NOT NULL
)
GO

CREATE TABLE [PaymentStatusCodes] (
  [Id] INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Name] NVARCHAR(15) NOT NULL
)
GO

CREATE TABLE [OrderItems] (
  [Id] INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Index] nvarchar(20) UNIQUE NOT NULL,
  [OrderId] INT NOT NULL,
  [ProductId] INT NOT NULL,
  [ProductPrice] DECIMAL(8) NOT NULL,
  [InventoryItemId] int UNIQUE NOT NULL
)
GO

CREATE TABLE [OrderItemReturns] (
  [Id] INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Index] nvarchar(20) UNIQUE NOT NULL,
  [OrderItemId] INT UNIQUE NOT NULL,
  [Reason] NVARCHAR(500) NOT NULL,
  [IssuedAt] DATETIME NOT NULL,
  [CompletedAt] DATETIME,
  [IsRefunded] bit NOT NULL,
  [IsReturned] bit NOT NULL,
  [IsResellable] bit NOT NULL
)
GO

CREATE TABLE [OrderItemsCoupons] (
  [Id] INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [OrderItemId] INT NOT NULL,
  [CouponId] int
)
GO

CREATE TABLE [ShipmemtMethods] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [Name] NVARCHAR(20) UNIQUE NOT NULL,
  [Cost] DECIMAL(8) NOT NULL
)
GO

CREATE TABLE [InventoryItems] (
  [Id] INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Index] NVARCHAR(20) UNIQUE NOT NULL,
  [ProductId] INT NOT NULL,
  [StockInSheetId] INT NOT NULL,
  [Cost] DECIMAL(8) NOT NULL,
  [GameKey] NVARCHAR(50)
)
GO

CREATE TABLE [StockInSheets] (
  [Id] INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Index] NVARCHAR(20) UNIQUE NOT NULL,
  [StockInStatusId] INT NOT NULL,
  [SupplierId] INT NOT NULL,
  [Quantity] INT NOT NULL,
  [OrderRequestDate] DateTime NOT NULL,
  [ArrivedAt] DATETIME
)
GO

CREATE TABLE [StockInStatusCodes] (
  [Id] INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Name] NVARCHAR(50)
)
GO

CREATE TABLE [Suppliers] (
  [Id] INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Name] NVARCHAR(50) NOT NULL,
  [Phone] NVARCHAR(15),
  [Email] NVARCHAR(30)
)
GO

CREATE TABLE [News] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Title] nvarchar(100) NOT NULL,
  [Content] nvarchar(max) NOT NULL,
  [BackendMemberId] int NOT NULL,
  [NewsCategoryId] int NOT NULL,
  [GamesId] int,
  [CoverImg] nvarchar(100),
  [ScheduleDate] datetime NOT NULL,
  [ActiveFlag] bit NOT NULL,
  [DeleteDatetime] datetime,
  [DeleteBackendMemberId] int
)
GO

CREATE TABLE [NewsCategoryCodes] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(50) NOT NULL
)
GO

CREATE TABLE [NewsComments] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [NewsId] int NOT NULL,
  [Content] nvarchar(280) NOT NULL,
  [Time] datetime NOT NULL,
  [MemberID] int NOT NULL,
  [ActiveFlag] bit NOT NULL,
  [DeleteDatetime] datetime,
  [DeleteMemberId] int,
  [DeleteBackendMemberId] int
)
GO

CREATE TABLE [NewsLikes] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [NewsId] int NOT NULL,
  [MemberId] int NOT NULL,
  [Time] datetime NOT NULL
)
GO

CREATE TABLE [NewsViews] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [NewsId] int NOT NULL,
  [MemberId] int NOT NULL,
  [ViewTime] datetime NOT NULL
)
GO

CREATE TABLE [Boards] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(100) NOT NULL,
  [GameId] int,
  [BoardAbout] nvarchar(max),
  [BoardHeaderCoverImg] varchar(max)
)
GO

CREATE TABLE [BoardsModerators] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [ModeratorMemberId] int NOT NULL,
  [BoardId] int NOT NULL,
  [StartDate] datetime NOT NULL,
  [EndDate] datetime NOT NULL
)
GO

CREATE TABLE [BoardsModeratorsApplications] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [MemberId] int NOT NULL,
  [BoardId] int NOT NULL,
  [AddOrRemove] bit NOT NULL,
  [ApplyReason] nvarchar(500) NOT NULL,
  [ApprovalStatusId] int NOT NULL,
  [ApprovalResult] bit,
  [BackendMemberId] int,
  [ApprovalStatusDate] datetime
)
GO

CREATE TABLE [ApprovalStatusCodes] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(20) NOT NULL
)
GO

CREATE TABLE [MembersBoards] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [MemberId] int NOT NULL,
  [BoardId] int NOT NULL,
  [IsFavorite] bit NOT NULL
)
GO

CREATE TABLE [Posts] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [MemberId] int NOT NULL,
  [BoardId] int,
  [Content] nvarchar(1500) NOT NULL,
  [CategoryCode] int NOT NULL,
  [Datetime] datetime NOT NULL,
  [LastEditDatetime] datetime NOT NULL,
  [ActiveFlag] bit NOT NULL,
  [DeleteDatetime] datetime,
  [DeleteMemberId] int,
  [DeleteBackendMemberId] int
)
GO

CREATE TABLE [PostEditLogs] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [PostId] int NOT NULL,
  [ContentBeforeEdit] nvarchar(1500) NOT NULL,
  [EditDatetime] datetime NOT NULL
)
GO

CREATE TABLE [PostComments] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [MemberId] int NOT NULL,
  [PostId] int NOT NULL,
  [Content] nvarchar(280) NOT NULL,
  [Datetime] datetime NOT NULL,
  [ActiveFlag] bit NOT NULL,
  [DeleteDatetime] datetime,
  [DeleteMemberId] int,
  [DeleteBackendMemberId] int,
  [ParentId] int
)
GO

CREATE TABLE [PostUpDownVotes] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [MemberId] int NOT NULL,
  [PostId] int NOT NULL,
  [Date] datetime NOT NULL,
  [Type] bit NOT NULL
)
GO

CREATE TABLE [PostCommentUpDownVotes] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [MemberId] int NOT NULL,
  [PostCommentId] int NOT NULL,
  [Date] datetime NOT NULL,
  [Type] bit NOT NULL
)
GO

CREATE TABLE [PostReports] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [PostId] int NOT NULL,
  [MemberID] int NOT NULL,
  [Datetime] datetime NOT NULL,
  [Reason] nvarchar(500) NOT NULL,
  [ReviewerBackenMemberId] int,
  [ReviewDatetime] datetime,
  [IsCommit] bit NOT NULL,
  [ReviewComment] nvarchar(max)
)
GO

CREATE TABLE [PostCommentReports] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [PostCommentId] int NOT NULL,
  [MemberID] int NOT NULL,
  [Datetime] datetime NOT NULL,
  [Reason] nvarchar(500) NOT NULL,
  [ReviewerBackenMemberId] int,
  [ReviewDatetime] datetime,
  [IsCommit] bit NOT NULL,
  [ReviewComment] nvarchar(max)
)
GO

CREATE TABLE [BucketLogs] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [BucketMemberId] int NOT NULL,
  [ModeratorMemberId] int,
  [BackendMmemberId] int,
  [BoardId] int NOT NULL,
  [BucketReason] nvarchar(500) NOT NULL,
  [StartTime] datetime NOT NULL,
  [EndTime] datetime NOT NULL,
  [IsNoctified] bit NOT NULL
)
GO

CREATE TABLE [FAQ] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Question] nvarchar(max),
  [Answer] nvarchar(max),
  [CreatedAt] datetime NOT NULL,
  [IssueTypeId] int
)
GO

CREATE TABLE [Announcement] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Title] nvarchar(max),
  [Content] nvarchar(max),
  [CreatedAt] datetime NOT NULL
)
GO

ALTER TABLE [BackendMembers] ADD FOREIGN KEY ([BackendMembersRoleId]) REFERENCES [BackendMembersRolesCodes] ([Id])
GO

ALTER TABLE [BackendMembersRolePermissions] ADD FOREIGN KEY ([BackendMembersRoleId]) REFERENCES [BackendMembersRolesCodes] ([Id])
GO

ALTER TABLE [BackendMembersRolePermissions] ADD FOREIGN KEY ([BackendMemberPermissionId]) REFERENCES [BackendMembersPermissionsCodes] ([Id])
GO

ALTER TABLE [Newsletters] ADD FOREIGN KEY ([BackendMemberId]) REFERENCES [BackendMembers] ([Id])
GO

ALTER TABLE [NewsletterLogs] ADD FOREIGN KEY ([NewsletterId]) REFERENCES [Newsletters] ([Id])
GO

ALTER TABLE [NewsletterLogs] ADD FOREIGN KEY ([AddresseeMemberID]) REFERENCES [Members] ([Id])
GO

ALTER TABLE [Games] ADD FOREIGN KEY ([CreatedBackendMemberId]) REFERENCES [BackendMembers] ([Id])
GO

ALTER TABLE [Games] ADD FOREIGN KEY ([ModifiedBackendMemberId]) REFERENCES [BackendMembers] ([Id])
GO

ALTER TABLE [Products] ADD FOREIGN KEY ([GameId]) REFERENCES [Games] ([Id])
GO

ALTER TABLE [Products] ADD FOREIGN KEY ([GamePlatformId]) REFERENCES [GamePlatformsCodes] ([Id])
GO

ALTER TABLE [Products] ADD FOREIGN KEY ([ProductStatusId]) REFERENCES [ProductStatusCodes] ([Id])
GO

ALTER TABLE [Products] ADD FOREIGN KEY ([CreatedBackendMemberId]) REFERENCES [BackendMembers] ([Id])
GO

ALTER TABLE [Products] ADD FOREIGN KEY ([ModifiedBackendMemberId]) REFERENCES [BackendMembers] ([Id])
GO

ALTER TABLE [Coupons] ADD FOREIGN KEY ([DiscountTypeId]) REFERENCES [DiscountTypeCodes] ([Id])
GO

ALTER TABLE [Coupons] ADD FOREIGN KEY ([CreatedBackendMemberId]) REFERENCES [BackendMembers] ([Id])
GO

ALTER TABLE [Coupons] ADD FOREIGN KEY ([ModifiedBackendMemberId]) REFERENCES [BackendMembers] ([Id])
GO

ALTER TABLE [CouponsProducts] ADD FOREIGN KEY ([CouponId]) REFERENCES [Coupons] ([Id])
GO

ALTER TABLE [CouponsProducts] ADD FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id])
GO

ALTER TABLE [GameClassificationGames] ADD FOREIGN KEY ([GameId]) REFERENCES [Games] ([Id])
GO

ALTER TABLE [GameClassificationGames] ADD FOREIGN KEY ([GameClassificationId]) REFERENCES [GameClassificationsCodes] ([Id])
GO

ALTER TABLE [GameComments] ADD FOREIGN KEY ([GameId]) REFERENCES [Games] ([Id])
GO

ALTER TABLE [GameComments] ADD FOREIGN KEY ([MemberId]) REFERENCES [Members] ([Id])
GO

ALTER TABLE [GameComments] ADD FOREIGN KEY ([DeleteBackendMemberId]) REFERENCES [BackendMembers] ([Id])
GO

ALTER TABLE [MemberProductViews] ADD FOREIGN KEY ([MemberId]) REFERENCES [Members] ([Id])
GO

ALTER TABLE [MemberProductViews] ADD FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id])
GO

ALTER TABLE [Carts] ADD FOREIGN KEY ([MemberId]) REFERENCES [Members] ([Id])
GO

ALTER TABLE [Carts] ADD FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id])
GO

ALTER TABLE [ProductImages] ADD FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id])
GO

ALTER TABLE [Issues] ADD FOREIGN KEY ([MemberId]) REFERENCES [Members] ([Id])
GO

ALTER TABLE [Issues] ADD FOREIGN KEY ([IssueTypeId]) REFERENCES [IssueTypesCodes] ([Id])
GO

ALTER TABLE [Issues] ADD FOREIGN KEY ([Status]) REFERENCES [IssueStatusCodes] ([Id])
GO

ALTER TABLE [Replies] ADD FOREIGN KEY ([IssueId]) REFERENCES [Issues] ([Id])
GO

ALTER TABLE [Replies] ADD FOREIGN KEY ([BackendMemberId]) REFERENCES [BackendMembers] ([Id])
GO

ALTER TABLE [Orders] ADD FOREIGN KEY ([MemberId]) REFERENCES [Members] ([Id])
GO

ALTER TABLE [Orders] ADD FOREIGN KEY ([OrderStatusId]) REFERENCES [OrderStatusCodes] ([Id])
GO

ALTER TABLE [Orders] ADD FOREIGN KEY ([ShipmentStatusId]) REFERENCES [ShipmentStatusesCodes] ([Id])
GO

ALTER TABLE [Orders] ADD FOREIGN KEY ([PaymentStatusId]) REFERENCES [PaymentStatusCodes] ([Id])
GO

ALTER TABLE [Orders] ADD FOREIGN KEY ([ShipmemtMethodId]) REFERENCES [ShipmemtMethods] ([Id])
GO

ALTER TABLE [OrderItems] ADD FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id])
GO

ALTER TABLE [OrderItems] ADD FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id])
GO

ALTER TABLE [OrderItems] ADD FOREIGN KEY ([InventoryItemId]) REFERENCES [InventoryItems] ([Id])
GO

ALTER TABLE [OrderItemReturns] ADD FOREIGN KEY ([OrderItemId]) REFERENCES [OrderItems] ([Id])
GO

ALTER TABLE [OrderItemsCoupons] ADD FOREIGN KEY ([OrderItemId]) REFERENCES [OrderItems] ([Id])
GO

ALTER TABLE [OrderItemsCoupons] ADD FOREIGN KEY ([CouponId]) REFERENCES [Coupons] ([Id])
GO

ALTER TABLE [InventoryItems] ADD FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id])
GO

ALTER TABLE [InventoryItems] ADD FOREIGN KEY ([StockInSheetId]) REFERENCES [StockInSheets] ([Id])
GO

ALTER TABLE [StockInSheets] ADD FOREIGN KEY ([StockInStatusId]) REFERENCES [StockInStatusCodes] ([Id])
GO

ALTER TABLE [StockInSheets] ADD FOREIGN KEY ([SupplierId]) REFERENCES [Suppliers] ([Id])
GO

ALTER TABLE [News] ADD FOREIGN KEY ([BackendMemberId]) REFERENCES [BackendMembers] ([Id])
GO

ALTER TABLE [News] ADD FOREIGN KEY ([NewsCategoryId]) REFERENCES [NewsCategoryCodes] ([Id])
GO

ALTER TABLE [News] ADD FOREIGN KEY ([GamesId]) REFERENCES [Games] ([Id])
GO

ALTER TABLE [News] ADD FOREIGN KEY ([DeleteBackendMemberId]) REFERENCES [BackendMembers] ([Id])
GO

ALTER TABLE [NewsComments] ADD FOREIGN KEY ([NewsId]) REFERENCES [News] ([Id])
GO

ALTER TABLE [NewsComments] ADD FOREIGN KEY ([MemberID]) REFERENCES [Members] ([Id])
GO

ALTER TABLE [NewsComments] ADD FOREIGN KEY ([DeleteMemberId]) REFERENCES [Members] ([Id])
GO

ALTER TABLE [NewsComments] ADD FOREIGN KEY ([DeleteBackendMemberId]) REFERENCES [BackendMembers] ([Id])
GO

ALTER TABLE [NewsLikes] ADD FOREIGN KEY ([NewsId]) REFERENCES [News] ([Id])
GO

ALTER TABLE [NewsLikes] ADD FOREIGN KEY ([MemberId]) REFERENCES [Members] ([Id])
GO

ALTER TABLE [NewsViews] ADD FOREIGN KEY ([NewsId]) REFERENCES [News] ([Id])
GO

ALTER TABLE [NewsViews] ADD FOREIGN KEY ([MemberId]) REFERENCES [Members] ([Id])
GO

ALTER TABLE [Boards] ADD FOREIGN KEY ([GameId]) REFERENCES [Games] ([Id])
GO

ALTER TABLE [BoardsModerators] ADD FOREIGN KEY ([ModeratorMemberId]) REFERENCES [Members] ([Id])
GO

ALTER TABLE [BoardsModerators] ADD FOREIGN KEY ([BoardId]) REFERENCES [Boards] ([Id])
GO

ALTER TABLE [BoardsModeratorsApplications] ADD FOREIGN KEY ([MemberId]) REFERENCES [Members] ([Id])
GO

ALTER TABLE [BoardsModeratorsApplications] ADD FOREIGN KEY ([BoardId]) REFERENCES [Boards] ([Id])
GO

ALTER TABLE [BoardsModeratorsApplications] ADD FOREIGN KEY ([ApprovalStatusId]) REFERENCES [ApprovalStatusCodes] ([Id])
GO

ALTER TABLE [BoardsModeratorsApplications] ADD FOREIGN KEY ([BackendMemberId]) REFERENCES [BackendMembers] ([Id])
GO

ALTER TABLE [MembersBoards] ADD FOREIGN KEY ([MemberId]) REFERENCES [Members] ([Id])
GO

ALTER TABLE [MembersBoards] ADD FOREIGN KEY ([BoardId]) REFERENCES [Boards] ([Id])
GO

ALTER TABLE [Posts] ADD FOREIGN KEY ([MemberId]) REFERENCES [Members] ([Id])
GO

ALTER TABLE [Posts] ADD FOREIGN KEY ([BoardId]) REFERENCES [Boards] ([Id])
GO

ALTER TABLE [Posts] ADD FOREIGN KEY ([DeleteMemberId]) REFERENCES [Members] ([Id])
GO

ALTER TABLE [Posts] ADD FOREIGN KEY ([DeleteBackendMemberId]) REFERENCES [BackendMembers] ([Id])
GO

ALTER TABLE [PostEditLogs] ADD FOREIGN KEY ([PostId]) REFERENCES [Posts] ([Id])
GO

ALTER TABLE [PostComments] ADD FOREIGN KEY ([MemberId]) REFERENCES [Members] ([Id])
GO

ALTER TABLE [PostComments] ADD FOREIGN KEY ([PostId]) REFERENCES [Posts] ([Id])
GO

ALTER TABLE [PostComments] ADD FOREIGN KEY ([DeleteMemberId]) REFERENCES [Members] ([Id])
GO

ALTER TABLE [PostComments] ADD FOREIGN KEY ([DeleteBackendMemberId]) REFERENCES [BackendMembers] ([Id])
GO

ALTER TABLE [PostComments] ADD FOREIGN KEY ([ParentId]) REFERENCES [PostComments] ([Id])
GO

ALTER TABLE [PostUpDownVotes] ADD FOREIGN KEY ([MemberId]) REFERENCES [Members] ([Id])
GO

ALTER TABLE [PostUpDownVotes] ADD FOREIGN KEY ([PostId]) REFERENCES [Posts] ([Id])
GO

ALTER TABLE [PostCommentUpDownVotes] ADD FOREIGN KEY ([MemberId]) REFERENCES [Members] ([Id])
GO

ALTER TABLE [PostCommentUpDownVotes] ADD FOREIGN KEY ([PostCommentId]) REFERENCES [PostComments] ([Id])
GO

ALTER TABLE [PostReports] ADD FOREIGN KEY ([PostId]) REFERENCES [Posts] ([Id])
GO

ALTER TABLE [PostReports] ADD FOREIGN KEY ([MemberID]) REFERENCES [Members] ([Id])
GO

ALTER TABLE [PostReports] ADD FOREIGN KEY ([ReviewerBackenMemberId]) REFERENCES [BackendMembers] ([Id])
GO

ALTER TABLE [PostCommentReports] ADD FOREIGN KEY ([PostCommentId]) REFERENCES [PostComments] ([Id])
GO

ALTER TABLE [PostCommentReports] ADD FOREIGN KEY ([MemberID]) REFERENCES [Members] ([Id])
GO

ALTER TABLE [PostCommentReports] ADD FOREIGN KEY ([ReviewerBackenMemberId]) REFERENCES [BackendMembers] ([Id])
GO

ALTER TABLE [BucketLogs] ADD FOREIGN KEY ([BucketMemberId]) REFERENCES [Members] ([Id])
GO

ALTER TABLE [BucketLogs] ADD FOREIGN KEY ([ModeratorMemberId]) REFERENCES [Members] ([Id])
GO

ALTER TABLE [BucketLogs] ADD FOREIGN KEY ([BackendMmemberId]) REFERENCES [BackendMembers] ([Id])
GO

ALTER TABLE [BucketLogs] ADD FOREIGN KEY ([BoardId]) REFERENCES [Boards] ([Id])
GO

ALTER TABLE [FAQ] ADD FOREIGN KEY ([IssueTypeId]) REFERENCES [IssueTypesCodes] ([Id])
GO
