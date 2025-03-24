using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIPCommerce.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Actif",
                table: "TableUtilisateur",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnVente",
                table: "TableProduit",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actif",
                table: "TableUtilisateur");

            migrationBuilder.DropColumn(
                name: "EnVente",
                table: "TableProduit");
        }
    }
}
