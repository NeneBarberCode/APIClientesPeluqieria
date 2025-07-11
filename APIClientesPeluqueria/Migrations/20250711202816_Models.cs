using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIClientesPeluqueria.Migrations
{
    /// <inheritdoc />
    public partial class Models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hairCuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hairCuts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "customerHaircuts",
                columns: table => new
                {
                    CurtomerId = table.Column<int>(type: "int", nullable: false),
                    HairCutId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerHaircuts", x => new { x.CurtomerId, x.HairCutId });
                    table.ForeignKey(
                        name: "FK_customerHaircuts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_customerHaircuts_hairCuts_HairCutId",
                        column: x => x.HairCutId,
                        principalTable: "hairCuts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customerHaircuts_CustomerId",
                table: "customerHaircuts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_customerHaircuts_HairCutId",
                table: "customerHaircuts",
                column: "HairCutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customerHaircuts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "hairCuts");
        }
    }
}
