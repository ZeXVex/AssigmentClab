using LampApp.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace LampApp.Infrastructure.Data
{
    public class LampAppContext : DbContext
    {
        public LampAppContext(DbContextOptions<LampAppContext> opt) 
            : base(opt) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<OrderLine>()
                .HasKey(ol => new {ol.LampId, ol.OrderId});

            modelBuilder.Entity<OrderLine>()
                .HasOne<Order>(ol => ol.Order)
                .WithMany(o => o.OrderLines)
                .HasForeignKey(ol => ol.OrderId);

            modelBuilder.Entity<OrderLine>()
                .HasOne<Lamp>(ol => ol.Lamp)
                .WithMany(l => l.OrderLines)
                .HasForeignKey(ol => ol.OrderId);

            modelBuilder.Entity<OrderLine>()
                .HasOne<Lamp>(ol => ol.Lamp)
                .WithMany(l => l.OrderLines)
                .HasForeignKey(ol => ol.LampId);
        }
        public DbSet<Lamp> Lamps { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
    }
}