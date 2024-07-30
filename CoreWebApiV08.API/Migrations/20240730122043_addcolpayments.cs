using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreWebApiV08.API.Migrations
{
    /// <inheritdoc />
    public partial class addcolpayments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "annualfees",
                table: "TblPayments",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "computerfees",
                table: "TblPayments",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "miscellaneousfees",
                table: "TblPayments",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "otherfees",
                table: "TblPayments",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "sportsfees",
                table: "TblPayments",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "tiefees",
                table: "TblPayments",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "totalamount",
                table: "TblPayments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "tuitionfees",
                table: "TblPayments",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "annualfees",
                table: "TblPayments");

            migrationBuilder.DropColumn(
                name: "computerfees",
                table: "TblPayments");

            migrationBuilder.DropColumn(
                name: "miscellaneousfees",
                table: "TblPayments");

            migrationBuilder.DropColumn(
                name: "otherfees",
                table: "TblPayments");

            migrationBuilder.DropColumn(
                name: "sportsfees",
                table: "TblPayments");

            migrationBuilder.DropColumn(
                name: "tiefees",
                table: "TblPayments");

            migrationBuilder.DropColumn(
                name: "totalamount",
                table: "TblPayments");

            migrationBuilder.DropColumn(
                name: "tuitionfees",
                table: "TblPayments");
        }
    }
}
