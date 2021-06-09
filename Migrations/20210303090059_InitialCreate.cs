using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Economat_v2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Angajati",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume_Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIM = table.Column<int>(type: "int", nullable: false),
                    CNP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sold = table.Column<int>(type: "int", nullable: false),
                    Restanta_Totala = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Angajati", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companii",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<int>(type: "int", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companii", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Numar_Facturi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Serie = table.Column<int>(type: "int", nullable: false),
                    Numar_Inceput = table.Column<int>(type: "int", nullable: false),
                    Numar_Sfarsit = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Numar_Curent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Numar_Facturi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stoc = table.Column<int>(type: "int", nullable: false),
                    Pret_Unitate = table.Column<int>(type: "int", nullable: false),
                    Categorie = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facturi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CIM_Angajat = table.Column<int>(type: "int", nullable: false),
                    Nume_Angajat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Serie = table.Column<int>(type: "int", nullable: false),
                    Numar_Document = table.Column<int>(type: "int", nullable: false),
                    Tip_Document = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suma_Totala = table.Column<int>(type: "int", nullable: false),
                    Suma_Platita = table.Column<int>(type: "int", nullable: false),
                    Restanta = table.Column<int>(type: "int", nullable: false),
                    AngajatId = table.Column<int>(type: "int", nullable: false),
                    CompanieId = table.Column<int>(type: "int", nullable: false),
                    Numar_FacturaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facturi_Angajati_AngajatId",
                        column: x => x.AngajatId,
                        principalTable: "Angajati",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Facturi_Companii_CompanieId",
                        column: x => x.CompanieId,
                        principalTable: "Companii",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Facturi_Numar_Facturi_Numar_FacturaId",
                        column: x => x.Numar_FacturaId,
                        principalTable: "Numar_Facturi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Detalii",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume_Produs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cantitate_Produs = table.Column<int>(type: "int", nullable: false),
                    Pret = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FacturaId = table.Column<int>(type: "int", nullable: false),
                    ProdusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalii", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detalii_Facturi_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Facturi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Detalii_Produse_ProdusId",
                        column: x => x.ProdusId,
                        principalTable: "Produse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalii_FacturaId",
                table: "Detalii",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Detalii_ProdusId",
                table: "Detalii",
                column: "ProdusId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturi_AngajatId",
                table: "Facturi",
                column: "AngajatId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturi_CompanieId",
                table: "Facturi",
                column: "CompanieId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facturi_Numar_FacturaId",
                table: "Facturi",
                column: "Numar_FacturaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalii");

            migrationBuilder.DropTable(
                name: "Facturi");

            migrationBuilder.DropTable(
                name: "Produse");

            migrationBuilder.DropTable(
                name: "Angajati");

            migrationBuilder.DropTable(
                name: "Companii");

            migrationBuilder.DropTable(
                name: "Numar_Facturi");
        }
    }
}
