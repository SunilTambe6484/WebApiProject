using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreWebApi.Migrations
{
    public partial class createproducttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ProductAvailibilityMappers_Products_ProductId",
            //    table: "ProductAvailibilityMappers");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ProductImages_Products_ProductId",
            //    table: "ProductImages");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_SubCategoryProductMappers_Products_ProductId",
            //    table: "SubCategoryProductMappers");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_SubTypeProductMappers_Products_ProductId",
            //    table: "SubTypeProductMappers");

            //migrationBuilder.AddColumn<int>(
            //    name: "OrderDetailsId",
            //    table: "DeliveryDetailsOrderMappers",
            //    type: "int",
            //    nullable: true);

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MRP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_DeliveryDetailsOrderMappers_OrderDetailsId",
            //    table: "DeliveryDetailsOrderMappers",
            //    column: "OrderDetailsId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_DeliveryDetailsOrderMappers_OrderDetails_OrderDetailsId",
            //    table: "DeliveryDetailsOrderMappers",
            //    column: "OrderDetailsId",
            //    principalTable: "OrderDetails",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAvailibilityMappers_Product_ProductId",
                table: "ProductAvailibilityMappers",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Product_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoryProductMappers_Product_ProductId",
                table: "SubCategoryProductMappers",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubTypeProductMappers_Product_ProductId",
                table: "SubTypeProductMappers",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryDetailsOrderMappers_OrderDetails_OrderDetailsId",
                table: "DeliveryDetailsOrderMappers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAvailibilityMappers_Product_ProductId",
                table: "ProductAvailibilityMappers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Product_ProductId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoryProductMappers_Product_ProductId",
                table: "SubCategoryProductMappers");

            migrationBuilder.DropForeignKey(
                name: "FK_SubTypeProductMappers_Product_ProductId",
                table: "SubTypeProductMappers");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryDetailsOrderMappers_OrderDetailsId",
                table: "DeliveryDetailsOrderMappers");

            migrationBuilder.DropColumn(
                name: "OrderDetailsId",
                table: "DeliveryDetailsOrderMappers");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAvailibilityMappers_Products_ProductId",
                table: "ProductAvailibilityMappers",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoryProductMappers_Products_ProductId",
                table: "SubCategoryProductMappers",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubTypeProductMappers_Products_ProductId",
                table: "SubTypeProductMappers",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
