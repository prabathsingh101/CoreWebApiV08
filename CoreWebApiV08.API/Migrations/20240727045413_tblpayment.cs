using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreWebApiV08.API.Migrations
{
    /// <inheritdoc />
    public partial class tblpayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblPayments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    collectiondate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    paymenttype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    invoiceno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    admissionfees = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    discountamount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    finalamount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    islocked = table.Column<bool>(type: "bit", nullable: true),
                    isstatus = table.Column<bool>(type: "bit", nullable: true),
                    isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updateddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    studentid = table.Column<int>(type: "int", nullable: true),
                    classid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPayments", x => x.id);
                    table.ForeignKey(
                        name: "FK_TblPayments_TblClass_classid",
                        column: x => x.classid,
                        principalTable: "TblClass",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TblPayments_TblStudent_studentid",
                        column: x => x.studentid,
                        principalTable: "TblStudent",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblPayments_classid",
                table: "TblPayments",
                column: "classid");

            migrationBuilder.CreateIndex(
                name: "IX_TblPayments_studentid",
                table: "TblPayments",
                column: "studentid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblPayments");
        }
    }
}
