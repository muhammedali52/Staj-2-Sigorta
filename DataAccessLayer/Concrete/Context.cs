using Microsoft.EntityFrameworkCore;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Police> Polices { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Burada veritabanı bağlantı dizesini yapılandırın
                optionsBuilder.UseSqlServer("Server=N200066\\SQLEXPRESS01;Database=stajDB;User Id=sa;Password=123123;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            // Diğer konfigürasyonlarınızı burada yapabilirsiniz
            base.OnModelCreating(modelBuilder);
        }
    }
}
