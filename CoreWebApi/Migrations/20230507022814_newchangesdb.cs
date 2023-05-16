using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreWebApi.Migrations
{
    public partial class newchangesdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeleiveryDetails");

            migrationBuilder.DropTable(
                name: "DelieveryDetailsOrderMappers");

            migrationBuilder.RenameColumn(
                name: "StateId",
                table: "States",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "CityName",
                table: "States",
                newName: "StateName");

            migrationBuilder.RenameColumn(
                name: "DelieveryDetailsOrderMapperId",
                table: "OrderHistories",
                newName: "DeliveryDetailsOrderMapperId");

            migrationBuilder.AddColumn<int>(
                name: "ProductSubTypeId",
                table: "SubTypeProductMappers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductTypeId",
                table: "ProductSubTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DeliveryDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Delivery_Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryDetailsOrderMappers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryDetailsId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    DeliveredDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryDetailsOrderMappers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryDetailsOrderMappers_DeliveryDetails_DeliveryDetailsId",
                        column: x => x.DeliveryDetailsId,
                        principalTable: "DeliveryDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubTypeProductMappers_ProductId",
                table: "SubTypeProductMappers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTypeProductMappers_ProductSubTypeId",
                table: "SubTypeProductMappers",
                column: "ProductSubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryProductMappers_ProductId",
                table: "SubCategoryProductMappers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryProductMappers_SubCategoryId",
                table: "SubCategoryProductMappers",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSubTypes_ProductTypeId",
                table: "ProductSubTypes",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductShops_CityId",
                table: "ProductShops",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductShops_CountryId",
                table: "ProductShops",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductShops_StateId",
                table: "ProductShops",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAvailibilityMappers_ProductId",
                table: "ProductAvailibilityMappers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAvailibilityMappers_ShopId",
                table: "ProductAvailibilityMappers",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistories_DeliveryDetailsOrderMapperId",
                table: "OrderHistories",
                column: "DeliveryDetailsOrderMapperId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistories_OrderId",
                table: "OrderHistories",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_KartDetails_ProductId",
                table: "KartDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CityId",
                table: "Customers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountryId",
                table: "Customers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_StateId",
                table: "Customers",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDetailsOrderMappers_DeliveryDetailsId",
                table: "DeliveryDetailsOrderMappers",
                column: "DeliveryDetailsId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Cities_States_StateId",
            //    table: "Cities",
            //    column: "StateId",
            //    principalTable: "States",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Customers_Cities_CityId",
            //    table: "Customers",
            //    column: "CityId",
            //    principalTable: "Cities",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Customers_Countries_CountryId",
            //    table: "Customers",
            //    column: "CountryId",
            //    principalTable: "Countries",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Customers_States_StateId",
            //    table: "Customers",
            //    column: "StateId",
            //    principalTable: "States",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_KartDetails_Products_ProductId",
            //    table: "KartDetails",
            //    column: "ProductId",
            //    principalTable: "Products",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_OrderDetails_Products_ProductId",
            //    table: "OrderDetails",
            //    column: "ProductId",
            //    principalTable: "Products",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_OrderHistories_DeliveryDetailsOrderMappers_DeliveryDetailsOrderMapperId",
            //    table: "OrderHistories",
            //    column: "DeliveryDetailsOrderMapperId",
            //    principalTable: "DeliveryDetailsOrderMappers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_OrderHistories_OrderDetails_OrderId",
            //    table: "OrderHistories",
            //    column: "OrderId",
            //    principalTable: "OrderDetails",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ProductAvailibilityMappers_Products_ProductId",
            //    table: "ProductAvailibilityMappers",
            //    column: "ProductId",
            //    principalTable: "Products",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ProductAvailibilityMappers_ProductShops_ShopId",
            //    table: "ProductAvailibilityMappers",
            //    column: "ShopId",
            //    principalTable: "ProductShops",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ProductImages_Products_ProductId",
            //    table: "ProductImages",
            //    column: "ProductId",
            //    principalTable: "Products",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ProductShops_Cities_CityId",
            //    table: "ProductShops",
            //    column: "CityId",
            //    principalTable: "Cities",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ProductShops_Countries_CountryId",
            //    table: "ProductShops",
            //    column: "CountryId",
            //    principalTable: "Countries",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ProductShops_States_StateId",
            //    table: "ProductShops",
            //    column: "StateId",
            //    principalTable: "States",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ProductSubTypes_ProductTypes_ProductTypeId",
            //    table: "ProductSubTypes",
            //    column: "ProductTypeId",
            //    principalTable: "ProductTypes",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_States_Countries_CountryId",
            //    table: "States",
            //    column: "CountryId",
            //    principalTable: "Countries",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_SubCategories_Categories_CategoryId",
            //    table: "SubCategories",
            //    column: "CategoryId",
            //    principalTable: "Categories",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_SubCategoryProductMappers_Products_ProductId",
            //    table: "SubCategoryProductMappers",
            //    column: "ProductId",
            //    principalTable: "Products",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_SubCategoryProductMappers_SubCategories_SubCategoryId",
            //    table: "SubCategoryProductMappers",
            //    column: "SubCategoryId",
            //    principalTable: "SubCategories",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_SubTypeProductMappers_Products_ProductId",
            //    table: "SubTypeProductMappers",
            //    column: "ProductId",
            //    principalTable: "Products",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_SubTypeProductMappers_ProductSubTypes_ProductSubTypeId",
            //    table: "SubTypeProductMappers",
            //    column: "ProductSubTypeId",
            //    principalTable: "ProductSubTypes",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Cities_States_StateId",
            //    table: "Cities");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Customers_Cities_CityId",
            //    table: "Customers");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Customers_Countries_CountryId",
            //    table: "Customers");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Customers_States_StateId",
            //    table: "Customers");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_KartDetails_Products_ProductId",
            //    table: "KartDetails");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_OrderDetails_Products_ProductId",
            //    table: "OrderDetails");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_OrderHistories_DeliveryDetailsOrderMappers_DeliveryDetailsOrderMapperId",
            //    table: "OrderHistories");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_OrderHistories_OrderDetails_OrderId",
            //    table: "OrderHistories");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ProductAvailibilityMappers_Products_ProductId",
            //    table: "ProductAvailibilityMappers");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ProductAvailibilityMappers_ProductShops_ShopId",
            //    table: "ProductAvailibilityMappers");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ProductImages_Products_ProductId",
            //    table: "ProductImages");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ProductShops_Cities_CityId",
            //    table: "ProductShops");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ProductShops_Countries_CountryId",
            //    table: "ProductShops");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ProductShops_States_StateId",
            //    table: "ProductShops");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ProductSubTypes_ProductTypes_ProductTypeId",
            //    table: "ProductSubTypes");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_States_Countries_CountryId",
            //    table: "States");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_SubCategories_Categories_CategoryId",
            //    table: "SubCategories");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_SubCategoryProductMappers_Products_ProductId",
            //    table: "SubCategoryProductMappers");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_SubCategoryProductMappers_SubCategories_SubCategoryId",
            //    table: "SubCategoryProductMappers");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_SubTypeProductMappers_Products_ProductId",
            //    table: "SubTypeProductMappers");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_SubTypeProductMappers_ProductSubTypes_ProductSubTypeId",
            //    table: "SubTypeProductMappers");

            migrationBuilder.DropTable(
                name: "DeliveryDetailsOrderMappers");

            migrationBuilder.DropTable(
                name: "DeliveryDetails");

            migrationBuilder.DropIndex(
                name: "IX_SubTypeProductMappers_ProductId",
                table: "SubTypeProductMappers");

            migrationBuilder.DropIndex(
                name: "IX_SubTypeProductMappers_ProductSubTypeId",
                table: "SubTypeProductMappers");

            migrationBuilder.DropIndex(
                name: "IX_SubCategoryProductMappers_ProductId",
                table: "SubCategoryProductMappers");

            migrationBuilder.DropIndex(
                name: "IX_SubCategoryProductMappers_SubCategoryId",
                table: "SubCategoryProductMappers");

            migrationBuilder.DropIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_States_CountryId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_ProductSubTypes_ProductTypeId",
                table: "ProductSubTypes");

            migrationBuilder.DropIndex(
                name: "IX_ProductShops_CityId",
                table: "ProductShops");

            migrationBuilder.DropIndex(
                name: "IX_ProductShops_CountryId",
                table: "ProductShops");

            migrationBuilder.DropIndex(
                name: "IX_ProductShops_StateId",
                table: "ProductShops");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductAvailibilityMappers_ProductId",
                table: "ProductAvailibilityMappers");

            migrationBuilder.DropIndex(
                name: "IX_ProductAvailibilityMappers_ShopId",
                table: "ProductAvailibilityMappers");

            migrationBuilder.DropIndex(
                name: "IX_OrderHistories_DeliveryDetailsOrderMapperId",
                table: "OrderHistories");

            migrationBuilder.DropIndex(
                name: "IX_OrderHistories_OrderId",
                table: "OrderHistories");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_KartDetails_ProductId",
                table: "KartDetails");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CityId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CountryId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_StateId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Cities_StateId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "ProductSubTypeId",
                table: "SubTypeProductMappers");

            migrationBuilder.DropColumn(
                name: "ProductTypeId",
                table: "ProductSubTypes");

            migrationBuilder.RenameColumn(
                name: "StateName",
                table: "States",
                newName: "CityName");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "States",
                newName: "StateId");

            migrationBuilder.RenameColumn(
                name: "DeliveryDetailsOrderMapperId",
                table: "OrderHistories",
                newName: "DelieveryDetailsOrderMapperId");

            migrationBuilder.CreateTable(
                name: "DeleiveryDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleivery_Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeleiveryDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DelieveryDetailsOrderMappers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeleiveredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDetailsId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DelieveryDetailsOrderMappers", x => x.Id);
                });
        }
    }
}
