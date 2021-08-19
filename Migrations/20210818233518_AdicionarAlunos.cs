using Microsoft.EntityFrameworkCore.Migrations;

namespace aec_mvc_entity_framework.Migrations
{
    public partial class AdicionarAlunos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "alunos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    matricula = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    notas = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alunos", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alunos");
        }
    }
}
