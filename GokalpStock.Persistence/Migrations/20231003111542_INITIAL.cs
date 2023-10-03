using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GokalpStock.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class INITIAL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACCOUNTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    USERNAME = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Authority = table.Column<int>(type: "int", nullable: false),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BILLINGS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    IS_IT_COMFIRM = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BILLINGS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BILLINGS_ACCOUNTS_ACCOUNT_ID",
                        column: x => x.ACCOUNT_ID,
                        principalTable: "ACCOUNTS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BILLING_ID = table.Column<int>(type: "int", nullable: false),
                    ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    PRODUCT_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRICE = table.Column<int>(type: "int", nullable: false),
                    IN_STOCK = table.Column<int>(type: "int", nullable: false),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_ACCOUNTS_ACCOUNT_ID",
                        column: x => x.ACCOUNT_ID,
                        principalTable: "ACCOUNTS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PRODUCTS_BILLINGS_BILLING_ID",
                        column: x => x.BILLING_ID,
                        principalTable: "BILLINGS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BILLINGS_ACCOUNT_ID",
                table: "BILLINGS",
                column: "ACCOUNT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_ACCOUNT_ID",
                table: "PRODUCTS",
                column: "ACCOUNT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_BILLING_ID",
                table: "PRODUCTS",
                column: "BILLING_ID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "BILLINGS");

            migrationBuilder.DropTable(
                name: "ACCOUNTS");
        }
    }
}
