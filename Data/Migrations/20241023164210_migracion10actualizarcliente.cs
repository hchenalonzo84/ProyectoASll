using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoASll.Data.Migrations
{
    /// <inheritdoc />
    public partial class migracion10actualizarcliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Clientes",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Clientes");
        }
    }
}
