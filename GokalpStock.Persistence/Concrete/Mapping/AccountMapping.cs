using GokalpStock.Domain.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GokalpStock.Persistence.Concrete.Mapping
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("ACCOUNTS");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar(15)")
                .HasColumnName("NAME");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnType("nvarchar(50)")
                .HasColumnName("EMAIL");

            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasColumnName("IS_DELETED")
                .HasDefaultValueSql("0");

            builder.Property(x => x.UserName)
                .IsRequired()
                .HasColumnType("nvarchar(15)")
                .HasColumnName("USERNAME");

            builder.Property(x => x.Password)
                .IsRequired()
                .HasColumnType("nvarchar(15)")
                .HasColumnName("PASSWORD");

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

            builder.HasMany(x => x.Billings)
                .WithOne(x => x.Account)
                .HasForeignKey(x => x.AccountId);

            builder.HasMany(x => x.Products)
                 .WithOne(x => x.Account)
                 .HasForeignKey(x => x.AccountId);
        }
    }
}
