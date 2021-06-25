using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class addAccRoleId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountRoleId",
                table: "tb_m_accountrole",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountRoleId",
                table: "tb_m_accountrole");
        }
    }
}
