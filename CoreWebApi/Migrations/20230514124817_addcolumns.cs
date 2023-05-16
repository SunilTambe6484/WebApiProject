using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreWebApi.Migrations
{
    public partial class addcolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeliveryAddressId",
                table: "OrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_DeliveryAddressId",
                table: "OrderDetails",
                column: "DeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_PaymentMethodId",
                table: "OrderDetails",
                column: "PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_DeliveryAddresses_DeliveryAddressId",
                table: "OrderDetails",
                column: "DeliveryAddressId",
                principalTable: "DeliveryAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_PaymentMethods_PaymentMethodId",
                table: "OrderDetails",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_DeliveryAddresses_DeliveryAddressId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_PaymentMethods_PaymentMethodId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_DeliveryAddressId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_PaymentMethodId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "DeliveryAddressId",
                table: "OrderDetails");
        }
    }
}
