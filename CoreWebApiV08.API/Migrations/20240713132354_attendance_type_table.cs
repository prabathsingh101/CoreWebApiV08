using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreWebApiV08.API.Migrations
{
    /// <inheritdoc />
    public partial class attendance_type_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblAttendanceType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    attendancedate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    classid = table.Column<int>(type: "int", nullable: true),
                    teacherid = table.Column<int>(type: "int", nullable: true),
                    studentid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAttendanceType", x => x.id);
                    table.ForeignKey(
                        name: "FK_TblAttendanceType_TblClass_classid",
                        column: x => x.classid,
                        principalTable: "TblClass",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TblAttendanceType_TblStudent_studentid",
                        column: x => x.studentid,
                        principalTable: "TblStudent",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TblAttendanceType_TblTeacher_teacherid",
                        column: x => x.teacherid,
                        principalTable: "TblTeacher",
                        principalColumn: "id");
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblAttendanceType");
        }
    }
}
