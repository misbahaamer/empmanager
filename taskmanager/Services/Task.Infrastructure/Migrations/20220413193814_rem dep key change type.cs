using Microsoft.EntityFrameworkCore.Migrations;

namespace Task.Infrastructure.Migrations
{
    public partial class remdepkeychangetype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeBenefits_Dependents_DependentKey",
                table: "EmployeeBenefits");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeBenefits_DependentKey",
                table: "EmployeeBenefits");

            migrationBuilder.DropColumn(
                name: "DependentKey",
                table: "EmployeeBenefits");

            migrationBuilder.AlterColumn<double>(
                name: "TotalCost",
                table: "EmployeeBenefits",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "EmployeeCost",
                table: "EmployeeBenefits",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "DependentCost",
                table: "EmployeeBenefits",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "DependentId",
                table: "EmployeeBenefits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBenefits_DependentId",
                table: "EmployeeBenefits",
                column: "DependentId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeBenefits_Dependents_DependentId",
                table: "EmployeeBenefits",
                column: "DependentId",
                principalTable: "Dependents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeBenefits_Dependents_DependentId",
                table: "EmployeeBenefits");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeBenefits_DependentId",
                table: "EmployeeBenefits");

            migrationBuilder.DropColumn(
                name: "DependentId",
                table: "EmployeeBenefits");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCost",
                table: "EmployeeBenefits",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "EmployeeCost",
                table: "EmployeeBenefits",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "DependentCost",
                table: "EmployeeBenefits",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "DependentKey",
                table: "EmployeeBenefits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBenefits_DependentKey",
                table: "EmployeeBenefits",
                column: "DependentKey");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeBenefits_Dependents_DependentKey",
                table: "EmployeeBenefits",
                column: "DependentKey",
                principalTable: "Dependents",
                principalColumn: "Id");
        }
    }
}
