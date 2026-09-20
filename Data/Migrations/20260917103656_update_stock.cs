using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stockastic.Data.Migrations
{
    /// <inheritdoc />
    public partial class update_stock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Industry",
                table: "Stocks",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Industry",
                table: "Stocks");
        }
    }
}
