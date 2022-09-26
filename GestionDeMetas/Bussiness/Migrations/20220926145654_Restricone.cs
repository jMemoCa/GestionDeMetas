using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionDeMetas.Bussiness.Migrations
{
    public partial class Restricone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Meta",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Actividad",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Meta_Nombre",
                table: "Meta",
                column: "Nombre",
                unique: true,
                filter: "[Nombre] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Actividad_Nombre",
                table: "Actividad",
                column: "Nombre",
                unique: true,
                filter: "[Nombre] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Meta_Nombre",
                table: "Meta");

            migrationBuilder.DropIndex(
                name: "IX_Actividad_Nombre",
                table: "Actividad");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Meta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Actividad",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
