using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cabinets",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<int>(type: "int", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cabinets", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sectors",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<int>(type: "int", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sectors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "spexializations",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spexializations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    patronymic = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    sector_id = table.Column<long>(type: "bigint", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.id);
                    table.ForeignKey(
                        name: "FK_patients_sectors_sector_id",
                        column: x => x.sector_id,
                        principalTable: "sectors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fio = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    cabinet_id = table.Column<long>(type: "bigint", nullable: false),
                    specialization_id = table.Column<long>(type: "bigint", nullable: false),
                    sector_id = table.Column<long>(type: "bigint", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.id);
                    table.ForeignKey(
                        name: "FK_doctors_cabinets_cabinet_id",
                        column: x => x.cabinet_id,
                        principalTable: "cabinets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_doctors_sectors_sector_id",
                        column: x => x.sector_id,
                        principalTable: "sectors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_doctors_spexializations_specialization_id",
                        column: x => x.specialization_id,
                        principalTable: "spexializations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_doctors_cabinet_id",
                table: "doctors",
                column: "cabinet_id");

            migrationBuilder.CreateIndex(
                name: "IX_doctors_fio",
                table: "doctors",
                column: "fio",
                unique: true,
                filter: "is_deleted = 1");

            migrationBuilder.CreateIndex(
                name: "IX_doctors_sector_id",
                table: "doctors",
                column: "sector_id");

            migrationBuilder.CreateIndex(
                name: "IX_doctors_specialization_id",
                table: "doctors",
                column: "specialization_id");

            migrationBuilder.CreateIndex(
                name: "IX_patients_first_name_last_name_patronymic_is_deleted",
                table: "patients",
                columns: new[] { "first_name", "last_name", "patronymic", "is_deleted" },
                unique: true,
                filter: "is_deleted = 1");

            migrationBuilder.CreateIndex(
                name: "IX_patients_sector_id",
                table: "patients",
                column: "sector_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "patients");

            migrationBuilder.DropTable(
                name: "cabinets");

            migrationBuilder.DropTable(
                name: "spexializations");

            migrationBuilder.DropTable(
                name: "sectors");
        }
    }
}
