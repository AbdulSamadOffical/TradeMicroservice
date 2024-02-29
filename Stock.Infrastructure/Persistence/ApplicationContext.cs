using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Trade.Domain.Entities;

namespace Trade.Infrastructure.Persistence
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
   
        public DbSet<User> User { get; set; }
        public DbSet<StockProduct> StockProduct { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasMany(c => c.StockProduct)
                .WithOne(s => s.User)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(c => c.Order)
                .WithOne(s => s.User)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderItems>()
                .HasOne(oi => oi.Stock)
                .WithMany(s => s.OrderItems)
                .HasForeignKey(oi => oi.StockId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<OrderItems>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Status)
                .WithOne(os => os.Order);
               
           
        }

      
    }
}
