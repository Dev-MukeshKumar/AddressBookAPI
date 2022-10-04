using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressBookAPI.Migrations
{
    public partial class assetTableFileSizeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "size",
                table: "Assets",
                newName: "Size");

            migrationBuilder.AlterColumn<decimal>(
                name: "Size",
                table: "Assets",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Assets",
                newName: "size");

            migrationBuilder.AlterColumn<int>(
                name: "size",
                table: "Assets",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
