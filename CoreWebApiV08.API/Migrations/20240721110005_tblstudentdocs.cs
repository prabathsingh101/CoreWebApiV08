using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreWebApiV08.API.Migrations
{
    /// <inheritdoc />
    public partial class tblstudentdocs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblStudentDocs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    filename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    filedescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fileextension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    filesizebytes = table.Column<long>(type: "bigint", nullable: true),
                    filepath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    registrationno = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblStudentDocs", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblStudentDocs");
        }
    }
}
