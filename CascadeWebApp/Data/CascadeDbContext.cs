using Microsoft.EntityFrameworkCore;
using CascadeWebApp.Models;

namespace CascadeWebApp.Data
{
    public class CascadeDbContext : DbContext
    {
        public CascadeDbContext(DbContextOptions<CascadeDbContext> options) : base(options)
        {
        }

        // DbSets for all entities
        public DbSet<Items> Items { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<OrdersList> OrdersList { get; set; }
        public DbSet<BatchList> BatchList { get; set; }
        public DbSet<OrderContents> OrderContents { get; set; }
        public DbSet<BatchContents> BatchContents { get; set; }
        public DbSet<BatchLoss> BatchLoss { get; set; }
        public DbSet<BatchAssignments> BatchAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and constraints
            
            // OrdersList relationships
            modelBuilder.Entity<OrdersList>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            // OrderContents relationships
            modelBuilder.Entity<OrderContents>()
                .HasOne(oc => oc.Order)
                .WithMany(o => o.OrderContents)
                .HasForeignKey(oc => oc.OrderID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderContents>()
                .HasOne(oc => oc.Item)
                .WithMany(i => i.OrderContents)
                .HasForeignKey(oc => oc.ProductID)
                .OnDelete(DeleteBehavior.Restrict);

            // BatchContents relationships
            modelBuilder.Entity<BatchContents>()
                .HasOne(bc => bc.Batch)
                .WithMany(b => b.BatchContents)
                .HasForeignKey(bc => bc.BatchID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BatchContents>()
                .HasOne(bc => bc.Item)
                .WithMany(i => i.BatchContents)
                .HasForeignKey(bc => bc.ProductID)
                .OnDelete(DeleteBehavior.Restrict);

            // BatchLoss relationships
            modelBuilder.Entity<BatchLoss>()
                .HasOne(bl => bl.Batch)
                .WithMany(b => b.BatchLoss)
                .HasForeignKey(bl => bl.BatchID)
                .OnDelete(DeleteBehavior.Cascade);

            // BatchAssignments relationships
            modelBuilder.Entity<BatchAssignments>()
                .HasOne(ba => ba.Batch)
                .WithMany(b => b.BatchAssignments)
                .HasForeignKey(ba => ba.BatchID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BatchAssignments>()
                .HasOne(ba => ba.Order)
                .WithMany(o => o.BatchAssignments)
                .HasForeignKey(ba => ba.OrdersID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure decimal precision
            modelBuilder.Entity<BatchContents>()
                .Property(bc => bc.EstimatedWeight)
                .HasPrecision(18, 2);

            modelBuilder.Entity<BatchContents>()
                .Property(bc => bc.ActualWeight)
                .HasPrecision(18, 2);

            modelBuilder.Entity<BatchLoss>()
                .Property(bl => bl.LossQuantity)
                .HasPrecision(18, 2);

            modelBuilder.Entity<BatchLoss>()
                .Property(bl => bl.LossWeight)
                .HasPrecision(18, 2);
        }
    }
}