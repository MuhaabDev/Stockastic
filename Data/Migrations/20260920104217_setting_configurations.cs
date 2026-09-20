using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stockastic.Data.Migrations
{
    /// <inheritdoc />
    public partial class setting_configurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WatchlistItems_WatchlistId",
                table: "WatchlistItems");

            migrationBuilder.AddColumn<int>(
                name: "StockId1",
                table: "WatchlistItems",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WatchlistItems_StockId1",
                table: "WatchlistItems",
                column: "StockId1");

            migrationBuilder.CreateIndex(
                name: "IX_WatchlistItems_WatchlistId_StockId",
                table: "WatchlistItems",
                columns: new[] { "WatchlistId", "StockId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchlistItems_Stocks_StockId1",
                table: "WatchlistItems",
                column: "StockId1",
                principalTable: "Stocks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchlistItems_Stocks_StockId1",
                table: "WatchlistItems");

            migrationBuilder.DropIndex(
                name: "IX_WatchlistItems_StockId1",
                table: "WatchlistItems");

            migrationBuilder.DropIndex(
                name: "IX_WatchlistItems_WatchlistId_StockId",
                table: "WatchlistItems");

            migrationBuilder.DropColumn(
                name: "StockId1",
                table: "WatchlistItems");

            migrationBuilder.CreateIndex(
                name: "IX_WatchlistItems_WatchlistId",
                table: "WatchlistItems",
                column: "WatchlistId");
        }
    }
}
