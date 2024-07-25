using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreWebApiV08.API.Migrations
{
    /// <inheritdoc />
    public partial class modifytablefeesheadcls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Classesid",
                table: "TblFeesHead",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblFeesHead_Classesid",
                table: "TblFeesHead",
                column: "Classesid");

            migrationBuilder.AddForeignKey(
                name: "FK_TblFeesHead_TblClass_Classesid",
                table: "TblFeesHead",
                column: "Classesid",
                principalTable: "TblClass",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblFeesHead_TblClass_Classesid",
                table: "TblFeesHead");

            migrationBuilder.DropIndex(
                name: "IX_TblFeesHead_Classesid",
                table: "TblFeesHead");

            migrationBuilder.DropColumn(
                name: "Classesid",
                table: "TblFeesHead");
        }
    }
}
