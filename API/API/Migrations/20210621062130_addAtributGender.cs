using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class addAtributGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "gender",
                table: "tb_m_employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "gender",
                table: "tb_m_employees");
        }
    }
}
