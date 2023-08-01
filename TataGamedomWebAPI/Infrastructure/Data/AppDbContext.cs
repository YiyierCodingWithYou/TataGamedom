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

    public virtual DbSet<AggregatedCounter> AggregatedCounters { get; set; }

    public virtual DbSet<Announcement> Announcements { get; set; }

    public virtual DbSet<ApprovalStatusCode> ApprovalStatusCodes { get; set; }

    public virtual DbSet<BackendMember> BackendMembers { get; set; }

    public virtual DbSet<BackendMembersPermissionsCode> BackendMembersPermissionsCodes { get; set; }

    public virtual DbSet<BackendMembersRolePermission> BackendMembersRolePermissions { get; set; }

    public virtual DbSet<BackendMembersRolesCode> BackendMembersRolesCodes { get; set; }

    public virtual DbSet<Board> Boards { get; set; }

    public virtual DbSet<BoardsModerator> BoardsModerators { get; set; }

    public virtual DbSet<BoardsModeratorsApplication> BoardsModeratorsApplications { get; set; }

    public virtual DbSet<BucketLog> BucketLogs { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Counter> Counters { get; set; }

    public virtual DbSet<Coupon> Coupons { get; set; }

    public virtual DbSet<CouponsProduct> CouponsProducts { get; set; }

    public virtual DbSet<DiscountTypeCode> DiscountTypeCodes { get; set; }

    public virtual DbSet<Faq> Faqs { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GameClassificationGame> GameClassificationGames { get; set; }

    public virtual DbSet<GameClassificationsCode> GameClassificationsCodes { get; set; }

    public virtual DbSet<GameComment> GameComments { get; set; }

    public virtual DbSet<GamePlatformsCode> GamePlatformsCodes { get; set; }

    public virtual DbSet<Hash> Hashes { get; set; }

    public virtual DbSet<InventoryItem> InventoryItems { get; set; }

    public virtual DbSet<Issue> Issues { get; set; }

    public virtual DbSet<IssueStatusCode> IssueStatusCodes { get; set; }

    public virtual DbSet<IssueTypesCode> IssueTypesCodes { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobParameter> JobParameters { get; set; }

    public virtual DbSet<JobQueue> JobQueues { get; set; }

    public virtual DbSet<List> Lists { get; set; }

    public virtual DbSet<Member> Members { get; set; }

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

    public virtual DbSet<Schema> Schemas { get; set; }

    public virtual DbSet<Server> Servers { get; set; }

    public virtual DbSet<Set> Sets { get; set; }

    public virtual DbSet<ShipmemtMethod> ShipmemtMethods { get; set; }

    public virtual DbSet<ShipmentStatusesCode> ShipmentStatusesCodes { get; set; }

    public virtual DbSet<StandardProduct> StandardProducts { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<StockInSheet> StockInSheets { get; set; }

    public virtual DbSet<StockInStatusCode> StockInStatusCodes { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AggregatedCounter>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PK_HangFire_CounterAggregated");

            entity.ToTable("AggregatedCounter", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_AggregatedCounter_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");

            entity.Property(e => e.Key).HasMaxLength(100);
            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Announce__3214EC076F8C9048");

            entity.ToTable("Announcement");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<ApprovalStatusCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Approval__3214EC0710AED82C");

            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<BackendMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BackendM__3214EC0742E417C8");

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
                .HasConstraintName("FK__BackendMe__Backe__17F790F9");
        });

        modelBuilder.Entity<BackendMembersPermissionsCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BackendM__3214EC075E7D4653");

            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<BackendMembersRolePermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BackendM__3214EC070FF5C968");

            entity.HasOne(d => d.BackendMemberPermission).WithMany(p => p.BackendMembersRolePermissions)
                .HasForeignKey(d => d.BackendMemberPermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BackendMe__Backe__19DFD96B");

            entity.HasOne(d => d.BackendMembersRole).WithMany(p => p.BackendMembersRolePermissions)
                .HasForeignKey(d => d.BackendMembersRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BackendMe__Backe__18EBB532");
        });

        modelBuilder.Entity<BackendMembersRolesCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BackendM__3214EC070C563F31");

            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Board>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Boards__3214EC07F6EFB42E");

            entity.Property(e => e.BoardHeaderCoverImg).IsUnicode(false);
            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.CreatedBackendMember).WithMany(p => p.Boards)
                .HasForeignKey(d => d.CreatedBackendMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Boards__CreatedB__1AD3FDA4");

            entity.HasOne(d => d.Game).WithMany(p => p.Boards)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("FK__Boards__GameId__1BC821DD");
        });

        modelBuilder.Entity<BoardsModerator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BoardsMo__3214EC0762456D53");

            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Board).WithMany(p => p.BoardsModerators)
                .HasForeignKey(d => d.BoardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BoardsMod__Board__1CBC4616");

            entity.HasOne(d => d.ModeratorMember).WithMany(p => p.BoardsModerators)
                .HasForeignKey(d => d.ModeratorMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BoardsMod__Moder__1DB06A4F");
        });

        modelBuilder.Entity<BoardsModeratorsApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BoardsMo__3214EC075247CC98");

            entity.Property(e => e.ApplyDate).HasColumnType("datetime");
            entity.Property(e => e.ApplyReason).HasMaxLength(500);
            entity.Property(e => e.ApprovalStatusDate).HasColumnType("datetime");

            entity.HasOne(d => d.ApprovalStatus).WithMany(p => p.BoardsModeratorsApplications)
                .HasForeignKey(d => d.ApprovalStatusId)
                .HasConstraintName("FK__BoardsMod__Appro__1EA48E88");

            entity.HasOne(d => d.BackendMember).WithMany(p => p.BoardsModeratorsApplications)
                .HasForeignKey(d => d.BackendMemberId)
                .HasConstraintName("FK__BoardsMod__Backe__1F98B2C1");

            entity.HasOne(d => d.Board).WithMany(p => p.BoardsModeratorsApplications)
                .HasForeignKey(d => d.BoardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BoardsMod__Board__208CD6FA");

            entity.HasOne(d => d.Member).WithMany(p => p.BoardsModeratorsApplications)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BoardsMod__Membe__2180FB33");
        });

        modelBuilder.Entity<BucketLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BucketLo__3214EC07B517B10B");

            entity.Property(e => e.BucketReason).HasMaxLength(500);
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.BackendMmember).WithMany(p => p.BucketLogs)
                .HasForeignKey(d => d.BackendMmemberId)
                .HasConstraintName("FK__BucketLog__Backe__22751F6C");

            entity.HasOne(d => d.Board).WithMany(p => p.BucketLogs)
                .HasForeignKey(d => d.BoardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BucketLog__Board__236943A5");

            entity.HasOne(d => d.BucketMember).WithMany(p => p.BucketLogBucketMembers)
                .HasForeignKey(d => d.BucketMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BucketLog__Bucke__245D67DE");

            entity.HasOne(d => d.ModeratorMember).WithMany(p => p.BucketLogModeratorMembers)
                .HasForeignKey(d => d.ModeratorMemberId)
                .HasConstraintName("FK__BucketLog__Moder__25518C17");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Carts__3214EC074F6F2B07");

            entity.HasOne(d => d.Member).WithMany(p => p.Carts)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Carts__MemberId__2645B050");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Carts__ProductId__2739D489");
        });

        modelBuilder.Entity<Counter>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.Id }).HasName("PK_HangFire_Counter");

            entity.ToTable("Counter", "HangFire");

            entity.Property(e => e.Key).HasMaxLength(100);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Coupon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Coupons__3214EC07709360B4");

            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(30);
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.ModifiedTime).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedBackendMember).WithMany(p => p.CouponCreatedBackendMembers)
                .HasForeignKey(d => d.CreatedBackendMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Coupons__Created__282DF8C2");

            entity.HasOne(d => d.DiscountType).WithMany(p => p.Coupons)
                .HasForeignKey(d => d.DiscountTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Coupons__Discoun__29221CFB");

            entity.HasOne(d => d.ModifiedBackendMember).WithMany(p => p.CouponModifiedBackendMembers)
                .HasForeignKey(d => d.ModifiedBackendMemberId)
                .HasConstraintName("FK__Coupons__Modifie__2A164134");
        });

        modelBuilder.Entity<CouponsProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CouponsP__3214EC07D4B7EA50");

            entity.HasOne(d => d.Coupon).WithMany(p => p.CouponsProducts)
                .HasForeignKey(d => d.CouponId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CouponsPr__Coupo__2B0A656D");

            entity.HasOne(d => d.Product).WithMany(p => p.CouponsProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CouponsPr__Produ__2BFE89A6");
        });

        modelBuilder.Entity<DiscountTypeCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discount__3214EC076BDBF8A4");

            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<Faq>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FAQ__3214EC07C2215F22");

            entity.ToTable("FAQ");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.IssueType).WithMany(p => p.Faqs)
                .HasForeignKey(d => d.IssueTypeId)
                .HasConstraintName("FK__FAQ__IssueTypeId__2CF2ADDF");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Games__3214EC0723B3415E");

            entity.Property(e => e.ChiName).HasMaxLength(50);
            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1500);
            entity.Property(e => e.EngName).HasMaxLength(100);
            entity.Property(e => e.GameCoverImg).HasMaxLength(100);
            entity.Property(e => e.ModifiedTime).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedBackendMember).WithMany(p => p.GameCreatedBackendMembers)
                .HasForeignKey(d => d.CreatedBackendMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Games__CreatedBa__32AB8735");

            entity.HasOne(d => d.ModifiedBackendMember).WithMany(p => p.GameModifiedBackendMembers)
                .HasForeignKey(d => d.ModifiedBackendMemberId)
                .HasConstraintName("FK__Games__ModifiedB__339FAB6E");
        });

        modelBuilder.Entity<GameClassificationGame>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GameClas__3214EC07366124A6");

            entity.HasOne(d => d.GameClassification).WithMany(p => p.GameClassificationGames)
                .HasForeignKey(d => d.GameClassificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GameClass__GameC__2DE6D218");

            entity.HasOne(d => d.Game).WithMany(p => p.GameClassificationGames)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GameClass__GameI__2EDAF651");
        });

        modelBuilder.Entity<GameClassificationsCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GameClas__3214EC076BDA457A");

            entity.Property(e => e.Name).HasMaxLength(10);
        });

        modelBuilder.Entity<GameComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GameComm__3214EC0781DC040F");

            entity.Property(e => e.Content).HasMaxLength(500);
            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.DeleteDatetime).HasColumnType("datetime");

            entity.HasOne(d => d.DeleteBackendMember).WithMany(p => p.GameComments)
                .HasForeignKey(d => d.DeleteBackendMemberId)
                .HasConstraintName("FK__GameComme__Delet__2FCF1A8A");

            entity.HasOne(d => d.Game).WithMany(p => p.GameComments)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GameComme__GameI__30C33EC3");

            entity.HasOne(d => d.Member).WithMany(p => p.GameComments)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GameComme__Membe__31B762FC");
        });

        modelBuilder.Entity<GamePlatformsCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GamePlat__3214EC0719D38634");

            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Hash>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.Field }).HasName("PK_HangFire_Hash");

            entity.ToTable("Hash", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Hash_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");

            entity.Property(e => e.Key).HasMaxLength(100);
            entity.Property(e => e.Field).HasMaxLength(100);
        });

        modelBuilder.Entity<InventoryItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Inventor__3214EC0781DD9C1A");

            entity.HasIndex(e => e.Index, "UQ__Inventor__9A5B6229FC4610D4").IsUnique();

            entity.Property(e => e.Cost).HasColumnType("decimal(8, 0)");
            entity.Property(e => e.GameKey).HasMaxLength(50);
            entity.Property(e => e.Index).HasMaxLength(20);

            entity.HasOne(d => d.Product).WithMany(p => p.InventoryItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Produ__3493CFA7");

            entity.HasOne(d => d.StockInSheet).WithMany(p => p.InventoryItems)
                .HasForeignKey(d => d.StockInSheetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Stock__3587F3E0");
        });

        modelBuilder.Entity<Issue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Issues__3214EC07BE9CBF53");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.File).HasMaxLength(600);

            entity.HasOne(d => d.IssueType).WithMany(p => p.Issues)
                .HasForeignKey(d => d.IssueTypeId)
                .HasConstraintName("FK__Issues__IssueTyp__367C1819");

            entity.HasOne(d => d.Member).WithMany(p => p.Issues)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK__Issues__MemberId__37703C52");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Issues)
                .HasForeignKey(d => d.Status)
                .HasConstraintName("FK__Issues__Status__3864608B");
        });

        modelBuilder.Entity<IssueStatusCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__IssueSta__3214EC07FB07D6D1");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<IssueTypesCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__IssueTyp__3214EC0751A7A365");

            entity.Property(e => e.TypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_HangFire_Job");

            entity.ToTable("Job", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Job_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");

            entity.HasIndex(e => e.StateName, "IX_HangFire_Job_StateName").HasFilter("([StateName] IS NOT NULL)");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            entity.Property(e => e.StateName).HasMaxLength(20);
        });

        modelBuilder.Entity<JobParameter>(entity =>
        {
            entity.HasKey(e => new { e.JobId, e.Name }).HasName("PK_HangFire_JobParameter");

            entity.ToTable("JobParameter", "HangFire");

            entity.Property(e => e.Name).HasMaxLength(40);

            entity.HasOne(d => d.Job).WithMany(p => p.JobParameters)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK_HangFire_JobParameter_Job");
        });

        modelBuilder.Entity<JobQueue>(entity =>
        {
            entity.HasKey(e => new { e.Queue, e.Id }).HasName("PK_HangFire_JobQueue");

            entity.ToTable("JobQueue", "HangFire");

            entity.Property(e => e.Queue).HasMaxLength(50);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.FetchedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<List>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.Id }).HasName("PK_HangFire_List");

            entity.ToTable("List", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_List_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");

            entity.Property(e => e.Key).HasMaxLength(100);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Members__3214EC07786C974D");

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

        modelBuilder.Entity<MemberProductView>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MemberPr__3214EC077814EA21");

            entity.Property(e => e.ViewTime).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.MemberProductViews)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MemberPro__Membe__395884C4");

            entity.HasOne(d => d.Product).WithMany(p => p.MemberProductViews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MemberPro__Produ__3A4CA8FD");
        });

        modelBuilder.Entity<MembersBoard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MembersB__3214EC0710BB5BF7");

            entity.HasOne(d => d.Board).WithMany(p => p.MembersBoards)
                .HasForeignKey(d => d.BoardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MembersBo__Board__3B40CD36");

            entity.HasOne(d => d.Member).WithMany(p => p.MembersBoards)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MembersBo__Membe__3C34F16F");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__News__3214EC07D97613C4");

            entity.Property(e => e.CoverImg).HasMaxLength(100);
            entity.Property(e => e.DeleteDatetime).HasColumnType("datetime");
            entity.Property(e => e.EditDatetime).HasColumnType("datetime");
            entity.Property(e => e.ScheduleDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.BackendMember).WithMany(p => p.NewsBackendMembers)
                .HasForeignKey(d => d.BackendMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__News__BackendMem__3D2915A8");

            entity.HasOne(d => d.DeleteBackendMember).WithMany(p => p.NewsDeleteBackendMembers)
                .HasForeignKey(d => d.DeleteBackendMemberId)
                .HasConstraintName("FK__News__DeleteBack__3E1D39E1");

            entity.HasOne(d => d.Games).WithMany(p => p.News)
                .HasForeignKey(d => d.GamesId)
                .HasConstraintName("FK__News__GamesId__3F115E1A");

            entity.HasOne(d => d.NewsCategory).WithMany(p => p.News)
                .HasForeignKey(d => d.NewsCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__News__NewsCatego__40058253");
        });

        modelBuilder.Entity<NewsCategoryCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NewsCate__3214EC07397B86D6");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<NewsComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NewsComm__3214EC07623FFBBE");

            entity.Property(e => e.Content).HasMaxLength(280);
            entity.Property(e => e.DeleteDatetime).HasColumnType("datetime");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.DeleteBackendMember).WithMany(p => p.NewsComments)
                .HasForeignKey(d => d.DeleteBackendMemberId)
                .HasConstraintName("FK__NewsComme__Delet__41EDCAC5");

            entity.HasOne(d => d.DeleteMember).WithMany(p => p.NewsCommentDeleteMembers)
                .HasForeignKey(d => d.DeleteMemberId)
                .HasConstraintName("FK__NewsComme__Delet__40F9A68C");

            entity.HasOne(d => d.Member).WithMany(p => p.NewsCommentMembers)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NewsComme__Membe__42E1EEFE");

            entity.HasOne(d => d.News).WithMany(p => p.NewsComments)
                .HasForeignKey(d => d.NewsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NewsComme__NewsI__43D61337");
        });

        modelBuilder.Entity<NewsLike>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NewsLike__3214EC07E892DBB6");

            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.NewsLikes)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NewsLikes__Membe__47A6A41B");

            entity.HasOne(d => d.News).WithMany(p => p.NewsLikes)
                .HasForeignKey(d => d.NewsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NewsLikes__NewsI__489AC854");
        });

        modelBuilder.Entity<NewsView>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NewsView__3214EC0767C2DA08");

            entity.Property(e => e.ViewTime).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.NewsViews)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NewsViews__Membe__498EEC8D");

            entity.HasOne(d => d.News).WithMany(p => p.NewsViews)
                .HasForeignKey(d => d.NewsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NewsViews__NewsI__4A8310C6");
        });

        modelBuilder.Entity<Newsletter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Newslett__3214EC073D3E894F");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.BackendMember).WithMany(p => p.Newsletters)
                .HasForeignKey(d => d.BackendMemberId)
                .HasConstraintName("FK__Newslette__Backe__46B27FE2");
        });

        modelBuilder.Entity<NewsletterLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Newslett__3214EC076ABB543D");

            entity.Property(e => e.AddresseeMemberEmail)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.AddresseeMemberId).HasColumnName("AddresseeMemberID");
            entity.Property(e => e.AddresseeMemberName).HasMaxLength(50);
            entity.Property(e => e.EmailSentDatetime).HasColumnType("datetime");

            entity.HasOne(d => d.AddresseeMember).WithMany(p => p.NewsletterLogs)
                .HasForeignKey(d => d.AddresseeMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Newslette__Addre__44CA3770");

            entity.HasOne(d => d.Newsletter).WithMany(p => p.NewsletterLogs)
                .HasForeignKey(d => d.NewsletterId)
                .HasConstraintName("FK__Newslette__Newsl__45BE5BA9");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC0743A819E5");

            entity.HasIndex(e => e.Index, "UQ__Orders__9A5B62299A9DCB7B").IsUnique();

            entity.Property(e => e.CompletedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeliveredAt).HasColumnType("datetime");
            entity.Property(e => e.Index).HasMaxLength(20);
            entity.Property(e => e.RecipientName).HasMaxLength(20);
            entity.Property(e => e.SentAt).HasColumnType("datetime");
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

            entity.HasOne(d => d.ShipmemtMethod).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShipmemtMethodId)
                .HasConstraintName("FK__Orders__Shipmemt__540C7B00");

            entity.HasOne(d => d.ShipmentStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShipmentStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
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
            entity.Property(e => e.Index).HasMaxLength(20);
            entity.Property(e => e.IssuedAt).HasColumnType("datetime");
            entity.Property(e => e.Reason).HasMaxLength(500);

            entity.HasOne(d => d.OrderItem).WithOne(p => p.OrderItemReturn)
                .HasForeignKey<OrderItemReturn>(d => d.OrderItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Order__4B7734FF");
        });

        modelBuilder.Entity<OrderItemsCoupon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3214EC07A8696374");

            entity.HasOne(d => d.Coupon).WithMany(p => p.OrderItemsCoupons)
                .HasForeignKey(d => d.CouponId)
                .HasConstraintName("FK__OrderItem__Coupo__4F47C5E3");

            entity.HasOne(d => d.OrderItem).WithMany(p => p.OrderItemsCoupons)
                .HasForeignKey(d => d.OrderItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Order__503BEA1C");
        });

        modelBuilder.Entity<OrderStatusCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderSta__3214EC074E846712");

            entity.Property(e => e.Name).HasMaxLength(15);
        });

        modelBuilder.Entity<PaymentStatusCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PaymentS__3214EC075DEA360F");

            entity.Property(e => e.Name).HasMaxLength(15);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Posts__3214EC077E146464");

            entity.Property(e => e.Content).HasMaxLength(1500);
            entity.Property(e => e.Datetime).HasColumnType("datetime");
            entity.Property(e => e.DeleteDatetime).HasColumnType("datetime");
            entity.Property(e => e.LastEditDatetime).HasColumnType("datetime");

            entity.HasOne(d => d.Board).WithMany(p => p.Posts)
                .HasForeignKey(d => d.BoardId)
                .HasConstraintName("FK__Posts__BoardId__634EBE90");

            entity.HasOne(d => d.DeleteBackendMember).WithMany(p => p.Posts)
                .HasForeignKey(d => d.DeleteBackendMemberId)
                .HasConstraintName("FK__Posts__DeleteBac__6442E2C9");

            entity.HasOne(d => d.DeleteMember).WithMany(p => p.PostDeleteMembers)
                .HasForeignKey(d => d.DeleteMemberId)
                .HasConstraintName("FK__Posts__DeleteMem__65370702");

            entity.HasOne(d => d.Member).WithMany(p => p.PostMembers)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Posts__MemberId__662B2B3B");
        });

        modelBuilder.Entity<PostComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PostComm__3214EC075BFE8522");

            entity.Property(e => e.Content).HasMaxLength(280);
            entity.Property(e => e.Datetime).HasColumnType("datetime");
            entity.Property(e => e.DeleteDatetime).HasColumnType("datetime");

            entity.HasOne(d => d.DeleteBackendMember).WithMany(p => p.PostComments)
                .HasForeignKey(d => d.DeleteBackendMemberId)
                .HasConstraintName("FK__PostComme__Delet__59C55456");

            entity.HasOne(d => d.DeleteMember).WithMany(p => p.PostCommentDeleteMembers)
                .HasForeignKey(d => d.DeleteMemberId)
                .HasConstraintName("FK__PostComme__Delet__58D1301D");

            entity.HasOne(d => d.Member).WithMany(p => p.PostCommentMembers)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostComme__Membe__5AB9788F");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK__PostComme__Paren__5BAD9CC8");

            entity.HasOne(d => d.Post).WithMany(p => p.PostComments)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostComme__PostI__5CA1C101");
        });

        modelBuilder.Entity<PostCommentReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PostComm__3214EC0726002056");

            entity.Property(e => e.Datetime).HasColumnType("datetime");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.Reason).HasMaxLength(500);
            entity.Property(e => e.ReviewDatetime).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.PostCommentReports)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostComme__Membe__55F4C372");

            entity.HasOne(d => d.PostComment).WithMany(p => p.PostCommentReports)
                .HasForeignKey(d => d.PostCommentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostComme__PostC__56E8E7AB");

            entity.HasOne(d => d.ReviewerBackenMember).WithMany(p => p.PostCommentReports)
                .HasForeignKey(d => d.ReviewerBackenMemberId)
                .HasConstraintName("FK__PostComme__Revie__57DD0BE4");
        });

        modelBuilder.Entity<PostCommentUpDownVote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PostComm__3214EC07F4AA3635");

            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.PostCommentUpDownVotes)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostComme__Membe__5D95E53A");

            entity.HasOne(d => d.PostComment).WithMany(p => p.PostCommentUpDownVotes)
                .HasForeignKey(d => d.PostCommentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostComme__PostC__5E8A0973");
        });

        modelBuilder.Entity<PostEditLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PostEdit__3214EC0776F1E205");

            entity.Property(e => e.ContentBeforeEdit).HasMaxLength(1500);
            entity.Property(e => e.EditDatetime).HasColumnType("datetime");

            entity.HasOne(d => d.Post).WithMany(p => p.PostEditLogs)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostEditL__PostI__5F7E2DAC");
        });

        modelBuilder.Entity<PostReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PostRepo__3214EC07520839C0");

            entity.Property(e => e.Datetime).HasColumnType("datetime");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.Reason).HasMaxLength(500);
            entity.Property(e => e.ReviewDatetime).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.PostReports)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostRepor__Membe__607251E5");

            entity.HasOne(d => d.Post).WithMany(p => p.PostReports)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostRepor__PostI__6166761E");

            entity.HasOne(d => d.ReviewerBackenMember).WithMany(p => p.PostReports)
                .HasForeignKey(d => d.ReviewerBackenMemberId)
                .HasConstraintName("FK__PostRepor__Revie__625A9A57");
        });

        modelBuilder.Entity<PostUpDownVote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PostUpDo__3214EC07DC31F491");

            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.PostUpDownVotes)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostUpDow__Membe__671F4F74");

            entity.HasOne(d => d.Post).WithMany(p => p.PostUpDownVotes)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostUpDow__PostI__681373AD");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC0752E4CA1C");

            entity.HasIndex(e => e.Index, "UQ__Products__9A5B6229BF6A6C19").IsUnique();

            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.Index).HasMaxLength(20);
            entity.Property(e => e.ModifiedTime).HasColumnType("datetime");
            entity.Property(e => e.SaleDate).HasColumnType("datetime");
            entity.Property(e => e.SystemRequire).HasMaxLength(1500);

            entity.HasOne(d => d.CreatedBackendMember).WithMany(p => p.ProductCreatedBackendMembers)
                .HasForeignKey(d => d.CreatedBackendMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__Create__69FBBC1F");

            entity.HasOne(d => d.Game).WithMany(p => p.Products)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("FK__Products__GameId__6AEFE058");

            entity.HasOne(d => d.GamePlatform).WithMany(p => p.Products)
                .HasForeignKey(d => d.GamePlatformId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__GamePl__6BE40491");

            entity.HasOne(d => d.ModifiedBackendMember).WithMany(p => p.ProductModifiedBackendMembers)
                .HasForeignKey(d => d.ModifiedBackendMemberId)
                .HasConstraintName("FK__Products__Modifi__6CD828CA");

            entity.HasOne(d => d.ProductStatus).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__Produc__6DCC4D03");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductI__3214EC070B8CB976");

            entity.Property(e => e.Image).HasMaxLength(100);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductIm__Produ__690797E6");
        });

        modelBuilder.Entity<ProductStatusCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductS__3214EC07A0DA3444");

            entity.Property(e => e.Name).HasMaxLength(5);
        });

        modelBuilder.Entity<Reply>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Replies__3214EC076418D4EC");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.BackendMember).WithMany(p => p.Replies)
                .HasForeignKey(d => d.BackendMemberId)
                .HasConstraintName("FK__Replies__Backend__6EC0713C");

            entity.HasOne(d => d.Issue).WithMany(p => p.Replies)
                .HasForeignKey(d => d.IssueId)
                .HasConstraintName("FK__Replies__IssueId__6FB49575");
        });

        modelBuilder.Entity<Schema>(entity =>
        {
            entity.HasKey(e => e.Version).HasName("PK_HangFire_Schema");

            entity.ToTable("Schema", "HangFire");

            entity.Property(e => e.Version).ValueGeneratedNever();
        });

        modelBuilder.Entity<Server>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_HangFire_Server");

            entity.ToTable("Server", "HangFire");

            entity.HasIndex(e => e.LastHeartbeat, "IX_HangFire_Server_LastHeartbeat");

            entity.Property(e => e.Id).HasMaxLength(200);
            entity.Property(e => e.LastHeartbeat).HasColumnType("datetime");
        });

        modelBuilder.Entity<Set>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.Value }).HasName("PK_HangFire_Set");

            entity.ToTable("Set", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Set_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");

            entity.HasIndex(e => new { e.Key, e.Score }, "IX_HangFire_Set_Score");

            entity.Property(e => e.Key).HasMaxLength(100);
            entity.Property(e => e.Value).HasMaxLength(256);
            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<ShipmemtMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Shipmemt__3214EC077A58408D");

            entity.HasIndex(e => e.Name, "UQ__Shipmemt__737584F6F62D8AB5").IsUnique();

            entity.Property(e => e.Cost).HasColumnType("decimal(8, 0)");
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<ShipmentStatusesCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Shipment__3214EC07DAF1C49F");

            entity.Property(e => e.Name).HasMaxLength(15);
        });

        modelBuilder.Entity<StandardProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Standard__3214EC074DA067DA");

            entity.HasOne(d => d.Product).WithMany(p => p.StandardProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StandardP__Produ__70A8B9AE");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => new { e.JobId, e.Id }).HasName("PK_HangFire_State");

            entity.ToTable("State", "HangFire");

            entity.HasIndex(e => e.CreatedAt, "IX_HangFire_State_CreatedAt");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Reason).HasMaxLength(100);

            entity.HasOne(d => d.Job).WithMany(p => p.States)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK_HangFire_State_Job");
        });

        modelBuilder.Entity<StockInSheet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StockInS__3214EC07C1EF7C51");

            entity.HasIndex(e => e.Index, "UQ__StockInS__9A5B6229FB91117E").IsUnique();

            entity.Property(e => e.ArrivedAt).HasColumnType("datetime");
            entity.Property(e => e.Index).HasMaxLength(20);
            entity.Property(e => e.OrderRequestDate).HasColumnType("datetime");

            entity.HasOne(d => d.StockInStatus).WithMany(p => p.StockInSheets)
                .HasForeignKey(d => d.StockInStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StockInSh__Stock__719CDDE7");

            entity.HasOne(d => d.Supplier).WithMany(p => p.StockInSheets)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StockInSh__Suppl__72910220");
        });

        modelBuilder.Entity<StockInStatusCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StockInS__3214EC076CDB2D70");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Supplier__3214EC073AA4C416");

            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(15);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
