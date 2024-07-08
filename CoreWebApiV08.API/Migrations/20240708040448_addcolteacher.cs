using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreWebApiV08.API.Migrations
{
    /// <inheritdoc />
    public partial class addcolteacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Proficiency",
                table: "TblTeacher",
                newName: "proficiency");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "TblTeacher",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TblTeacher",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "ModfiedDate",
                table: "TblTeacher",
                newName: "modfieddate");

            migrationBuilder.RenameColumn(
                name: "Degree",
                table: "TblTeacher",
                newName: "degree");

            migrationBuilder.RenameColumn(
                name: "DateofJoining",
                table: "TblTeacher",
                newName: "dateofjoining");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "TblTeacher",
                newName: "createddate");

            migrationBuilder.RenameColumn(
                name: "ContactNo",
                table: "TblTeacher",
                newName: "contactno");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "TblTeacher",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TblTeacher",
                newName: "id");

            migrationBuilder.AddColumn<string>(
                name: "pincode",
                table: "TblTeacher",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pincode",
                table: "TblTeacher");

            migrationBuilder.RenameColumn(
                name: "proficiency",
                table: "TblTeacher",
                newName: "Proficiency");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "TblTeacher",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "TblTeacher",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "modfieddate",
                table: "TblTeacher",
                newName: "ModfiedDate");

            migrationBuilder.RenameColumn(
                name: "degree",
                table: "TblTeacher",
                newName: "Degree");

            migrationBuilder.RenameColumn(
                name: "dateofjoining",
                table: "TblTeacher",
                newName: "DateofJoining");

            migrationBuilder.RenameColumn(
                name: "createddate",
                table: "TblTeacher",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "contactno",
                table: "TblTeacher",
                newName: "ContactNo");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "TblTeacher",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TblTeacher",
                newName: "Id");
        }
    }
}
