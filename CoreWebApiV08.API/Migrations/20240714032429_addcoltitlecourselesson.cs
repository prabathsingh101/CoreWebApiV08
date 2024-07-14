using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreWebApiV08.API.Migrations
{
    /// <inheritdoc />
    public partial class addcoltitlecourselesson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "seqNo",
                table: "TblLessions",
                newName: "seqno");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "TblLessions",
                newName: "courseid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TblLessions",
                newName: "id");

            migrationBuilder.AddColumn<DateTime>(
                name: "createddate",
                table: "TblLessions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "TblLessions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updateddate",
                table: "TblLessions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "duration",
                table: "TblCourse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblLessions_courseid",
                table: "TblLessions",
                column: "courseid");

            migrationBuilder.AddForeignKey(
                name: "FK_TblLessions_TblCourse_courseid",
                table: "TblLessions",
                column: "courseid",
                principalTable: "TblCourse",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblLessions_TblCourse_courseid",
                table: "TblLessions");

            migrationBuilder.DropIndex(
                name: "IX_TblLessions_courseid",
                table: "TblLessions");

            migrationBuilder.DropColumn(
                name: "createddate",
                table: "TblLessions");

            migrationBuilder.DropColumn(
                name: "title",
                table: "TblLessions");

            migrationBuilder.DropColumn(
                name: "updateddate",
                table: "TblLessions");

            migrationBuilder.DropColumn(
                name: "duration",
                table: "TblCourse");

            migrationBuilder.RenameColumn(
                name: "seqno",
                table: "TblLessions",
                newName: "seqNo");

            migrationBuilder.RenameColumn(
                name: "courseid",
                table: "TblLessions",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TblLessions",
                newName: "Id");
        }
    }
}
