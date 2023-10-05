using GokalpStock.Domain.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GokalpStock.Persistence.Concrete.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("PRODUCTS");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnName("PRICE");

            builder.Property(x => x.ProductName)
                .IsRequired()
                .HasColumnName("PRODUCT_NAME");

            builder.Property(x => x.InStock)
                .IsRequired()
                .HasColumnName("IN_STOCK");

            builder.Property(x => x.AccountId)
                .IsRequired()
                .HasColumnName("ACCOUNT_ID");

            builder.Property(x => x.IsDeleted)
                
                .HasColumnName("IS_DELETED")
                .HasDefaultValueSql("0");

            builder.Property(x => x.BillingId)
                .IsRequired()
                .HasColumnName("BILLING_ID");

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("ID");

            builder.Property(x => x.CreateDate)
                
                .HasColumnName("CREATE_DATE");

            builder.Property(x => x.CreatedBy)
                
                .HasColumnName("CREATED_BY");

            builder.Property(x => x.ModifiedBy)
                
                .HasColumnName("MODIFIED_BY");

            builder.Property(x => x.ModifiedDate)
                
                .HasColumnName("MODIFIED_DATE");

            builder.HasOne(x => x.Account)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Billing)
                .WithOne(x => x.Product)
                .HasForeignKey<Product>(x => x.BillingId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
