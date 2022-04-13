using Microsoft.EntityFrameworkCore.Migrations;

namespace Task.Infrastructure.Migrations
{
    public partial class updatedep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
