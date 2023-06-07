using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_begin_date_price : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Product",
                newName: "BeginPrice");

            migrationBuilder.AddColumn<DateTime>(
                name: "BeginDate",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeginDate",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "BeginPrice",
                table: "Product",
                newName: "Price");
        }
    }
}
