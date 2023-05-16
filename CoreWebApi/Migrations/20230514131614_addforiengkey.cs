using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreWebApi.Migrations
{
    public partial class addforiengkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_DeliveryAddressId",
                table: "OrderDetails",
                column: "DeliveryAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_DeliveryAddresses_DeliveryAddressId",
                table: "OrderDetails",
                column: "DeliveryAddressId",
                principalTable: "DeliveryAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_DeliveryAddresses_DeliveryAddressId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_DeliveryAddressId",
                table: "OrderDetails");
        }
    }
}
