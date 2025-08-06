using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProjeKamp.WebApi.Migrations
{
    public partial class AddEmailFieldMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Messages");
        }
    }
}
