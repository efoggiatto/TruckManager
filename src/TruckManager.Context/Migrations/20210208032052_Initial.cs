using Microsoft.EntityFrameworkCore.Migrations;

namespace TruckManager.Context.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TruckModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trucks",
                columns: table => new
                {
                    Chassis = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    TruckModelId = table.Column<int>(type: "int", nullable: false),
                    BuildingYear = table.Column<int>(type: "int", nullable: false),
                    ModelYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.Chassis);
                    table.ForeignKey(
                        name: "FK_Trucks_TruckModels_TruckModelId",
                        column: x => x.TruckModelId,
                        principalTable: "TruckModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trucks_TruckModelId",
                table: "Trucks",
                column: "TruckModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trucks");

            migrationBuilder.DropTable(
                name: "TruckModels");
        }
    }
}
