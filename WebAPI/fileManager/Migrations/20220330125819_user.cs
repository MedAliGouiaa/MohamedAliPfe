using Microsoft.EntityFrameworkCore.Migrations;

namespace fileManager.Migrations
{
    public partial class user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utilisateur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Motpasse = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    role = table.Column<string>(type: "nvarchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateur", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Utilisateur");
        }
    }
}
