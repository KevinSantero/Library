using Microsoft.EntityFrameworkCore.Migrations;

namespace TecnicalTestPersonas.Data.Migrations
{
    public partial class Initialdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Terceros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Documento = table.Column<string>(maxLength: 15, nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(maxLength: 100, nullable: false),
                    CorreoElectronico1 = table.Column<string>(maxLength: 100, nullable: true),
                    CorreoElectronico2 = table.Column<string>(maxLength: 100, nullable: true),
                    Tel1 = table.Column<string>(maxLength: 15, nullable: true),
                    Tel2 = table.Column<string>(maxLength: 15, nullable: true),
                    Direccion1 = table.Column<string>(maxLength: 500, nullable: true),
                    Direccion2 = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terceros", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Terceros");
        }
    }
}
