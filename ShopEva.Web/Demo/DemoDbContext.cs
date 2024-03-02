using Microsoft.EntityFrameworkCore;

namespace ShopEva.Web.Demo
{
    public class DemoDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public DemoDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(_configuration.GetConnectionString("MyDemoContextString"));
        }

        DbSet<hocsinh> hocsinhs { get; set; }
    }
}
