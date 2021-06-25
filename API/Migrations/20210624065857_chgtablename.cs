using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class chgtablename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountRole_Roles_RolesId",
                table: "AccountRole");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountRole_tb_m_accounts_AccountsId",
                table: "AccountRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountRole",
                table: "AccountRole");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "tb_m_roles");

            migrationBuilder.RenameTable(
                name: "AccountRole",
                newName: "tb_m_accountrole");

            migrationBuilder.RenameIndex(
                name: "IX_AccountRole_RolesId",
                table: "tb_m_accountrole",
                newName: "IX_tb_m_accountrole_RolesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_roles",
                table: "tb_m_roles",
                column: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_accountrole",
                table: "tb_m_accountrole",
                columns: new[] { "AccountsId", "RolesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_accountrole_tb_m_accounts_AccountsId",
                table: "tb_m_accountrole",
                column: "AccountsId",
                principalTable: "tb_m_accounts",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_accountrole_tb_m_roles_RolesId",
                table: "tb_m_accountrole",
                column: "RolesId",
                principalTable: "tb_m_roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_accountrole_tb_m_accounts_AccountsId",
                table: "tb_m_accountrole");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_accountrole_tb_m_roles_RolesId",
                table: "tb_m_accountrole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_roles",
                table: "tb_m_roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_accountrole",
                table: "tb_m_accountrole");

            migrationBuilder.RenameTable(
                name: "tb_m_roles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "tb_m_accountrole",
                newName: "AccountRole");

            migrationBuilder.RenameIndex(
                name: "IX_tb_m_accountrole_RolesId",
                table: "AccountRole",
                newName: "IX_AccountRole_RolesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountRole",
                table: "AccountRole",
                columns: new[] { "AccountsId", "RolesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRole_Roles_RolesId",
                table: "AccountRole",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRole_tb_m_accounts_AccountsId",
                table: "AccountRole",
                column: "AccountsId",
                principalTable: "tb_m_accounts",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
