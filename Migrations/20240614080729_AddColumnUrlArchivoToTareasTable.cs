using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectEF.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnUrlArchivoToTareasTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlArchivo",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlArchivo",
                table: "Tarea");
        }
    }
}
