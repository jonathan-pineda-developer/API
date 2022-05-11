using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiExamenFinal.Migrations
{
    public partial class escuela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Escuela",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nonbre = table.Column<string>(nullable: true),
                    codigo = table.Column<string>(nullable: true),
                    faculdadId = table.Column<int>(nullable: false),
                    FacultadId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escuela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Escuela_Facultades_FacultadId",
                        column: x => x.FacultadId,
                        principalTable: "Facultades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Escuela_FacultadId",
                table: "Escuela",
                column: "FacultadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Escuela");
        }
    }
}
