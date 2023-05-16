using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreWebApi.Migrations
{
    public partial class removeforiegnkeyconstraintfromorderhistorytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHistories_DeliveryDetails_DeliveryDetailsId",
                table: "OrderHistories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
