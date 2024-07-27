using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreWebApiV08.API.Migrations
{
    /// <inheritdoc />
    public partial class tblfkpayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TblAttendanceType_classid",
                table: "TblAttendanceType",
                column: "classid");

            migrationBuilder.CreateIndex(
                name: "IX_TblAttendanceType_studentid",
                table: "TblAttendanceType",
                column: "studentid");

            migrationBuilder.CreateIndex(
                name: "IX_TblAttendanceType_teacherid",
                table: "TblAttendanceType",
                column: "teacherid");

            migrationBuilder.AddForeignKey(
                name: "FK_TblAttendanceType_TblClass_classid",
                table: "TblAttendanceType",
                column: "classid",
                principalTable: "TblClass",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblAttendanceType_TblStudent_studentid",
                table: "TblAttendanceType",
                column: "studentid",
                principalTable: "TblStudent",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblAttendanceType_TblTeacher_teacherid",
                table: "TblAttendanceType",
                column: "teacherid",
                principalTable: "TblTeacher",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblAttendanceType_TblClass_classid",
                table: "TblAttendanceType");

            migrationBuilder.DropForeignKey(
                name: "FK_TblAttendanceType_TblStudent_studentid",
                table: "TblAttendanceType");

            migrationBuilder.DropForeignKey(
                name: "FK_TblAttendanceType_TblTeacher_teacherid",
                table: "TblAttendanceType");

            migrationBuilder.DropIndex(
                name: "IX_TblAttendanceType_classid",
                table: "TblAttendanceType");

            migrationBuilder.DropIndex(
                name: "IX_TblAttendanceType_studentid",
                table: "TblAttendanceType");

            migrationBuilder.DropIndex(
                name: "IX_TblAttendanceType_teacherid",
                table: "TblAttendanceType");
        }
    }
}
