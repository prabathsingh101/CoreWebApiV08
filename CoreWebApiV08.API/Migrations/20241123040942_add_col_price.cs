using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreWebApiV08.API.Migrations
{
    /// <inheritdoc />
    public partial class add_col_price : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "TblProducts",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "TblProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "TblProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "TblProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "TblProducts");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "TblProducts");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "TblProducts");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TblProducts",
                newName: "name");
        }
    }
}
