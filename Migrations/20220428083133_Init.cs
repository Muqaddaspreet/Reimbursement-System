using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MainProject.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReimbursementDatas",
                columns: table => new
                {
                    ReimbursementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReimbursementType = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    RequestedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    RequestedValue = table.Column<int>(type: "int", nullable: false),
                    ApprovedValue = table.Column<int>(type: "int", nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    ReceiptAttached = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    ReceiptImageLink = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    RequestedPhase = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    InternalNotes = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReimbursementDatas", x => x.ReimbursementID);
                });

            migrationBuilder.CreateTable(
                name: "SignUps",
                columns: table => new
                {
                    SignUpID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    PanNumber = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Bank = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(12)", nullable: false),
                    IsApprover = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignUps", x => x.SignUpID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReimbursementDatas");

            migrationBuilder.DropTable(
                name: "SignUps");
        }
    }
}
