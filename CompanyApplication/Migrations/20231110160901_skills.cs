using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyApplication.Migrations
{
    /// <inheritdoc />
    public partial class skills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SkillName",
                table: "employees",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "skills",
                columns: table => new
                {
                    SkillName = table.Column<string>(type: "text", nullable: false),
                    SkillDescription = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skills", x => x.SkillName);
                });

            migrationBuilder.CreateTable(
                name: "employeesskills",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    SkillName = table.Column<string>(type: "text", nullable: false),
                    SkillLevel = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeesskills", x => new { x.EmployeeId, x.SkillName });
                    table.ForeignKey(
                        name: "FK_employeesskills_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employeesskills_skills_SkillName",
                        column: x => x.SkillName,
                        principalTable: "skills",
                        principalColumn: "SkillName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "departments",
                columns: new[] { "DepartmentNumber", "Name" },
                values: new object[,]
                {
                    { 1, "Operations" },
                    { 2, "HR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_employees_SkillName",
                table: "employees",
                column: "SkillName");

            migrationBuilder.CreateIndex(
                name: "IX_employeesskills_SkillName",
                table: "employeesskills",
                column: "SkillName");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_skills_SkillName",
                table: "employees",
                column: "SkillName",
                principalTable: "skills",
                principalColumn: "SkillName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_skills_SkillName",
                table: "employees");

            migrationBuilder.DropTable(
                name: "employeesskills");

            migrationBuilder.DropTable(
                name: "skills");

            migrationBuilder.DropIndex(
                name: "IX_employees_SkillName",
                table: "employees");

            migrationBuilder.DeleteData(
                table: "departments",
                keyColumn: "DepartmentNumber",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "departments",
                keyColumn: "DepartmentNumber",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "SkillName",
                table: "employees");
        }
    }
}
