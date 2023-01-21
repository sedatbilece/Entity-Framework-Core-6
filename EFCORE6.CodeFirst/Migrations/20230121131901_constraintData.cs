using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCORE6.CodeFirst.Migrations
{
    public partial class constraintData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPrice",
                table: "Products",
                type: "decimal(9,2)",
                precision: 9,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddCheckConstraint(
                name: "PriceDiscountCheck",
                table: "Products",
                sql: "[Price]>[DiscountPrice]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "PriceDiscountCheck",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                table: "Products");
        }
    }
}
