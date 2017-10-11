namespace FlowerShop.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FlowerShop : DbContext
    {
        public FlowerShop()
            : base("name=FlowerShop")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrdersDetail> OrdersDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.website)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Accounts)
                .Map(m => m.ToTable("Account_Role").MapLeftKey("AccountId").MapRightKey("RoleId"));

            modelBuilder.Entity<Employee>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrdersDetails)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.ordersId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrdersDetail>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.photo)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrdersDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.name)
                .IsUnicode(false);
        }
    }
}
