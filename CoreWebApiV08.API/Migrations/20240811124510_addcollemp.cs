using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreWebApiV08.API.Migrations
{
    /// <inheritdoc />
    public partial class addcollemp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "TblEmployee",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "TblEmployee",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "FileExtension",
                table: "TblEmployee",
                newName: "fullname");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "TblEmployee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "TblEmployee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "employeeimage",
                table: "TblEmployee",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "TblEmployee");

            migrationBuilder.DropColumn(
                name: "email",
                table: "TblEmployee");

            migrationBuilder.DropColumn(
                name: "employeeimage",
                table: "TblEmployee");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "TblEmployee",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "TblEmployee",
                newName: "FileName");

            migrationBuilder.RenameColumn(
                name: "fullname",
                table: "TblEmployee",
                newName: "FileExtension");
        }
    }
}
