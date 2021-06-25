using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class deltAccRoleIdasKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountRoleId",
                table: "tb_m_accountrole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountRoleId",
                table: "tb_m_accountrole",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
