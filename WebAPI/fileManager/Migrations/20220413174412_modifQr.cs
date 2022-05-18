using Microsoft.EntityFrameworkCore.Migrations;

namespace fileManager.Migrations
{
    public partial class modifQr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QRcode_FileData_Id",
                table: "QRcode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QRcode",
                table: "QRcode");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "QRcode",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdQr",
                table: "QRcode",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QRcode",
                table: "QRcode",
                column: "IdQr");

            migrationBuilder.CreateIndex(
                name: "IX_QRcode_Id",
                table: "QRcode",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QRcode_FileData_Id",
                table: "QRcode",
                column: "Id",
                principalTable: "FileData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QRcode_FileData_Id",
                table: "QRcode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QRcode",
                table: "QRcode");

            migrationBuilder.DropIndex(
                name: "IX_QRcode_Id",
                table: "QRcode");

            migrationBuilder.DropColumn(
                name: "IdQr",
                table: "QRcode");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "QRcode",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QRcode",
                table: "QRcode",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QRcode_FileData_Id",
                table: "QRcode",
                column: "Id",
                principalTable: "FileData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
