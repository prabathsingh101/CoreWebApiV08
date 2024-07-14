using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreWebApiV08.API.Migrations
{
    /// <inheritdoc />
    public partial class add_col_courseid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "courseid",
                table: "TblClass",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblClass_courseid",
                table: "TblClass",
                column: "courseid");

            migrationBuilder.AddForeignKey(
                name: "FK_TblClass_TblCourse_courseid",
                table: "TblClass",
                column: "courseid",
                principalTable: "TblCourse",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblClass_TblCourse_courseid",
                table: "TblClass");

            migrationBuilder.DropIndex(
                name: "IX_TblClass_courseid",
                table: "TblClass");

            migrationBuilder.DropColumn(
                name: "courseid",
                table: "TblClass");
        }
    }
}
