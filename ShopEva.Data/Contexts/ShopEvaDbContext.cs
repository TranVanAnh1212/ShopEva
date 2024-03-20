
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShopEva.Models.Model;

namespace ShopEva.Data.Contexts
{
    public class ShopEvaDbContext : IdentityDbContext<ApplicationUser>
    {
        public ShopEvaDbContext(DbContextOptions<ShopEvaDbContext> options) : base(options) { }

        public ShopEvaDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=ShopEva;Username=postgres;Password=123456");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Sys_Status> Sys_Statuses { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuGroup> MenuGroups { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductsDetail { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductProductCategory> ProductProductCategories { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<SupportOnline> SupportOnlines { get; set; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<VisitorStatistic> VisitorStatistics { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Error> Errors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostTag>(e => e.HasKey(x => new { x.PostID, x.TagID }));
            modelBuilder.Entity<ProductTag>(e => e.HasKey(x => new { x.ProductID, x.TagID }));
            modelBuilder.Entity<OrderDetail>(e => e.HasKey(x => new { x.OrderID, x.ProductID }));
            modelBuilder.Entity<ProductProductCategory>(e => e.HasKey(x => new { x.CategoryID, x.ProductID }));

            modelBuilder.Entity<Product>(e =>
            {
                e.Property(x => x.ViewCount).HasDefaultValueSql("0");
                e.Property(x => x.BuyCount).HasDefaultValueSql("0");
                e.Property(x => x.ReviewCount).HasDefaultValueSql("0");
            });

            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);

            // Bỏ tiền tố AspNet của các bảng: mặc định các bảng trong IdentityDbContext có
            // tên với tiền tố AspNet như: AspNetUserRoles, AspNetUser ...
            // Đoạn mã sau chạy khi khởi tạo DbContext, tạo database sẽ loại bỏ tiền tố đó
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
        }

    }
}
