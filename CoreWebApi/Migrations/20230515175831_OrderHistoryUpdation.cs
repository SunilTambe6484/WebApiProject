using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreWebApi.Migrations
{
    public partial class OrderHistoryUpdation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_OrderHistories_DeliveryDetailsOrderMappers_DeliveryDetailsOrderMapperId",
            //    table: "OrderHistories");

            migrationBuilder.RenameColumn(
                name: "DeliveryDetailsOrderMapperId",
                table: "OrderHistories",
                newName: "DeliveryDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderHistories_DeliveryDetailsOrderMapperId",
                table: "OrderHistories",
                newName: "IX_OrderHistories_DeliveryDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHistories_DeliveryDetails_DeliveryDetailsId",
                table: "OrderHistories",
                column: "DeliveryDetailsId",
                principalTable: "DeliveryDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHistories_DeliveryDetails_DeliveryDetailsId",
                table: "OrderHistories");

            migrationBuilder.RenameColumn(
                name: "DeliveryDetailsId",
                table: "OrderHistories",
                newName: "DeliveryDetailsOrderMapperId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderHistories_DeliveryDetailsId",
                table: "OrderHistories",
                newName: "IX_OrderHistories_DeliveryDetailsOrderMapperId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHistories_DeliveryDetailsOrderMappers_DeliveryDetailsOrderMapperId",
                table: "OrderHistories",
                column: "DeliveryDetailsOrderMapperId",
                principalTable: "DeliveryDetailsOrderMappers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
