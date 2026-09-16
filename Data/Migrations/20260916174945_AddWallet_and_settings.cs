using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stockastic.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddWallet_and_settings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CashBalance",
                table: "Portfolios",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CashBalance",
                table: "Portfolios");
        }
    }
}
