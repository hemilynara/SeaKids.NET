using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeaKids.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CuriosidadeVideo",
                columns: table => new
                {
                    CuriosidadesId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    VideosId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuriosidadeVideo", x => new { x.CuriosidadesId, x.VideosId });
                    table.ForeignKey(
                        name: "FK_CuriosidadeVideo_Curiosidades_CuriosidadesId",
                        column: x => x.CuriosidadesId,
                        principalTable: "Curiosidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuriosidadeVideo_Vídeo_VideosId",
                        column: x => x.VideosId,
                        principalTable: "Vídeo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuriosidadeVideo_VideosId",
                table: "CuriosidadeVideo",
                column: "VideosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuriosidadeVideo");
        }
    }
}
