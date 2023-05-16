using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreWebApi.Migrations
{
    public partial class columnnamechangesofdelivery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDelieveryFree",
                table: "ProductDeliveryExpectations",
                newName: "IsDeliveryFree");

            migrationBuilder.RenameColumn(
                name: "DeliveryExpectationDate",
                table: "ProductDeliveryExpectations",
                newName: "DeliveryExpectatedDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeliveryFree",
                table: "ProductDeliveryExpectations",
                newName: "IsDelieveryFree");

            migrationBuilder.RenameColumn(
                name: "DeliveryExpectatedDate",
                table: "ProductDeliveryExpectations",
                newName: "DeliveryExpectationDate");
        }
    }
}
