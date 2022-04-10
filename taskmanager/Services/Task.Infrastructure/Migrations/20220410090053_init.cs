using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Task.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Benefits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dependents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeKey = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dependents_Employees_EmployeeKey",
                        column: x => x.EmployeeKey,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeePayrolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeKey = table.Column<int>(type: "int", nullable: false),
                    GrossAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Deduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePayrolls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePayrolls_Employees_EmployeeKey",
                        column: x => x.EmployeeKey,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeBenefits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeKey = table.Column<int>(type: "int", nullable: false),
                    DependentKey = table.Column<int>(type: "int", nullable: false),
                    BenefitKey = table.Column<int>(type: "int", nullable: false),
                    EmployeeCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DependentCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeBenefits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeBenefits_Benefits_BenefitKey",
                        column: x => x.BenefitKey,
                        principalTable: "Benefits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeBenefits_Dependents_DependentKey",
                        column: x => x.DependentKey,
                        principalTable: "Dependents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeBenefits_Employees_EmployeeKey",
                        column: x => x.EmployeeKey,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dependents_EmployeeKey",
                table: "Dependents",
                column: "EmployeeKey");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBenefits_BenefitKey",
                table: "EmployeeBenefits",
                column: "BenefitKey");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBenefits_DependentKey",
                table: "EmployeeBenefits",
                column: "DependentKey");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBenefits_EmployeeKey",
                table: "EmployeeBenefits",
                column: "EmployeeKey");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayrolls_EmployeeKey",
                table: "EmployeePayrolls",
                column: "EmployeeKey",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeBenefits");

            migrationBuilder.DropTable(
                name: "EmployeePayrolls");

            migrationBuilder.DropTable(
                name: "Benefits");

            migrationBuilder.DropTable(
                name: "Dependents");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
