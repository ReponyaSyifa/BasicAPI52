using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class addTablesRelation1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_m_employees",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_employees", x => x.NIK);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_universities",
                columns: table => new
                {
                    UniId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UniName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_universities", x => x.UniId);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_accounts",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_accounts", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_tb_m_accounts_tb_m_employees_NIK",
                        column: x => x.NIK,
                        principalTable: "tb_m_employees",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_educations",
                columns: table => new
                {
                    EducationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniversitiesUniId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_educations", x => x.EducationId);
                    table.ForeignKey(
                        name: "FK_tb_m_educations_tb_m_universities_UniversitiesUniId",
                        column: x => x.UniversitiesUniId,
                        principalTable: "tb_m_universities",
                        principalColumn: "UniId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_profilings",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EducationsEducationId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_profilings", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_tb_m_profilings_tb_m_accounts_NIK",
                        column: x => x.NIK,
                        principalTable: "tb_m_accounts",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_m_profilings_tb_m_educations_EducationsEducationId",
                        column: x => x.EducationsEducationId,
                        principalTable: "tb_m_educations",
                        principalColumn: "EducationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_educations_UniversitiesUniId",
                table: "tb_m_educations",
                column: "UniversitiesUniId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_profilings_EducationsEducationId",
                table: "tb_m_profilings",
                column: "EducationsEducationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_m_profilings");

            migrationBuilder.DropTable(
                name: "tb_m_accounts");

            migrationBuilder.DropTable(
                name: "tb_m_educations");

            migrationBuilder.DropTable(
                name: "tb_m_employees");

            migrationBuilder.DropTable(
                name: "tb_m_universities");
        }
    }
}
