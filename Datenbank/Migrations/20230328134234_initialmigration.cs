using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Datenbank.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ansprechpartner",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Vorname = table.Column<string>(type: "longtext", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    EMail = table.Column<string>(type: "longtext", nullable: false),
                    Telefon = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ansprechpartner", x => x.ID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Kunde",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Betrieb = table.Column<string>(type: "longtext", nullable: false),
                    Straße = table.Column<string>(type: "longtext", nullable: false),
                    Ort = table.Column<string>(type: "longtext", nullable: false),
                    PLZ = table.Column<string>(type: "longtext", nullable: false),
                    AnsprechId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunde", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Kunde_Ansprechpartner_AnsprechId",
                        column: x => x.AnsprechId,
                        principalTable: "Ansprechpartner",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Kunde_AnsprechId",
                table: "Kunde",
                column: "AnsprechId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kunde");

            migrationBuilder.DropTable(
                name: "Ansprechpartner");
        }
    }
}
