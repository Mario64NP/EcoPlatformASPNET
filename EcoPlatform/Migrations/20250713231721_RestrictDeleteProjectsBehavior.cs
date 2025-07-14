using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoPlatform.Migrations
{
    /// <inheritdoc />
    public partial class RestrictDeleteProjectsBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Cities_CityId",
                table: "Projects");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Cities_CityId",
                table: "Projects",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Cities_CityId",
                table: "Projects");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Cities_CityId",
                table: "Projects",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
