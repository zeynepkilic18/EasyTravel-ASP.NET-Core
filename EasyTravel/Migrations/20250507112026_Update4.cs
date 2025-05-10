using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTravel.Migrations
{
    /// <inheritdoc />
    public partial class Update4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TravelRoutes",
                newName: "RouteName");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "TravelRoutes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TravelId",
                table: "TravelRoutes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TravelRoutes_TravelId",
                table: "TravelRoutes",
                column: "TravelId");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelRoutes_Travels_TravelId",
                table: "TravelRoutes",
                column: "TravelId",
                principalTable: "Travels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelRoutes_Travels_TravelId",
                table: "TravelRoutes");

            migrationBuilder.DropIndex(
                name: "IX_TravelRoutes_TravelId",
                table: "TravelRoutes");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "TravelRoutes");

            migrationBuilder.DropColumn(
                name: "TravelId",
                table: "TravelRoutes");

            migrationBuilder.RenameColumn(
                name: "RouteName",
                table: "TravelRoutes",
                newName: "Name");
        }
    }
}
