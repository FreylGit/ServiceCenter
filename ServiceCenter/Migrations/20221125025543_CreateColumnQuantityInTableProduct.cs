using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceCenter.Migrations
{
    /// <inheritdoc />
    public partial class CreateColumnQuantityInTableProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailProduct");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Details_ProductId",
                table: "Details",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Products_ProductId",
                table: "Details",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Details_Products_ProductId",
                table: "Details");

            migrationBuilder.DropIndex(
                name: "IX_Details_ProductId",
                table: "Details");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "DetailProduct",
                columns: table => new
                {
                    DetailsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailProduct", x => new { x.DetailsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_DetailProduct_Details_DetailsId",
                        column: x => x.DetailsId,
                        principalTable: "Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailProduct_ProductsId",
                table: "DetailProduct",
                column: "ProductsId");
        }
    }
}
