using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCORE6.CodeFirst.Migrations
{
    public partial class addCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.EnsureSchema(
                name: "products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "ProductTb",
                newSchema: "products");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                schema: "products",
                table: "ProductTb",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTb",
                schema: "products",
                table: "ProductTb",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTb_CategoryId",
                schema: "products",
                table: "ProductTb",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTb_Category_CategoryId",
                schema: "products",
                table: "ProductTb",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTb_Category_CategoryId",
                schema: "products",
                table: "ProductTb");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTb",
                schema: "products",
                table: "ProductTb");

            migrationBuilder.DropIndex(
                name: "IX_ProductTb_CategoryId",
                schema: "products",
                table: "ProductTb");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "products",
                table: "ProductTb");

            migrationBuilder.RenameTable(
                name: "ProductTb",
                schema: "products",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");
        }
    }
}
