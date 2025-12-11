using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProjeKamp.WebApi.Migrations
{
    public partial class mig8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTasks_Chefs_ChefID",
                table: "EmployeeTasks");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTasks_ChefID",
                table: "EmployeeTasks");

            migrationBuilder.DropColumn(
                name: "ChefID",
                table: "EmployeeTasks");

            migrationBuilder.CreateTable(
                name: "EmployeeTaskChefs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeTaskID = table.Column<int>(type: "int", nullable: false),
                    ChefID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTaskChefs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmployeeTaskChefs_Chefs_ChefID",
                        column: x => x.ChefID,
                        principalTable: "Chefs",
                        principalColumn: "ChefID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTaskChefs_EmployeeTasks_EmployeeTaskID",
                        column: x => x.EmployeeTaskID,
                        principalTable: "EmployeeTasks",
                        principalColumn: "EmployeeTaskID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTaskChefs_ChefID",
                table: "EmployeeTaskChefs",
                column: "ChefID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTaskChefs_EmployeeTaskID",
                table: "EmployeeTaskChefs",
                column: "EmployeeTaskID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTaskChefs");

            migrationBuilder.AddColumn<int>(
                name: "ChefID",
                table: "EmployeeTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTasks_ChefID",
                table: "EmployeeTasks",
                column: "ChefID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTasks_Chefs_ChefID",
                table: "EmployeeTasks",
                column: "ChefID",
                principalTable: "Chefs",
                principalColumn: "ChefID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
