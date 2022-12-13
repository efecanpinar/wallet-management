using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coins_Wallets_WalletId",
                table: "Coins");

            migrationBuilder.DropIndex(
                name: "IX_Coins_WalletId",
                table: "Coins");

            migrationBuilder.DropColumn(
                name: "WalletId",
                table: "Coins");

            migrationBuilder.AddColumn<string>(
                name: "AmountOfCoin",
                table: "CoinWallets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AvarageBuyPrice",
                table: "CoinWallets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TotalWelthOfCoin",
                table: "CoinWallets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CoinWallet",
                columns: table => new
                {
                    CoinsId = table.Column<int>(type: "int", nullable: false),
                    WalletsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoinWallet", x => new { x.CoinsId, x.WalletsId });
                    table.ForeignKey(
                        name: "FK_CoinWallet_Coins_CoinsId",
                        column: x => x.CoinsId,
                        principalTable: "Coins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoinWallet_Wallets_WalletsId",
                        column: x => x.WalletsId,
                        principalTable: "Wallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoinWallet_WalletsId",
                table: "CoinWallet",
                column: "WalletsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoinWallet");

            migrationBuilder.DropColumn(
                name: "AmountOfCoin",
                table: "CoinWallets");

            migrationBuilder.DropColumn(
                name: "AvarageBuyPrice",
                table: "CoinWallets");

            migrationBuilder.DropColumn(
                name: "TotalWelthOfCoin",
                table: "CoinWallets");

            migrationBuilder.AddColumn<int>(
                name: "WalletId",
                table: "Coins",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coins_WalletId",
                table: "Coins",
                column: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coins_Wallets_WalletId",
                table: "Coins",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id");
        }
    }
}
