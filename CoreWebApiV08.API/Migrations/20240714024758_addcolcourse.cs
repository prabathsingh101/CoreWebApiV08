using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreWebApiV08.API.Migrations
{
    /// <inheritdoc />
    public partial class addcolcourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "seqNo",
                table: "TblCourse",
                newName: "seqno");

            migrationBuilder.RenameColumn(
                name: "longDescription",
                table: "TblCourse",
                newName: "longdescription");

            migrationBuilder.RenameColumn(
                name: "lessonsCount",
                table: "TblCourse",
                newName: "lessonscount");

            migrationBuilder.RenameColumn(
                name: "iconUrl",
                table: "TblCourse",
                newName: "iconurl");

            migrationBuilder.RenameColumn(
                name: "courseListIcon",
                table: "TblCourse",
                newName: "courselisticon");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TblCourse",
                newName: "id");

            migrationBuilder.AddColumn<DateTime>(
                name: "createddate",
                table: "TblCourse",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updateddate",
                table: "TblCourse",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createddate",
                table: "TblCourse");

            migrationBuilder.DropColumn(
                name: "updateddate",
                table: "TblCourse");

            migrationBuilder.RenameColumn(
                name: "seqno",
                table: "TblCourse",
                newName: "seqNo");

            migrationBuilder.RenameColumn(
                name: "longdescription",
                table: "TblCourse",
                newName: "longDescription");

            migrationBuilder.RenameColumn(
                name: "lessonscount",
                table: "TblCourse",
                newName: "lessonsCount");

            migrationBuilder.RenameColumn(
                name: "iconurl",
                table: "TblCourse",
                newName: "iconUrl");

            migrationBuilder.RenameColumn(
                name: "courselisticon",
                table: "TblCourse",
                newName: "courseListIcon");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TblCourse",
                newName: "Id");
        }
    }
}
