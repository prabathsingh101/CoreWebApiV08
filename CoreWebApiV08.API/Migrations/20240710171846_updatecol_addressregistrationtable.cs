using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreWebApiV08.API.Migrations
{
    /// <inheritdoc />
    public partial class updatecol_addressregistrationtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "classid",
                table: "TblRegistration",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fathersname",
                table: "TblRegistration",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "classid",
                table: "TblRegistration");

            migrationBuilder.DropColumn(
                name: "fathersname",
                table: "TblRegistration");
        }
    }
}
