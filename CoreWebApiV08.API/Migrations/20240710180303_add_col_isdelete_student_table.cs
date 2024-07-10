using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreWebApiV08.API.Migrations
{
    /// <inheritdoc />
    public partial class add_col_isdelete_student_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "TblStudent",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "TblRegistration",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "TblStudent");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "TblRegistration");
        }
    }
}
