using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Infrastructure.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Announcement> Announcements { get; set; }

    public virtual DbSet<ApprovalStatusCode> ApprovalStatusCodes { get; set; }

    public virtual DbSet<BackendMember> BackendMembers { get; set; }

    public virtual DbSet<BackendMembersPermissionsCode> BackendMembersPermissionsCodes { get; set; }

    public virtual DbSet<BackendMembersRolePermission> BackendMembersRolePermissions { get; set; }

    public virtual DbSet<BackendMembersRolesCode> BackendMembersRolesCodes { get; set; }

    public virtual DbSet<Board> Boards { get; set; }

    public virtual DbSet<BoardNotification> BoardNotifications { get; set; }

    public virtual DbSet<BoardsModerator> BoardsModerators { get; set; }

    public virtual DbSet<BoardsModeratorsApplication> BoardsModeratorsApplications { get; set; }

    public virtual DbSet<BranchesOfSeven> BranchesOfSevens { get; set; }

    public virtual DbSet<BucketLog> BucketLogs { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<ChatMessage> ChatMessages { get; set; }

    public virtual DbSet<Coupon> Coupons { get; set; }

    public virtual DbSet<CouponsProduct> CouponsProducts { get; set; }

    public virtual DbSet<DiscountTypeCode> DiscountTypeCodes { get; set; }

    public virtual DbSet<Faq> Faqs { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GameClassificationGame> GameClassificationGames { get; set; }

    public virtual DbSet<GameClassificationsCode> GameClassificationsCodes { get; set; }

    public virtual DbSet<GameComment> GameComments { get; set; }

    public virtual DbSet<GamePlatformsCode> GamePlatformsCodes { get; set; }

    public virtual DbSet<InventoryItem> InventoryItems { get; set; }

    public virtual DbSet<Issue> Issues { get; set; }

    public virtual DbSet<IssueStatusCode> IssueStatusCodes { get; set; }

    public virtual DbSet<IssueTypesCode> IssueTypesCodes { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<MemberFollow> MemberFollows { get; set; }

    public virtual DbSet<MemberProductView> MemberProductViews { get; set; }

    public virtual DbSet<MembersBoard> MembersBoards { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<NewsCategoryCode> NewsCategoryCodes { get; set; }

    public virtual DbSet<NewsComment> NewsComments { get; set; }

    public virtual DbSet<NewsLike> NewsLikes { get; set; }

    public virtual DbSet<NewsView> NewsViews { get; set; }

    public virtual DbSet<Newsletter> Newsletters { get; set; }

    public virtual DbSet<NewsletterLog> NewsletterLogs { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<OrderItemReturn> OrderItemReturns { get; set; }

    public virtual DbSet<OrderItemsCoupon> OrderItemsCoupons { get; set; }

    public virtual DbSet<OrderStatusCode> OrderStatusCodes { get; set; }

    public virtual DbSet<PaymentStatusCode> PaymentStatusCodes { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<PostComment> PostComments { get; set; }

    public virtual DbSet<PostCommentReport> PostCommentReports { get; set; }

    public virtual DbSet<PostCommentUpDownVote> PostCommentUpDownVotes { get; set; }

    public virtual DbSet<PostEditLog> PostEditLogs { get; set; }

    public virtual DbSet<PostReport> PostReports { get; set; }

    public virtual DbSet<PostUpDownVote> PostUpDownVotes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<ProductStatusCode> ProductStatusCodes { get; set; }

    public virtual DbSet<Reply> Replies { get; set; }

    public virtual DbSet<ShipmentMethod> ShipmentMethods { get; set; }

    public virtual DbSet<ShipmentStatusesCode> ShipmentStatusesCodes { get; set; }

    public virtual DbSet<StandardProduct> StandardProducts { get; set; }

    public virtual DbSet<StockInSheet> StockInSheets { get; set; }

    public virtual DbSet<StockInStatusCode> StockInStatusCodes { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Announce__3214EC0744CB17D5");

            entity.ToTable("Announcement");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<ApprovalStatusCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Approval__3214EC07AE8ADA97");

            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<BackendMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BackendM__3214EC072C24AF65");

            entity.Property(e => e.Account)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

            entity.HasOne(d => d.BackendMembersRole).WithMany(p => p.BackendMembers)
                .HasForeignKey(d => d.BackendMembersRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BackendMe__Backe__31B762FC");
        });

        modelBuilder.Entity<BackendMembersPermissionsCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BackendM__3214EC070B9E4477");

            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<BackendMembersRolePermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BackendM__3214EC07A6F6518D");

            entity.HasOne(d => d.BackendMemberPermission).WithMany(p => p.BackendMembersRolePermissions)
                .HasForeignKey(d => d.BackendMemberPermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BackendMe__Backe__339FAB6E");

            entity.HasOne(d => d.BackendMembersRole).WithMany(p => p.BackendMembersRolePermissions)
                .HasForeignKey(d => d.BackendMembersRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BackendMe__Backe__32AB8735");
        });

        modelBuilder.Entity<BackendMembersRolesCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BackendM__3214EC07C7C2B550");

            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Board>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Boards__3214EC07DA7263D0");

            entity.Property(e => e.BoardHeaderCoverImg).IsUnicode(false);
            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.CreatedBackendMember).WithMany(p => p.Boards)
                .HasForeignKey(d => d.CreatedBackendMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Boards__CreatedB__3493CFA7");

            entity.HasOne(d => d.Game).WithMany(p => p.Boards)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("FK__Boards__GameId__3587F3E0");
        });

        modelBuilder.Entity<BoardNotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BoardNot__3214EC07B93E99E1");

            entity.Property(e => e.Content).HasMaxLength(2000);
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsReaded).HasColumnName("isReaded");
            entity.Property(e => e.Link).HasMaxLength(1000);
            entity.Property(e => e.ReadTime).HasColumnType("datetime");

            entity.HasOne(d => d.RecipientMember).WithMany(p => p.BoardNotificationRecipientMembers)
                .HasForeignKey(d => d.RecipientMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BoardNoti__Recip__12FDD1B2");

            entity.HasOne(d => d.RelationMember).WithMany(p => p.BoardNotificationRelationMembers)
                .HasForeignKey(d => d.RelationMemberId)
                .HasConstraintName("FK__BoardNoti__Relat__13F1F5EB");

            entity.HasOne(d => d.RelationPost).WithMany(p => p.BoardNotifications)
                .HasForeignKey(d => d.RelationPostId)
                .HasConstraintName("FK__BoardNoti__Relat__14E61A24");
        });

        modelBuilder.Entity<BoardsModerator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BoardsMo__3214EC07A16E5371");

            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Board).WithMany(p => p.BoardsModerators)
                .HasForeignKey(d => d.BoardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BoardsMod__Board__367C1819");

            entity.HasOne(d => d.ModeratorMember).WithMany(p => p.BoardsModerators)
                .HasForeignKey(d => d.ModeratorMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BoardsMod__Moder__37703C52");
        });

        modelBuilder.Entity<BoardsModeratorsApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BoardsMo__3214EC0731B3BE65");

            entity.Property(e => e.ApplyDate).HasColumnType("datetime");
            entity.Property(e => e.ApplyReason).HasMaxLength(500);
            entity.Property(e => e.ApprovalStatusDate).HasColumnType("datetime");

            entity.HasOne(d => d.ApprovalStatus).WithMany(p => p.BoardsModeratorsApplications)
                .HasForeignKey(d => d.ApprovalStatusId)
                .HasConstraintName("FK__BoardsMod__Appro__3864608B");

            entity.HasOne(d => d.BackendMember).WithMany(p => p.BoardsModeratorsApplications)
                .HasForeignKey(d => d.BackendMemberId)
                .HasConstraintName("FK__BoardsMod__Backe__395884C4");

            entity.HasOne(d => d.Board).WithMany(p => p.BoardsModeratorsApplications)
                .HasForeignKey(d => d.BoardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BoardsMod__Board__3A4CA8FD");

            entity.HasOne(d => d.Member).WithMany(p => p.BoardsModeratorsApplications)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BoardsMod__Membe__3B40CD36");
        });

        modelBuilder.Entity<BranchesOfSeven>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Branches__3214EC27C5E9490C");

            entity.ToTable("BranchesOfSeven");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StoreName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StoreNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BucketLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BucketLo__3214EC07C6A4089E");

            entity.Property(e => e.BucketReason).HasMaxLength(500);
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.BackendMmember).WithMany(p => p.BucketLogs)
                .HasForeignKey(d => d.BackendMmemberId)
                .HasConstraintName("FK__BucketLog__Backe__3C34F16F");

            entity.HasOne(d => d.Board).WithMany(p => p.BucketLogs)
                .HasForeignKey(d => d.BoardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BucketLog__Board__3D2915A8");

            entity.HasOne(d => d.BucketMember).WithMany(p => p.BucketLogBucketMembers)
                .HasForeignKey(d => d.BucketMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BucketLog__Bucke__3E1D39E1");

            entity.HasOne(d => d.ModeratorMember).WithMany(p => p.BucketLogModeratorMembers)
                .HasForeignKey(d => d.ModeratorMemberId)
                .HasConstraintName("FK__BucketLog__Moder__3F115E1A");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Carts__3214EC07043F272B");

            entity.HasOne(d => d.Member).WithMany(p => p.Carts)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Carts__MemberId__40058253");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Carts__ProductId__40F9A68C");
        });

        modelBuilder.Entity<ChatMessage>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ChatMessage");

            entity.Property(e => e.Content).HasMaxLength(1000);
            entity.Property(e => e.Timestamp).HasColumnType("datetime");

            entity.HasOne(d => d.BackendMember).WithMany()
                .HasForeignKey(d => d.BackendMemberId)
                .HasConstraintName("FK_ChatMessage_BackendMembers");

            entity.HasOne(d => d.Member).WithMany()
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_ChatMessage_Members");
        });

        modelBuilder.Entity<Coupon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Coupons__3214EC077F547B4A");

            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(30);
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.ModifiedTime).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedBackendMember).WithMany(p => p.CouponCreatedBackendMembers)
                .HasForeignKey(d => d.CreatedBackendMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Coupons__Created__43D61337");

            entity.HasOne(d => d.DiscountType).WithMany(p => p.Coupons)
                .HasForeignKey(d => d.DiscountTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Coupons__Discoun__44CA3770");

            entity.HasOne(d => d.ModifiedBackendMember).WithMany(p => p.CouponModifiedBackendMembers)
                .HasForeignKey(d => d.ModifiedBackendMemberId)
                .HasConstraintName("FK__Coupons__Modifie__45BE5BA9");
        });

        modelBuilder.Entity<CouponsProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CouponsP__3214EC075422D933");

            entity.HasOne(d => d.Coupon).WithMany(p => p.CouponsProducts)
                .HasForeignKey(d => d.CouponId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CouponsPr__Coupo__46B27FE2");

            entity.HasOne(d => d.Product).WithMany(p => p.CouponsProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CouponsPr__Produ__47A6A41B");
        });

        modelBuilder.Entity<DiscountTypeCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discount__3214EC07D1CAC334");

            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<Faq>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FAQ__3214EC0793C43210");

            entity.ToTable("FAQ");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.IssueType).WithMany(p => p.Faqs)
                .HasForeignKey(d => d.IssueTypeId)
                .HasConstraintName("FK__FAQ__IssueTypeId__489AC854");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Games__3214EC07910EE496");

            entity.Property(e => e.ChiName).HasMaxLength(50);
            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1500);
            entity.Property(e => e.EngName).HasMaxLength(100);
            entity.Property(e => e.GameCoverImg).HasMaxLength(100);
            entity.Property(e => e.ModifiedTime).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedBackendMember).WithMany(p => p.GameCreatedBackendMembers)
                .HasForeignKey(d => d.CreatedBackendMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Games__CreatedBa__4E53A1AA");

            entity.HasOne(d => d.ModifiedBackendMember).WithMany(p => p.GameModifiedBackendMembers)
                .HasForeignKey(d => d.ModifiedBackendMemberId)
                .HasConstraintName("FK__Games__ModifiedB__4F47C5E3");
        });

        modelBuilder.Entity<GameClassificationGame>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GameClas__3214EC07937EDA89");

            entity.HasOne(d => d.GameClassification).WithMany(p => p.GameClassificationGames)
                .HasForeignKey(d => d.GameClassificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GameClass__GameC__498EEC8D");

            entity.HasOne(d => d.Game).WithMany(p => p.GameClassificationGames)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GameClass__GameI__4A8310C6");
        });

        modelBuilder.Entity<GameClassificationsCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GameClas__3214EC0703AE2206");

            entity.Property(e => e.Name).HasMaxLength(10);
        });

        modelBuilder.Entity<GameComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GameComm__3214EC07F0F653A3");

            entity.Property(e => e.Content).HasMaxLength(500);
            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.DeleteDatetime).HasColumnType("datetime");

            entity.HasOne(d => d.DeleteBackendMember).WithMany(p => p.GameComments)
                .HasForeignKey(d => d.DeleteBackendMemberId)
                .HasConstraintName("FK__GameComme__Delet__4B7734FF");

            entity.HasOne(d => d.Game).WithMany(p => p.GameComments)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GameComme__GameI__4C6B5938");

            entity.HasOne(d => d.Member).WithMany(p => p.GameComments)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GameComme__Membe__4D5F7D71");
        });

        modelBuilder.Entity<GamePlatformsCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GamePlat__3214EC073939C40B");

            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<InventoryItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Inventor__3214EC07FA093884");

            entity.HasIndex(e => e.Index, "UQ__Inventor__9A5B62294C645919").IsUnique();

            entity.Property(e => e.Cost).HasColumnType("decimal(8, 0)");
            entity.Property(e => e.GameKey).HasMaxLength(50);
            entity.Property(e => e.Index).HasMaxLength(20);

            entity.HasOne(d => d.Product).WithMany(p => p.InventoryItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Produ__503BEA1C");

            entity.HasOne(d => d.StockInSheet).WithMany(p => p.InventoryItems)
                .HasForeignKey(d => d.StockInSheetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Stock__51300E55");
        });

        modelBuilder.Entity<Issue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Issues__3214EC0738E0B862");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.File).HasMaxLength(600);

            entity.HasOne(d => d.IssueType).WithMany(p => p.Issues)
                .HasForeignKey(d => d.IssueTypeId)
                .HasConstraintName("FK__Issues__IssueTyp__5224328E");

            entity.HasOne(d => d.Member).WithMany(p => p.Issues)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK__Issues__MemberId__531856C7");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Issues)
                .HasForeignKey(d => d.Status)
                .HasConstraintName("FK__Issues__Status__540C7B00");
        });

        modelBuilder.Entity<IssueStatusCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__IssueSta__3214EC07F657854B");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<IssueTypesCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__IssueTyp__3214EC07ABF1223E");

            entity.Property(e => e.TypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Members__3214EC0778002C7C");

            entity.Property(e => e.AboutMe).HasMaxLength(500);
            entity.Property(e => e.Account)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.ConfirmCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.IconImg).HasMaxLength(100);
            entity.Property(e => e.LastOnlineTime).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<MemberFollow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MemberFo__3213E83FCB3F974F");

            entity.HasOne(d => d.FollowedMember).WithMany(p => p.MemberFollowFollowedMembers)
                .HasForeignKey(d => d.FollowedMemberId)
                .HasConstraintName("FK__MemberFol__follo__55BFB948");

            entity.HasOne(d => d.FollowerMember).WithMany(p => p.MemberFollowFollowerMembers)
                .HasForeignKey(d => d.FollowerMemberId)
                .HasConstraintName("FK__MemberFol__follo__54CB950F");
        });

        modelBuilder.Entity<MemberProductView>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MemberPr__3214EC077559485B");

            entity.Property(e => e.ViewTime).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.MemberProductViews)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MemberPro__Membe__56E8E7AB");

            entity.HasOne(d => d.Product).WithMany(p => p.MemberProductViews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MemberPro__Produ__57DD0BE4");
        });

        modelBuilder.Entity<MembersBoard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MembersB__3214EC07C43EF7C1");

            entity.HasOne(d => d.Board).WithMany(p => p.MembersBoards)
                .HasForeignKey(d => d.BoardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MembersBo__Board__58D1301D");

            entity.HasOne(d => d.Member).WithMany(p => p.MembersBoards)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MembersBo__Membe__59C55456");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__News__3214EC077203D085");

            entity.Property(e => e.CoverImg).HasMaxLength(100);
            entity.Property(e => e.DeleteDatetime).HasColumnType("datetime");
            entity.Property(e => e.EditDatetime).HasColumnType("datetime");
            entity.Property(e => e.ScheduleDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.BackendMember).WithMany(p => p.NewsBackendMembers)
                .HasForeignKey(d => d.BackendMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__News__BackendMem__5AB9788F");

            entity.HasOne(d => d.DeleteBackendMember).WithMany(p => p.NewsDeleteBackendMembers)
                .HasForeignKey(d => d.DeleteBackendMemberId)
                .HasConstraintName("FK__News__DeleteBack__5BAD9CC8");

            entity.HasOne(d => d.Games).WithMany(p => p.News)
                .HasForeignKey(d => d.GamesId)
                .HasConstraintName("FK__News__GamesId__5CA1C101");

            entity.HasOne(d => d.NewsCategory).WithMany(p => p.News)
                .HasForeignKey(d => d.NewsCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__News__NewsCatego__5D95E53A");
        });

        modelBuilder.Entity<NewsCategoryCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NewsCate__3214EC07B24872E7");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<NewsComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NewsComm__3214EC0737D03377");

            entity.Property(e => e.Content).HasMaxLength(280);
            entity.Property(e => e.DeleteDatetime).HasColumnType("datetime");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.DeleteBackendMember).WithMany(p => p.NewsComments)
                .HasForeignKey(d => d.DeleteBackendMemberId)
                .HasConstraintName("FK__NewsComme__Delet__5F7E2DAC");

            entity.HasOne(d => d.DeleteMember).WithMany(p => p.NewsCommentDeleteMembers)
                .HasForeignKey(d => d.DeleteMemberId)
                .HasConstraintName("FK__NewsComme__Delet__5E8A0973");

            entity.HasOne(d => d.Member).WithMany(p => p.NewsCommentMembers)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NewsComme__Membe__607251E5");

            entity.HasOne(d => d.News).WithMany(p => p.NewsComments)
                .HasForeignKey(d => d.NewsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NewsComme__NewsI__6166761E");
        });

        modelBuilder.Entity<NewsLike>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NewsLike__3214EC0776580830");

            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.NewsLikes)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NewsLikes__Membe__65370702");

            entity.HasOne(d => d.News).WithMany(p => p.NewsLikes)
                .HasForeignKey(d => d.NewsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NewsLikes__NewsI__662B2B3B");
        });

        modelBuilder.Entity<NewsView>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NewsView__3214EC07E9BE321C");

            entity.Property(e => e.ViewTime).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.NewsViews)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NewsViews__Membe__671F4F74");

            entity.HasOne(d => d.News).WithMany(p => p.NewsViews)
                .HasForeignKey(d => d.NewsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NewsViews__NewsI__681373AD");
        });

        modelBuilder.Entity<Newsletter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Newslett__3214EC071CF82921");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.BackendMember).WithMany(p => p.Newsletters)
                .HasForeignKey(d => d.BackendMemberId)
                .HasConstraintName("FK__Newslette__Backe__6442E2C9");
        });

        modelBuilder.Entity<NewsletterLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Newslett__3214EC07BEF43A29");

            entity.Property(e => e.AddresseeMemberEmail)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.AddresseeMemberId).HasColumnName("AddresseeMemberID");
            entity.Property(e => e.AddresseeMemberName).HasMaxLength(50);
            entity.Property(e => e.EmailSentDatetime).HasColumnType("datetime");

            entity.HasOne(d => d.AddresseeMember).WithMany(p => p.NewsletterLogs)
                .HasForeignKey(d => d.AddresseeMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Newslette__Addre__625A9A57");

            entity.HasOne(d => d.Newsletter).WithMany(p => p.NewsletterLogs)
                .HasForeignKey(d => d.NewsletterId)
                .HasConstraintName("FK__Newslette__Newsl__634EBE90");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC0743A819E5");

            entity.HasIndex(e => e.Index, "UQ__Orders__9A5B62299A9DCB7B").IsUnique();

            entity.Property(e => e.CompletedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CreditCardBrand).HasMaxLength(20);
            entity.Property(e => e.DeliveredAt).HasColumnType("datetime");
            entity.Property(e => e.Index).HasMaxLength(30);
            entity.Property(e => e.LinePayTransactionId).HasMaxLength(30);
            entity.Property(e => e.MaskedCreditCardNumber).HasMaxLength(20);
            entity.Property(e => e.PaidAt).HasColumnType("datetime");
            entity.Property(e => e.ReceiverCellPhone).HasMaxLength(20);
            entity.Property(e => e.ReceiverEmail).HasMaxLength(50);
            entity.Property(e => e.RecipientName).HasMaxLength(20);
            entity.Property(e => e.SentAt).HasColumnType("datetime");
            entity.Property(e => e.ShippingFee).HasColumnType("decimal(8, 0)");
            entity.Property(e => e.ToAddress).HasMaxLength(50);
            entity.Property(e => e.TrackingNum).HasMaxLength(20);

            entity.HasOne(d => d.Member).WithMany(p => p.Orders)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__MemberId__51300E55");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__OrderSta__5224328E");

            entity.HasOne(d => d.PaymentStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__PaymentS__531856C7");

            entity.HasOne(d => d.ShipmentMethod).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShipmentMethodId)
                .HasConstraintName("FK__Orders__Shipmemt__540C7B00");

            entity.HasOne(d => d.ShipmentStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShipmentStatusId)
                .HasConstraintName("FK__Orders__Shipment__55009F39");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3214EC07A2DE618F");

            entity.HasIndex(e => e.InventoryItemId, "UQ__OrderIte__3BB2AC81819DD448").IsUnique();

            entity.HasIndex(e => e.Index, "UQ__OrderIte__9A5B62295905CB9C").IsUnique();

            entity.Property(e => e.Index).HasMaxLength(20);
            entity.Property(e => e.ProductPrice).HasColumnType("decimal(8, 0)");

            entity.HasOne(d => d.InventoryItem).WithOne(p => p.OrderItem)
                .HasForeignKey<OrderItem>(d => d.InventoryItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Inven__4C6B5938");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Order__4D5F7D71");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Produ__4E53A1AA");
        });

        modelBuilder.Entity<OrderItemReturn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3214EC07661B879E");

            entity.HasIndex(e => e.OrderItemId, "UQ__OrderIte__57ED0680FBF10CC1").IsUnique();

            entity.HasIndex(e => e.Index, "UQ__OrderIte__9A5B6229DB395A7A").IsUnique();

            entity.Property(e => e.CompletedAt).HasColumnType("datetime");
            entity.Property(e => e.Index).HasMaxLength(50);
            entity.Property(e => e.IssuedAt).HasColumnType("datetime");
            entity.Property(e => e.LinePayRefundTransactionId).HasMaxLength(25);
            entity.Property(e => e.Reason).HasMaxLength(500);

            entity.HasOne(d => d.OrderItem).WithOne(p => p.OrderItemReturn)
                .HasForeignKey<OrderItemReturn>(d => d.OrderItemId)
                .HasConstraintName("FK__OrderItem__Order__4B7734FF");
        });

        modelBuilder.Entity<OrderItemsCoupon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3214EC0731D8548A");

            entity.HasOne(d => d.Coupon).WithMany(p => p.OrderItemsCoupons)
                .HasForeignKey(d => d.CouponId)
                .HasConstraintName("FK__OrderItem__Coupo__6CD828CA");

            entity.HasOne(d => d.OrderItem).WithMany(p => p.OrderItemsCoupons)
                .HasForeignKey(d => d.OrderItemId)
                .HasConstraintName("FK__OrderItem__Order__503BEA1C");
        });

        modelBuilder.Entity<OrderStatusCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderSta__3214EC07F15A0C82");

            entity.Property(e => e.Name).HasMaxLength(15);
        });

        modelBuilder.Entity<PaymentStatusCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PaymentS__3214EC07965D7DE8");

            entity.Property(e => e.Name).HasMaxLength(15);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Posts__3214EC076E77EF7E");

            entity.Property(e => e.Content).HasMaxLength(2500);
            entity.Property(e => e.Datetime).HasColumnType("datetime");
            entity.Property(e => e.DeleteDatetime).HasColumnType("datetime");
            entity.Property(e => e.LastEditDatetime).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Board).WithMany(p => p.Posts)
                .HasForeignKey(d => d.BoardId)
                .HasConstraintName("FK__Posts__BoardId__00DF2177");

            entity.HasOne(d => d.DeleteBackendMember).WithMany(p => p.Posts)
                .HasForeignKey(d => d.DeleteBackendMemberId)
                .HasConstraintName("FK__Posts__DeleteBac__01D345B0");

            entity.HasOne(d => d.DeleteMember).WithMany(p => p.PostDeleteMembers)
                .HasForeignKey(d => d.DeleteMemberId)
                .HasConstraintName("FK__Posts__DeleteMem__02C769E9");

            entity.HasOne(d => d.Member).WithMany(p => p.PostMembers)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Posts__MemberId__03BB8E22");
        });

        modelBuilder.Entity<PostComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PostComm__3214EC07F2A63DB6");

            entity.Property(e => e.Content).HasMaxLength(280);
            entity.Property(e => e.Datetime).HasColumnType("datetime");
            entity.Property(e => e.DeleteDatetime).HasColumnType("datetime");

            entity.HasOne(d => d.DeleteBackendMember).WithMany(p => p.PostComments)
                .HasForeignKey(d => d.DeleteBackendMemberId)
                .HasConstraintName("FK__PostComme__Delet__7755B73D");

            entity.HasOne(d => d.DeleteMember).WithMany(p => p.PostCommentDeleteMembers)
                .HasForeignKey(d => d.DeleteMemberId)
                .HasConstraintName("FK__PostComme__Delet__76619304");

            entity.HasOne(d => d.Member).WithMany(p => p.PostCommentMembers)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostComme__Membe__7849DB76");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK__PostComme__Paren__793DFFAF");

            entity.HasOne(d => d.Post).WithMany(p => p.PostComments)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostComme__PostI__7A3223E8");
        });

        modelBuilder.Entity<PostCommentReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PostComm__3214EC0796BCA603");

            entity.Property(e => e.Datetime).HasColumnType("datetime");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.Reason).HasMaxLength(500);
            entity.Property(e => e.ReviewDatetime).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.PostCommentReports)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostComme__Membe__73852659");

            entity.HasOne(d => d.PostComment).WithMany(p => p.PostCommentReports)
                .HasForeignKey(d => d.PostCommentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostComme__PostC__74794A92");

            entity.HasOne(d => d.ReviewerBackenMember).WithMany(p => p.PostCommentReports)
                .HasForeignKey(d => d.ReviewerBackenMemberId)
                .HasConstraintName("FK__PostComme__Revie__756D6ECB");
        });

        modelBuilder.Entity<PostCommentUpDownVote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PostComm__3214EC0729AAEC27");

            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.PostCommentUpDownVotes)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostComme__Membe__7B264821");

            entity.HasOne(d => d.PostComment).WithMany(p => p.PostCommentUpDownVotes)
                .HasForeignKey(d => d.PostCommentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostComme__PostC__7C1A6C5A");
        });

        modelBuilder.Entity<PostEditLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PostEdit__3214EC076ED9F9EF");

            entity.Property(e => e.ContentBeforeEdit).HasMaxLength(1500);
            entity.Property(e => e.EditDatetime).HasColumnType("datetime");

            entity.HasOne(d => d.Post).WithMany(p => p.PostEditLogs)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostEditL__PostI__7D0E9093");
        });

        modelBuilder.Entity<PostReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PostRepo__3214EC0705C499B1");

            entity.Property(e => e.Datetime).HasColumnType("datetime");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.Reason).HasMaxLength(500);
            entity.Property(e => e.ReviewDatetime).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.PostReports)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostRepor__Membe__7E02B4CC");

            entity.HasOne(d => d.Post).WithMany(p => p.PostReports)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostRepor__PostI__7EF6D905");

            entity.HasOne(d => d.ReviewerBackenMember).WithMany(p => p.PostReports)
                .HasForeignKey(d => d.ReviewerBackenMemberId)
                .HasConstraintName("FK__PostRepor__Revie__7FEAFD3E");
        });

        modelBuilder.Entity<PostUpDownVote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PostUpDo__3214EC077FE9978F");

            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.PostUpDownVotes)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostUpDow__Membe__04AFB25B");

            entity.HasOne(d => d.Post).WithMany(p => p.PostUpDownVotes)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostUpDow__PostI__05A3D694");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC075E8B639E");

            entity.HasIndex(e => e.Index, "UQ__Products__9A5B6229C482EC11").IsUnique();

            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.Index).HasMaxLength(20);
            entity.Property(e => e.ModifiedTime).HasColumnType("datetime");
            entity.Property(e => e.SaleDate).HasColumnType("datetime");
            entity.Property(e => e.SystemRequire).HasMaxLength(1500);

            entity.HasOne(d => d.CreatedBackendMember).WithMany(p => p.ProductCreatedBackendMembers)
                .HasForeignKey(d => d.CreatedBackendMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__Create__078C1F06");

            entity.HasOne(d => d.Game).WithMany(p => p.Products)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("FK__Products__GameId__0880433F");

            entity.HasOne(d => d.GamePlatform).WithMany(p => p.Products)
                .HasForeignKey(d => d.GamePlatformId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__GamePl__09746778");

            entity.HasOne(d => d.ModifiedBackendMember).WithMany(p => p.ProductModifiedBackendMembers)
                .HasForeignKey(d => d.ModifiedBackendMemberId)
                .HasConstraintName("FK__Products__Modifi__0A688BB1");

            entity.HasOne(d => d.ProductStatus).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__Produc__0B5CAFEA");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductI__3214EC0741607EC1");

            entity.Property(e => e.Image).HasMaxLength(100);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductIm__Produ__0697FACD");
        });

        modelBuilder.Entity<ProductStatusCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductS__3214EC0784487DC2");

            entity.Property(e => e.Name).HasMaxLength(5);
        });

        modelBuilder.Entity<Reply>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Replies__3214EC07CB859A87");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.BackendMember).WithMany(p => p.Replies)
                .HasForeignKey(d => d.BackendMemberId)
                .HasConstraintName("FK__Replies__Backend__0C50D423");

            entity.HasOne(d => d.Issue).WithMany(p => p.Replies)
                .HasForeignKey(d => d.IssueId)
                .HasConstraintName("FK__Replies__IssueId__0D44F85C");
        });

        modelBuilder.Entity<ShipmentMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Shipment__3214EC074B245F0F");

            entity.HasIndex(e => e.Name, "UQ__Shipment__737584F648DA1223").IsUnique();

            entity.Property(e => e.Cost).HasColumnType("decimal(8, 0)");
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<ShipmentStatusesCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Shipment__3214EC0734AB0240");

            entity.Property(e => e.Name).HasMaxLength(15);
        });

        modelBuilder.Entity<StandardProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Standard__3214EC07D813FA45");

            entity.HasOne(d => d.Product).WithMany(p => p.StandardProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StandardP__Produ__0E391C95");
        });

        modelBuilder.Entity<StockInSheet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StockInS__3214EC077E825A4B");

            entity.HasIndex(e => e.Index, "UQ__StockInS__9A5B6229675C7B7A").IsUnique();

            entity.Property(e => e.ArrivedAt).HasColumnType("datetime");
            entity.Property(e => e.Index).HasMaxLength(20);
            entity.Property(e => e.OrderRequestDate).HasColumnType("datetime");

            entity.HasOne(d => d.StockInStatus).WithMany(p => p.StockInSheets)
                .HasForeignKey(d => d.StockInStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StockInSh__Stock__0F2D40CE");

            entity.HasOne(d => d.Supplier).WithMany(p => p.StockInSheets)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StockInSh__Suppl__10216507");
        });

        modelBuilder.Entity<StockInStatusCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StockInS__3214EC07B784C350");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Supplier__3214EC07FE6A35E8");

            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(15);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
