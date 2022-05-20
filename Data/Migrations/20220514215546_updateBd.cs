using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class updateBd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipeMembre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipeMembre",
                columns: table => new
                {
                    EquipesEquipeId = table.Column<int>(type: "int", nullable: false),
                    MembresIdentifiant = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipeMembre", x => new { x.EquipesEquipeId, x.MembresIdentifiant });
                    table.ForeignKey(
                        name: "FK_EquipeMembre_Equipes_EquipesEquipeId",
                        column: x => x.EquipesEquipeId,
                        principalTable: "Equipes",
                        principalColumn: "EquipeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipeMembre_Membres_MembresIdentifiant",
                        column: x => x.MembresIdentifiant,
                        principalTable: "Membres",
                        principalColumn: "Identifiant",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipeMembre_MembresIdentifiant",
                table: "EquipeMembre",
                column: "MembresIdentifiant");
        }
    }
}
