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
            entity.HasKey(e => e.Id).HasName("PK__Announce__3214EC0731A2F37B");

            entity.ToTable("Announcement");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<ApprovalStatusCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Approval__3214EC0738B218B9");

            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<BackendMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BackendM__3214EC073C0F30ED");

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
                .HasConstraintName("FK__BackendMe__Backe__2B0A656D");
        });

        modelBuilder.Entity<BackendMembersPermissionsCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BackendM__3214EC0744EAAF1F");

            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<BackendMembersRolePermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BackendM__3214EC07EBBEE756");

            entity.HasOne(d => d.BackendMemberPermission).WithMany(p => p.BackendMembersRolePermissions)
                .HasForeignKey(d => d.BackendMemberPermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BackendMe__Backe__2CF2ADDF");

            entity.HasOne(d => d.BackendMembersRole).WithMany(p => p.BackendMembersRolePermissions)
                .HasForeignKey(d => d.BackendMembersRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BackendMe__Backe__2BFE89A6");
        });

        modelBuilder.Entity<BackendMembersRolesCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BackendM__3214EC07937BC160");

            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Board>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Boards__3214EC077BDBA1CA");

            entity.Property(e => e.BoardHeaderCoverImg).IsUnicode(false);
            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.CreatedBackendMember).WithMany(p => p.Boards)
                .HasForeignKey(d => d.CreatedBackendMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Boards__CreatedB__662B2B3B");

            entity.HasOne(d => d.Game).WithMany(p => p.Boards)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("FK__Boards__GameId__65370702");
        });

        modelBuilder.Entity<BoardsModerator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BoardsMo__3214EC07E6D00860");

            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Board).WithMany(p => p.BoardsModerators)
                .HasForeignKey(d => d.BoardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BoardsMod__Board__681373AD");

            entity.HasOne(d => d.ModeratorMember).WithMany(p => p.BoardsModerators)
                .HasForeignKey(d => d.ModeratorMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BoardsMod__Moder__671F4F74");
        });

        modelBuilder.Entity<BoardsModeratorsApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BoardsMo__3214EC077B4F07BF");

            entity.Property(e => e.ApplyDate).HasColumnType("datetime");
            entity.Property(e => e.ApplyReason).HasMaxLength(500);
            entity.Property(e => e.ApprovalStatusDate).HasColumnType("datetime");

            entity.HasOne(d => d.ApprovalStatus).WithMany(p => p.BoardsModeratorsApplications)
                .HasForeignKey(d => d.ApprovalStatusId)
                .HasConstraintName("FK__BoardsMod__Appro__6BE40491");

            entity.HasOne(d => d.BackendMember).WithMany(p => p.BoardsModeratorsApplications)
                .HasForeignKey(d => d.BackendMemberId)
                .HasConstraintName("FK__BoardsMod__Backe__6AEFE058");

            entity.HasOne(d => d.Board).WithMany(p => p.BoardsModeratorsApplications)
                .HasForeignKey(d => d.BoardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BoardsMod__Board__69FBBC1F");

            entity.HasOne(d => d.Member).WithMany(p => p.BoardsModeratorsApplications)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BoardsMod__Membe__690797E6");
        });

        modelBuilder.Entity<BucketLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BucketLo__3214EC07057FCEE9");

            entity.Property(e => e.BucketReason).HasMaxLength(500);
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.BackendMmember).WithMany(p => p.BucketLogs)
                .HasForeignKey(d => d.BackendMmemberId)
                .HasConstraintName("FK__BucketLog__Backe__03BB8E22");

            entity.HasOne(d => d.Board).WithMany(p => p.BucketLogs)
                .HasForeignKey(d => d.BoardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BucketLog__Board__04AFB25B");

            entity.HasOne(d => d.BucketMember).WithMany(p => p.BucketLogBucketMembers)
                .HasForeignKey(d => d.BucketMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BucketLog__Bucke__01D345B0");

            entity.HasOne(d => d.ModeratorMember).WithMany(p => p.BucketLogModeratorMembers)
                .HasForeignKey(d => d.ModeratorMemberId)
                .HasConstraintName("FK__BucketLog__Moder__02C769E9");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Carts__3214EC071FFDBA6C");

            entity.HasOne(d => d.Member).WithMany(p => p.Carts)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Carts__MemberId__42E1EEFE");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Carts__ProductId__43D61337");
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
            entity.HasKey(e => e.Id).HasName("PK__Coupons__3214EC07BBD6FD84");

            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(30);
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.ModifiedTime).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedBackendMember).WithMany(p => p.CouponCreatedBackendMembers)
                .HasForeignKey(d => d.CreatedBackendMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Coupons__Created__3864608B");

            entity.HasOne(d => d.DiscountType).WithMany(p => p.Coupons)
                .HasForeignKey(d => d.DiscountTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Coupons__Discoun__37703C52");

            entity.HasOne(d => d.ModifiedBackendMember).WithMany(p => p.CouponModifiedBackendMembers)
                .HasForeignKey(d => d.ModifiedBackendMemberId)
                .HasConstraintName("FK__Coupons__Modifie__395884C4");
        });

        modelBuilder.Entity<CouponsProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CouponsP__3214EC070DF8D7A6");

            entity.HasOne(d => d.Coupon).WithMany(p => p.CouponsProducts)
                .HasForeignKey(d => d.CouponId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CouponsPr__Coupo__3A4CA8FD");

            entity.HasOne(d => d.Product).WithMany(p => p.CouponsProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CouponsPr__Produ__3B40CD36");
        });

        modelBuilder.Entity<DiscountTypeCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discount__3214EC07BA81FF43");

            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<Faq>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FAQ__3214EC07CF83785C");

            entity.ToTable("FAQ");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.IssueType).WithMany(p => p.Faqs)
                .HasForeignKey(d => d.IssueTypeId)
                .HasConstraintName("FK__FAQ__IssueTypeId__05A3D694");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Games__3214EC0757200B5D");

            entity.Property(e => e.ChiName).HasMaxLength(50);
            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1500);
            entity.Property(e => e.EngName).HasMaxLength(100);
            entity.Property(e => e.GameCoverImg).HasMaxLength(100);
            entity.Property(e => e.ModifiedTime).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedBackendMember).WithMany(p => p.GameCreatedBackendMembers)
                .HasForeignKey(d => d.CreatedBackendMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Games__CreatedBa__30C33EC3");

            entity.HasOne(d => d.ModifiedBackendMember).WithMany(p => p.GameModifiedBackendMembers)
                .HasForeignKey(d => d.ModifiedBackendMemberId)
                .HasConstraintName("FK__Games__ModifiedB__31B762FC");
        });

        modelBuilder.Entity<GameClassificationGame>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GameClas__3214EC07E39F5AD1");

            entity.HasOne(d => d.GameClassification).WithMany(p => p.GameClassificationGames)
                .HasForeignKey(d => d.GameClassificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GameClass__GameC__3D2915A8");

            entity.HasOne(d => d.Game).WithMany(p => p.GameClassificationGames)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GameClass__GameI__3C34F16F");
        });

        modelBuilder.Entity<GameClassificationsCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GameClas__3214EC076961F504");

            entity.Property(e => e.Name).HasMaxLength(10);
        });

        modelBuilder.Entity<GameComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GameComm__3214EC079C45272C");

            entity.Property(e => e.Content).HasMaxLength(500);
            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.DeleteDatetime).HasColumnType("datetime");

            entity.HasOne(d => d.DeleteBackendMember).WithMany(p => p.GameComments)
                .HasForeignKey(d => d.DeleteBackendMemberId)
                .HasConstraintName("FK__GameComme__Delet__40058253");

            entity.HasOne(d => d.Game).WithMany(p => p.GameComments)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GameComme__GameI__3E1D39E1");

            entity.HasOne(d => d.Member).WithMany(p => p.GameComments)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GameComme__Membe__3F115E1A");
        });

        modelBuilder.Entity<GamePlatformsCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GamePlat__3214EC073F5F2BBF");

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
            entity.HasKey(e => e.Id).HasName("PK__Inventor__3214EC070BDB5A07");

            entity.HasIndex(e => e.Index, "UQ__Inventor__9A5B6229F8DEE083").IsUnique();

            entity.Property(e => e.Cost).HasColumnType("decimal(8, 0)");
            entity.Property(e => e.GameKey).HasMaxLength(50);
            entity.Property(e => e.Index).HasMaxLength(20);

            entity.HasOne(d => d.Product).WithMany(p => p.InventoryItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Produ__55009F39");

            entity.HasOne(d => d.StockInSheet).WithMany(p => p.InventoryItems)
                .HasForeignKey(d => d.StockInSheetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Stock__55F4C372");
        });

        modelBuilder.Entity<Issue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Issues__3214EC07A79218DC");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.File).HasMaxLength(600);

            entity.HasOne(d => d.IssueType).WithMany(p => p.Issues)
                .HasForeignKey(d => d.IssueTypeId)
                .HasConstraintName("FK__Issues__IssueTyp__46B27FE2");

            entity.HasOne(d => d.Member).WithMany(p => p.Issues)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK__Issues__MemberId__45BE5BA9");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Issues)
                .HasForeignKey(d => d.Status)
                .HasConstraintName("FK__Issues__Status__47A6A41B");
        });

        modelBuilder.Entity<IssueStatusCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__IssueSta__3214EC07D918CFE7");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<IssueTypesCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__IssueTyp__3214EC07DBE7BA6A");

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
            entity.HasKey(e => e.Id).HasName("PK__Members__3214EC0772C18CB9");

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
            entity.HasKey(e => e.Id).HasName("PK__MemberPr__3214EC0774FFA1F9");

            entity.Property(e => e.ViewTime).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.MemberProductViews)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MemberPro__Membe__40F9A68C");

            entity.HasOne(d => d.Product).WithMany(p => p.MemberProductViews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MemberPro__Produ__41EDCAC5");
        });

        modelBuilder.Entity<MembersBoard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MembersB__3214EC07E18D0F7A");

            entity.HasOne(d => d.Board).WithMany(p => p.MembersBoards)
                .HasForeignKey(d => d.BoardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MembersBo__Board__6DCC4D03");

            entity.HasOne(d => d.Member).WithMany(p => p.MembersBoards)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MembersBo__Membe__6CD828CA");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__News__3214EC079C9F54B9");

            entity.Property(e => e.CoverImg).HasMaxLength(100);
            entity.Property(e => e.DeleteDatetime).HasColumnType("datetime");
            entity.Property(e => e.EditDatetime).HasColumnType("datetime");
            entity.Property(e => e.ScheduleDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.BackendMember).WithMany(p => p.NewsBackendMembers)
                .HasForeignKey(d => d.BackendMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__News__BackendMem__59C55456");

            entity.HasOne(d => d.DeleteBackendMember).WithMany(p => p.NewsDeleteBackendMembers)
                .HasForeignKey(d => d.DeleteBackendMemberId)
                .HasConstraintName("FK__News__DeleteBack__5CA1C101");

            entity.HasOne(d => d.Games).WithMany(p => p.News)
                .HasForeignKey(d => d.GamesId)
                .HasConstraintName("FK__News__GamesId__5BAD9CC8");

            entity.HasOne(d => d.NewsCategory).WithMany(p => p.News)
                .HasForeignKey(d => d.NewsCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__News__NewsCatego__5AB9788F");
        });

        modelBuilder.Entity<NewsCategoryCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NewsCate__3214EC075D2D9DEF");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<NewsComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NewsComm__3214EC073611A7E3");

            entity.Property(e => e.Content).HasMaxLength(280);
            entity.Property(e => e.DeleteDatetime).HasColumnType("datetime");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.DeleteBackendMember).WithMany(p => p.NewsComments)
                .HasForeignKey(d => d.DeleteBackendMemberId)
                .HasConstraintName("FK__NewsComme__Delet__607251E5");

            entity.HasOne(d => d.DeleteMember).WithMany(p => p.NewsCommentDeleteMembers)
                .HasForeignKey(d => d.DeleteMemberId)
                .HasConstraintName("FK__NewsComme__Delet__5F7E2DAC");

            entity.HasOne(d => d.Member).WithMany(p => p.NewsCommentMembers)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NewsComme__Membe__5E8A0973");

            entity.HasOne(d => d.News).WithMany(p => p.NewsComments)
                .HasForeignKey(d => d.NewsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NewsComme__NewsI__5D95E53A");
        });

        modelBuilder.Entity<NewsLike>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NewsLike__3214EC072E9E8BBF");

            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.NewsLikes)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NewsLikes__Membe__625A9A57");

            entity.HasOne(d => d.News).WithMany(p => p.NewsLikes)
                .HasForeignKey(d => d.NewsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NewsLikes__NewsI__6166761E");
        });

        modelBuilder.Entity<NewsView>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NewsView__3214EC0716135D20");

            entity.Property(e => e.ViewTime).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.NewsViews)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NewsViews__Membe__6442E2C9");

            entity.HasOne(d => d.News).WithMany(p => p.NewsViews)
                .HasForeignKey(d => d.NewsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NewsViews__NewsI__634EBE90");
        });

        modelBuilder.Entity<Newsletter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Newslett__3214EC07112AA7D6");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.BackendMember).WithMany(p => p.Newsletters)
                .HasForeignKey(d => d.BackendMemberId)
                .HasConstraintName("FK__Newslette__Backe__2DE6D218");
        });

        modelBuilder.Entity<NewsletterLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Newslett__3214EC0792DDF8C2");

            entity.Property(e => e.AddresseeMemberEmail)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.AddresseeMemberId).HasColumnName("AddresseeMemberID");
            entity.Property(e => e.AddresseeMemberName).HasMaxLength(50);
            entity.Property(e => e.EmailSentDatetime).HasColumnType("datetime");

            entity.HasOne(d => d.AddresseeMember).WithMany(p => p.NewsletterLogs)
                .HasForeignKey(d => d.AddresseeMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Newslette__Addre__2FCF1A8A");

            entity.HasOne(d => d.Newsletter).WithMany(p => p.NewsletterLogs)
                .HasForeignKey(d => d.NewsletterId)
                .HasConstraintName("FK__Newslette__Newsl__2EDAF651");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC079CF1DD5B");

            entity.HasIndex(e => e.Index, "UQ__Orders__9A5B6229D6132A17").IsUnique();

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
                .HasConstraintName("FK__Orders__MemberId__4A8310C6");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__OrderSta__4B7734FF");

            entity.HasOne(d => d.PaymentStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__PaymentS__4D5F7D71");

            entity.HasOne(d => d.ShipmemtMethod).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShipmemtMethodId)
                .HasConstraintName("FK__Orders__Shipmemt__4E53A1AA");

            entity.HasOne(d => d.ShipmentStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShipmentStatusId)
                .HasConstraintName("FK__Orders__Shipment__4C6B5938");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3214EC07B33B0517");

            entity.HasIndex(e => e.InventoryItemId, "UQ__OrderIte__3BB2AC81A33860DF").IsUnique();

            entity.HasIndex(e => e.Index, "UQ__OrderIte__9A5B62290CC02260").IsUnique();

            entity.Property(e => e.Index).HasMaxLength(20);
            entity.Property(e => e.ProductPrice).HasColumnType("decimal(8, 0)");

            entity.HasOne(d => d.InventoryItem).WithOne(p => p.OrderItem)
                .HasForeignKey<OrderItem>(d => d.InventoryItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Inven__51300E55");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Order__4F47C5E3");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Produ__503BEA1C");
        });

        modelBuilder.Entity<OrderItemReturn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3214EC07A77D9F02");

            entity.HasIndex(e => e.OrderItemId, "UQ__OrderIte__57ED06804B32A211").IsUnique();

            entity.HasIndex(e => e.Index, "UQ__OrderIte__9A5B62294B023E84").IsUnique();

            entity.Property(e => e.CompletedAt).HasColumnType("datetime");
            entity.Property(e => e.Index).HasMaxLength(20);
            entity.Property(e => e.IssuedAt).HasColumnType("datetime");
            entity.Property(e => e.Reason).HasMaxLength(500);

            entity.HasOne(d => d.OrderItem).WithOne(p => p.OrderItemReturn)
                .HasForeignKey<OrderItemReturn>(d => d.OrderItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Order__5224328E");
        });

        modelBuilder.Entity<OrderItemsCoupon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3214EC07C79E3155");

            entity.HasOne(d => d.Coupon).WithMany(p => p.OrderItemsCoupons)
                .HasForeignKey(d => d.CouponId)
                .HasConstraintName("FK__OrderItem__Coupo__540C7B00");

            entity.HasOne(d => d.OrderItem).WithMany(p => p.OrderItemsCoupons)
                .HasForeignKey(d => d.OrderItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Order__531856C7");
        });

        modelBuilder.Entity<OrderStatusCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderSta__3214EC074AAD2B0D");

            entity.Property(e => e.Name).HasMaxLength(15);
        });

        modelBuilder.Entity<PaymentStatusCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PaymentS__3214EC07CACCB291");

            entity.Property(e => e.Name).HasMaxLength(15);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Posts__3214EC07B6A3D2DE");

            entity.Property(e => e.Content).HasMaxLength(1500);
            entity.Property(e => e.Datetime).HasColumnType("datetime");
            entity.Property(e => e.DeleteDatetime).HasColumnType("datetime");
            entity.Property(e => e.LastEditDatetime).HasColumnType("datetime");

            entity.HasOne(d => d.Board).WithMany(p => p.Posts)
                .HasForeignKey(d => d.BoardId)
                .HasConstraintName("FK__Posts__BoardId__6FB49575");

            entity.HasOne(d => d.DeleteBackendMember).WithMany(p => p.Posts)
                .HasForeignKey(d => d.DeleteBackendMemberId)
                .HasConstraintName("FK__Posts__DeleteBac__719CDDE7");

            entity.HasOne(d => d.DeleteMember).WithMany(p => p.PostDeleteMembers)
                .HasForeignKey(d => d.DeleteMemberId)
                .HasConstraintName("FK__Posts__DeleteMem__70A8B9AE");

            entity.HasOne(d => d.Member).WithMany(p => p.PostMembers)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Posts__MemberId__6EC0713C");
        });

        modelBuilder.Entity<PostComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PostComm__3214EC0772D719B1");

            entity.Property(e => e.Content).HasMaxLength(280);
            entity.Property(e => e.Datetime).HasColumnType("datetime");
            entity.Property(e => e.DeleteDatetime).HasColumnType("datetime");

            entity.HasOne(d => d.DeleteBackendMember).WithMany(p => p.PostComments)
                .HasForeignKey(d => d.DeleteBackendMemberId)
                .HasConstraintName("FK__PostComme__Delet__76619304");

            entity.HasOne(d => d.DeleteMember).WithMany(p => p.PostCommentDeleteMembers)
                .HasForeignKey(d => d.DeleteMemberId)
                .HasConstraintName("FK__PostComme__Delet__756D6ECB");

            entity.HasOne(d => d.Member).WithMany(p => p.PostCommentMembers)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostComme__Membe__73852659");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK__PostComme__Paren__7755B73D");

            entity.HasOne(d => d.Post).WithMany(p => p.PostComments)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostComme__PostI__74794A92");
        });

        modelBuilder.Entity<PostCommentReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PostComm__3214EC07CD0D9BB5");

            entity.Property(e => e.Datetime).HasColumnType("datetime");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.Reason).HasMaxLength(500);
            entity.Property(e => e.ReviewDatetime).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.PostCommentReports)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostComme__Membe__7FEAFD3E");

            entity.HasOne(d => d.PostComment).WithMany(p => p.PostCommentReports)
                .HasForeignKey(d => d.PostCommentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostComme__PostC__7EF6D905");

            entity.HasOne(d => d.ReviewerBackenMember).WithMany(p => p.PostCommentReports)
                .HasForeignKey(d => d.ReviewerBackenMemberId)
                .HasConstraintName("FK__PostComme__Revie__00DF2177");
        });

        modelBuilder.Entity<PostCommentUpDownVote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PostComm__3214EC07F9687520");

            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.PostCommentUpDownVotes)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostComme__Membe__7A3223E8");

            entity.HasOne(d => d.PostComment).WithMany(p => p.PostCommentUpDownVotes)
                .HasForeignKey(d => d.PostCommentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostComme__PostC__7B264821");
        });

        modelBuilder.Entity<PostEditLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PostEdit__3214EC07FB8C20FC");

            entity.Property(e => e.ContentBeforeEdit).HasMaxLength(1500);
            entity.Property(e => e.EditDatetime).HasColumnType("datetime");

            entity.HasOne(d => d.Post).WithMany(p => p.PostEditLogs)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostEditL__PostI__72910220");
        });

        modelBuilder.Entity<PostReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PostRepo__3214EC07E9E884DB");

            entity.Property(e => e.Datetime).HasColumnType("datetime");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.Reason).HasMaxLength(500);
            entity.Property(e => e.ReviewDatetime).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.PostReports)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostRepor__Membe__7D0E9093");

            entity.HasOne(d => d.Post).WithMany(p => p.PostReports)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostRepor__PostI__7C1A6C5A");

            entity.HasOne(d => d.ReviewerBackenMember).WithMany(p => p.PostReports)
                .HasForeignKey(d => d.ReviewerBackenMemberId)
                .HasConstraintName("FK__PostRepor__Revie__7E02B4CC");
        });

        modelBuilder.Entity<PostUpDownVote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PostUpDo__3214EC07F90E755B");

            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.PostUpDownVotes)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostUpDow__Membe__7849DB76");

            entity.HasOne(d => d.Post).WithMany(p => p.PostUpDownVotes)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostUpDow__PostI__793DFFAF");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07C7C9A21B");

            entity.HasIndex(e => e.Index, "UQ__Products__9A5B62293AD972CF").IsUnique();

            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.Index).HasMaxLength(20);
            entity.Property(e => e.ModifiedTime).HasColumnType("datetime");
            entity.Property(e => e.SaleDate).HasColumnType("datetime");
            entity.Property(e => e.SystemRequire).HasMaxLength(1500);

            entity.HasOne(d => d.CreatedBackendMember).WithMany(p => p.ProductCreatedBackendMembers)
                .HasForeignKey(d => d.CreatedBackendMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__Create__3587F3E0");

            entity.HasOne(d => d.Game).WithMany(p => p.Products)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("FK__Products__GameId__32AB8735");

            entity.HasOne(d => d.GamePlatform).WithMany(p => p.Products)
                .HasForeignKey(d => d.GamePlatformId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__GamePl__339FAB6E");

            entity.HasOne(d => d.ModifiedBackendMember).WithMany(p => p.ProductModifiedBackendMembers)
                .HasForeignKey(d => d.ModifiedBackendMemberId)
                .HasConstraintName("FK__Products__Modifi__367C1819");

            entity.HasOne(d => d.ProductStatus).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__Produc__3493CFA7");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductI__3214EC07E98F8B1F");

            entity.Property(e => e.Image).HasMaxLength(100);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductIm__Produ__44CA3770");
        });

        modelBuilder.Entity<ProductStatusCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductS__3214EC0793D3812F");

            entity.Property(e => e.Name).HasMaxLength(5);
        });

        modelBuilder.Entity<Reply>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Replies__3214EC075AC6417D");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.BackendMember).WithMany(p => p.Replies)
                .HasForeignKey(d => d.BackendMemberId)
                .HasConstraintName("FK__Replies__Backend__498EEC8D");

            entity.HasOne(d => d.Issue).WithMany(p => p.Replies)
                .HasForeignKey(d => d.IssueId)
                .HasConstraintName("FK__Replies__IssueId__489AC854");
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
            entity.HasKey(e => e.Id).HasName("PK__Shipmemt__3214EC07371C7BE5");

            entity.HasIndex(e => e.Name, "UQ__Shipmemt__737584F699EC3B02").IsUnique();

            entity.Property(e => e.Cost).HasColumnType("decimal(8, 0)");
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<ShipmentStatusesCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Shipment__3214EC07D9ED2EC6");

            entity.Property(e => e.Name).HasMaxLength(15);
        });

        modelBuilder.Entity<StandardProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Standard__3214EC0791CE5551");

            entity.HasOne(d => d.Product).WithMany(p => p.StandardProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StandardP__Produ__58D1301D");
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
            entity.HasKey(e => e.Id).HasName("PK__StockInS__3214EC07F7371E7B");

            entity.HasIndex(e => e.Index, "UQ__StockInS__9A5B6229680847E0").IsUnique();

            entity.Property(e => e.ArrivedAt).HasColumnType("datetime");
            entity.Property(e => e.Index).HasMaxLength(20);
            entity.Property(e => e.OrderRequestDate).HasColumnType("datetime");

            entity.HasOne(d => d.StockInStatus).WithMany(p => p.StockInSheets)
                .HasForeignKey(d => d.StockInStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StockInSh__Stock__56E8E7AB");

            entity.HasOne(d => d.Supplier).WithMany(p => p.StockInSheets)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StockInSh__Suppl__57DD0BE4");
        });

        modelBuilder.Entity<StockInStatusCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StockInS__3214EC078CD228CF");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Supplier__3214EC07A240C189");

            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(15);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
