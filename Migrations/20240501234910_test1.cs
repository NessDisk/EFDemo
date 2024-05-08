using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDemo.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("fe2de405-c38e-4c90-ac52-da0540dfb410"),
                column: "FechaCreacion",
                value: new DateTime(2024, 5, 1, 18, 49, 9, 794, DateTimeKind.Local).AddTicks(6757));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("fe2de405-c38e-4c90-ac53-da0540dfb411"),
                column: "FechaCreacion",
                value: new DateTime(2024, 5, 1, 18, 49, 9, 794, DateTimeKind.Local).AddTicks(6773));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("fe2de405-c38e-4c90-ac52-da0540dfb410"),
                column: "FechaCreacion",
                value: new DateTime(2024, 5, 1, 18, 46, 48, 231, DateTimeKind.Local).AddTicks(6846));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("fe2de405-c38e-4c90-ac53-da0540dfb411"),
                column: "FechaCreacion",
                value: new DateTime(2024, 5, 1, 18, 46, 48, 231, DateTimeKind.Local).AddTicks(6860));
        }
    }
}
