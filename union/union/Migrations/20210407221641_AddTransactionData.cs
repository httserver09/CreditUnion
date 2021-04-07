using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace union.Migrations
{
    public partial class AddTransactionData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<double>(type: "float", nullable: false),
                    accountCredited = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    transactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    transactionStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "transactions",
                columns: new[] { "id", "accountCredited", "accountId", "amount", "bankName", "description", "transactionDate", "transactionStatus" },
                values: new object[] { 1, "1234567", 1, 7600.8900000000003, "Chase bank", "Annual House Maintenance", new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Successfully" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transactions");
        }
    }
}
