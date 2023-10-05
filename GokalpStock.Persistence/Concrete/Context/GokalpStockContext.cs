using GokalpStock.Domain.Abstract;
using GokalpStock.Domain.Concrete;
using GokalpStock.Persistence.Concrete.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GokalpStock.Persistence.Concrete.Context
{
    public class GokalpStockContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Billing> Billings { get; set; }
        public DbSet<Product> Products { get; set; }

        public GokalpStockContext(DbContextOptions<GokalpStockContext> opt) : base(opt)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Stocks6;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AccountMapping());
            modelBuilder.ApplyConfiguration(new BillingMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangeOnSuccsess, CancellationToken cancellationToken = default) 
        {
            var entries = ChangeTracker.Entries<BaseEntity>().ToList();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                }
                if (entry.Entity is AuditableEntity auditable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Deleted:
                            auditable.ModifiedBy = "Admin";
                            auditable.ModifiedDate = DateTime.Now;
                            break;
                        case EntityState.Modified:
                            auditable.ModifiedBy = "Admin";
                            auditable.ModifiedDate = DateTime.Now;
                            break;
                        case EntityState.Added:
                            auditable.CreateDate = DateTime.Now;
                            auditable.CreatedBy = "Admin";
                            break;
                        default: break;
                    }
                }
            }
            return base.SaveChangesAsync(acceptAllChangeOnSuccsess, cancellationToken); 
        }
        
    }
}
