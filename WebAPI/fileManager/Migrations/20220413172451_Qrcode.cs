using Microsoft.EntityFrameworkCore.Migrations;
using QRCoder;

namespace fileManager.Migrations
{
    public partial class Qrcode : Migration
    {
        internal static PayloadGenerator.Payload url;

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QRcode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<int>(type: "int", nullable: false),
                    url = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QRcode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QRcode_FileData_Id",
                        column: x => x.Id,
                        principalTable: "FileData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QRcode");
        }
    }
}
