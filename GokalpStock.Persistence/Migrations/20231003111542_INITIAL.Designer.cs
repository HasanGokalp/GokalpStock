﻿// <auto-generated />
using System;
using GokalpStock.Persistence.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GokalpStock.Persistence.Migrations
{
    [DbContext(typeof(GokalpStockContext))]
    [Migration("20231003111542_INITIAL")]
    partial class INITIAL
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GokalpStock.Domain.Concrete.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Authority")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateDate")
                        .IsRequired()
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DATE");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CREATED_BY");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("EMAIL");

                    b.Property<bool?>("IsDeleted")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasDefaultValueSql("0");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MODIFIED_BY");

                    b.Property<DateTime?>("ModifiedDate")
                        .IsRequired()
                        .HasColumnType("datetime2")
                        .HasColumnName("MODIFIED_DATE");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("NAME");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("PASSWORD");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("USERNAME");

                    b.HasKey("Id");

                    b.ToTable("ACCOUNTS", (string)null);
                });

            modelBuilder.Entity("GokalpStock.Domain.Concrete.Billing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("ACCOUNT_ID");

                    b.Property<DateTime?>("CreateDate")
                        .IsRequired()
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DATE");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CREATED_BY");

                    b.Property<bool?>("IsDeleted")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("IsItConfirm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_IT_COMFIRM")
                        .HasDefaultValueSql("0");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MODIFIED_BY");

                    b.Property<DateTime?>("ModifiedDate")
                        .IsRequired()
                        .HasColumnType("datetime2")
                        .HasColumnName("MODIFIED_DATE");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("PRODUCT_ID");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("BILLINGS", (string)null);
                });

            modelBuilder.Entity("GokalpStock.Domain.Concrete.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("ACCOUNT_ID");

                    b.Property<int>("BillingId")
                        .HasColumnType("int")
                        .HasColumnName("BILLING_ID");

                    b.Property<DateTime?>("CreateDate")
                        .IsRequired()
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DATE");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CREATED_BY");

                    b.Property<int>("InStock")
                        .HasColumnType("int")
                        .HasColumnName("IN_STOCK");

                    b.Property<bool?>("IsDeleted")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasDefaultValueSql("0");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MODIFIED_BY");

                    b.Property<DateTime?>("ModifiedDate")
                        .IsRequired()
                        .HasColumnType("datetime2")
                        .HasColumnName("MODIFIED_DATE");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("PRICE");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PRODUCT_NAME");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("BillingId")
                        .IsUnique();

                    b.ToTable("PRODUCTS", (string)null);
                });

            modelBuilder.Entity("GokalpStock.Domain.Concrete.Billing", b =>
                {
                    b.HasOne("GokalpStock.Domain.Concrete.Account", "Account")
                        .WithMany("Billings")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("GokalpStock.Domain.Concrete.Product", b =>
                {
                    b.HasOne("GokalpStock.Domain.Concrete.Account", "Account")
                        .WithMany("Products")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GokalpStock.Domain.Concrete.Billing", "Billing")
                        .WithOne("Product")
                        .HasForeignKey("GokalpStock.Domain.Concrete.Product", "BillingId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Billing");
                });

            modelBuilder.Entity("GokalpStock.Domain.Concrete.Account", b =>
                {
                    b.Navigation("Billings");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("GokalpStock.Domain.Concrete.Billing", b =>
                {
                    b.Navigation("Product")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
