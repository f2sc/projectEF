using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UrlArchivo",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1500)",
                oldMaxLength: 1500);

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaID", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("d24f36a0-89e7-4e99-ac6f-8f7818716939"), "Las actividades que están todavía pendientes de hacer.", "Actividades pendientes", 20 },
                    { new Guid("d24f36a0-89e7-4e99-ac6f-8f7818716940"), "Las actividades que se tienen que hacer personalmente.", "Actividades personales", 50 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo", "UrlArchivo" },
                values: new object[,]
                {
                    { new Guid("b83f34bf-af22-493a-bd0e-415788ce4163"), new Guid("d24f36a0-89e7-4e99-ac6f-8f7818716939"), "Hay que hacer la compra en el mercadona.", new DateTime(2024, 6, 14, 11, 20, 58, 108, DateTimeKind.Local).AddTicks(8203), 1, "Hacer la compra", "https://cdn.businessinsider.es/sites/navi.axelspringer.es/public/media/image/2022/11/mujer-mirando-lista-compra-2880589.jpg?tf=3840x" },
                    { new Guid("b83f34bf-af22-493a-bd0e-415788ce4174"), new Guid("d24f36a0-89e7-4e99-ac6f-8f7818716940"), "Salir a correr 15 minutos o correr en la cinta.", new DateTime(2024, 6, 14, 11, 20, 58, 108, DateTimeKind.Local).AddTicks(8254), 2, "Hacer deporte", "https://media.revistagq.com/photos/641c645781245672268fff7a/16:9/w_2560%2Cc_limit/1036780592" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("b83f34bf-af22-493a-bd0e-415788ce4163"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("b83f34bf-af22-493a-bd0e-415788ce4174"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaID",
                keyValue: new Guid("d24f36a0-89e7-4e99-ac6f-8f7818716939"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaID",
                keyValue: new Guid("d24f36a0-89e7-4e99-ac6f-8f7818716940"));

            migrationBuilder.AlterColumn<string>(
                name: "UrlArchivo",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1500)",
                oldMaxLength: 1500,
                oldNullable: true);
        }
    }
}
