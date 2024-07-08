using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreWebApiV08.API.Migrations
{
    /// <inheritdoc />
    public partial class updateclasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TblClass",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TblClass",
                newName: "description");

            migrationBuilder.AddColumn<string>(
                name: "classname",
                table: "TblClass",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "createddate",
                table: "TblClass",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "studentlimit",
                table: "TblClass",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "teacherid",
                table: "TblClass",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updateddate",
                table: "TblClass",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "classname",
                table: "TblClass");

            migrationBuilder.DropColumn(
                name: "createddate",
                table: "TblClass");

            migrationBuilder.DropColumn(
                name: "studentlimit",
                table: "TblClass");

            migrationBuilder.DropColumn(
                name: "teacherid",
                table: "TblClass");

            migrationBuilder.DropColumn(
                name: "updateddate",
                table: "TblClass");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TblClass",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "TblClass",
                newName: "Name");
        }
    }
}
