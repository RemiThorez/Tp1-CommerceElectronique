using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIPCommerce.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TableProduit_TableUtilisateur_IdVendeur",
                table: "TableProduit");

            migrationBuilder.AddForeignKey(
                name: "FK_TableProduit_TableUtilisateur_IdVendeur",
                table: "TableProduit",
                column: "IdVendeur",
                principalTable: "TableUtilisateur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TableProduit_TableUtilisateur_IdVendeur",
                table: "TableProduit");

            migrationBuilder.AddForeignKey(
                name: "FK_TableProduit_TableUtilisateur_IdVendeur",
                table: "TableProduit",
                column: "IdVendeur",
                principalTable: "TableUtilisateur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
