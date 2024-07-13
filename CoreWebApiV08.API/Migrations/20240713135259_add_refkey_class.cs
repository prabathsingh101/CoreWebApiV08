using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreWebApiV08.API.Migrations
{
    /// <inheritdoc />
    public partial class add_refkey_class : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TblClass_teacherid",
                table: "TblClass",
                column: "teacherid");

            migrationBuilder.AddForeignKey(
                name: "FK_TblClass_TblTeacher_teacherid",
                table: "TblClass",
                column: "teacherid",
                principalTable: "TblTeacher",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblClass_TblTeacher_teacherid",
                table: "TblClass");

            migrationBuilder.DropIndex(
                name: "IX_TblClass_teacherid",
                table: "TblClass");
        }
    }
}
