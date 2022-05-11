using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiExamenFinal.Migrations
{
    public partial class carrera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carrera",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true),
                    codigo = table.Column<string>(nullable: true),
                    escuelaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carrera_Escuela_escuelaId",
                        column: x => x.escuelaId,
                        principalTable: "Escuela",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrera_escuelaId",
                table: "Carrera",
                column: "escuelaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carrera");
        }
    }
}
