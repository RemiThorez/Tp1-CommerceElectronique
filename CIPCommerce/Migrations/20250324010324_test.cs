using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIPCommerce.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TableUtilisateur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identifiant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mdp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableUtilisateur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TableFacture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAcheteur = table.Column<int>(type: "int", nullable: false),
                    DateAchat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableFacture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableFacture_TableUtilisateur_IdAcheteur",
                        column: x => x.IdAcheteur,
                        principalTable: "TableUtilisateur",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TableProduit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prix = table.Column<double>(type: "float", nullable: false),
                    Categorie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdVendeur = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableProduit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableProduit_TableUtilisateur_IdVendeur",
                        column: x => x.IdVendeur,
                        principalTable: "TableUtilisateur",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TableFactureProduits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFacture = table.Column<int>(type: "int", nullable: false),
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    Qte = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableFactureProduits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableFactureProduits_TableFacture_IdFacture",
                        column: x => x.IdFacture,
                        principalTable: "TableFacture",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TableFactureProduits_TableProduit_IdProduit",
                        column: x => x.IdProduit,
                        principalTable: "TableProduit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TablePanier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAcheteur = table.Column<int>(type: "int", nullable: false),
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    Qte = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablePanier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TablePanier_TableProduit_IdProduit",
                        column: x => x.IdProduit,
                        principalTable: "TableProduit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TablePanier_TableUtilisateur_IdAcheteur",
                        column: x => x.IdAcheteur,
                        principalTable: "TableUtilisateur",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TableFacture_IdAcheteur",
                table: "TableFacture",
                column: "IdAcheteur");

            migrationBuilder.CreateIndex(
                name: "IX_TableFactureProduits_IdFacture",
                table: "TableFactureProduits",
                column: "IdFacture");

            migrationBuilder.CreateIndex(
                name: "IX_TableFactureProduits_IdProduit",
                table: "TableFactureProduits",
                column: "IdProduit");

            migrationBuilder.CreateIndex(
                name: "IX_TablePanier_IdAcheteur",
                table: "TablePanier",
                column: "IdAcheteur");

            migrationBuilder.CreateIndex(
                name: "IX_TablePanier_IdProduit",
                table: "TablePanier",
                column: "IdProduit");

            migrationBuilder.CreateIndex(
                name: "IX_TableProduit_IdVendeur",
                table: "TableProduit",
                column: "IdVendeur");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableFactureProduits");

            migrationBuilder.DropTable(
                name: "TablePanier");

            migrationBuilder.DropTable(
                name: "TableFacture");

            migrationBuilder.DropTable(
                name: "TableProduit");

            migrationBuilder.DropTable(
                name: "TableUtilisateur");
        }
    }
}
