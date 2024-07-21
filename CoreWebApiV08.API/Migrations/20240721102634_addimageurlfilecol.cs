using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreWebApiV08.API.Migrations
{
    /// <inheritdoc />
    public partial class addimageurlfilecol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "imageurl",
                table: "TblStudent",
                newName: "FilePath");

            migrationBuilder.AddColumn<string>(
                name: "FileDescription",
                table: "TblStudent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileExtension",
                table: "TblStudent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "TblStudent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FileSizeBytes",
                table: "TblStudent",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileDescription",
                table: "TblStudent");

            migrationBuilder.DropColumn(
                name: "FileExtension",
                table: "TblStudent");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "TblStudent");

            migrationBuilder.DropColumn(
                name: "FileSizeBytes",
                table: "TblStudent");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "TblStudent",
                newName: "imageurl");
        }
    }
}
