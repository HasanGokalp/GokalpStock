using GokalpStock.Domain.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GokalpStock.Persistence.Concrete.Mapping
{
    public class BillingMapping : IEntityTypeConfiguration<Billing>
    {
        public void Configure(EntityTypeBuilder<Billing> builder)
        {
            builder.ToTable("BILLINGS");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.AccountId)
                .IsRequired()
                .HasColumnName("ACCOUNT_ID");

            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasColumnName("IS_DELETED")
                .HasDefaultValueSql("0");

            builder.Property(x => x.ProductId)
                .IsRequired()
                .HasColumnName("PRODUCT_ID");

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("ID");

            builder.Property(x => x.CreateDate)
                .IsRequired()
                .HasColumnName("CREATE_DATE");

            builder.Property(x => x.CreatedBy)
                .IsRequired()
                .HasColumnName("CREATED_BY");

            builder.Property(x => x.ModifiedBy)
                .IsRequired()
                .HasColumnName("MODIFIED_BY");

            builder.Property(x => x.ModifiedDate)
                .IsRequired()
                .HasColumnName("MODIFIED_DATE");

            builder.HasOne(x => x.Account)
                .WithMany(x => x.Billings)
                .HasForeignKey(x => x.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Product)
                .WithOne(x => x.Billing)
                .HasForeignKey<Billing>(x => x.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.IsItConfirm)
                .IsRequired()
                .HasColumnName("IS_IT_COMFIRM")
                .HasDefaultValueSql("0");

        }
    }
}
