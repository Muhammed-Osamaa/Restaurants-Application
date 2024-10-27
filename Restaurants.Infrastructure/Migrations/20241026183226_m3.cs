using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurants.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Restaurants_RestaurantsId",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "RestaurantsId",
                table: "Dishes",
                newName: "RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_Dishes_RestaurantsId",
                table: "Dishes",
                newName: "IX_Dishes_RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Restaurants_RestaurantId",
                table: "Dishes",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Restaurants_RestaurantId",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "Dishes",
                newName: "RestaurantsId");

            migrationBuilder.RenameIndex(
                name: "IX_Dishes_RestaurantId",
                table: "Dishes",
                newName: "IX_Dishes_RestaurantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Restaurants_RestaurantsId",
                table: "Dishes",
                column: "RestaurantsId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
