using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class changeAtributGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "gender",
                table: "tb_m_employees",
                newName: "Gender");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "tb_m_employees",
                newName: "gender");
        }
    }
}
