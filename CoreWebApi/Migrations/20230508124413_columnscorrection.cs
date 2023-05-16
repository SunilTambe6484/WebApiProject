using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreWebApi.Migrations
{
    public partial class columnscorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "AddressTypes");

            migrationBuilder.RenameColumn(
                name: "ShippingAdress",
                table: "DeliveryAddresses",
                newName: "ShippingAddress");

            migrationBuilder.RenameColumn(
                name: "PermenentAdress",
                table: "DeliveryAddresses",
                newName: "PermanentAddress");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "DeliveryAddresses",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "DeliveryAddresses");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress",
                table: "DeliveryAddresses",
                newName: "ShippingAdress");

            migrationBuilder.RenameColumn(
                name: "PermanentAddress",
                table: "DeliveryAddresses",
                newName: "PermenentAdress");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "AddressTypes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
