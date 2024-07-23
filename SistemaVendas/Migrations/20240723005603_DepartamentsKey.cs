using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaVendas.Migrations
{
    /// <inheritdoc />
    public partial class DepartamentsKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartamenttId",
                table: "Sellers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartamenttId",
                table: "Sellers");
        }
    }
}
