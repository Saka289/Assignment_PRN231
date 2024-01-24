using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryAPI.Migrations
{
    public partial class AddTableToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalFacilities",
                columns: table => new
                {
                    FacilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoDoctor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrivateFacility = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalFacilities", x => x.FacilityId);
                });

            migrationBuilder.CreateTable(
                name: "ServicePriceLists",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServicePrice = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    FacilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePriceLists", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_ServicePriceLists_MedicalFacilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "MedicalFacilities",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServicePriceLists_FacilityId",
                table: "ServicePriceLists",
                column: "FacilityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicePriceLists");

            migrationBuilder.DropTable(
                name: "MedicalFacilities");
        }
    }
}
