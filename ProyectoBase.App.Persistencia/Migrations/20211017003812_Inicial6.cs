using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoBase.App.Persistencia.Migrations
{
    public partial class Inicial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aspirante",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    edad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profesion = table.Column<int>(type: "int", nullable: false),
                    estadocivil = table.Column<int>(type: "int", nullable: false),
                    ciudad = table.Column<int>(type: "int", nullable: false),
                    genero = table.Column<int>(type: "int", nullable: false),
                    agencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aspirante", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aspirante");
        }
    }
}
