using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreWebApiV08.API.Migrations
{
    /// <inheritdoc />
    public partial class addnewcolssws : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "attendancetype",
                table: "TblAttendanceType",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "attendancedate",
                table: "TblAttendanceType",
                newName: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type",
                table: "TblAttendanceType",
                newName: "attendancetype");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "TblAttendanceType",
                newName: "attendancedate");
        }
    }
}
