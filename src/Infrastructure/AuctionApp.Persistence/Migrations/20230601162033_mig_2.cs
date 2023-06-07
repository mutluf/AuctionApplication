using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "AppUserAuctions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AppUserAuctions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
