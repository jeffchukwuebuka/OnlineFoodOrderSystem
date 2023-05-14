using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineFoodOrderSystem.Migrations
{
    /// <inheritdoc />
    public partial class completedtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Restaurants_Restaurantid",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "RestaurantsID",
                table: "Menus");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Restaurants",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Restaurantid",
                table: "Menus",
                newName: "RestaurantID");

            migrationBuilder.RenameIndex(
                name: "IX_Menus_Restaurantid",
                table: "Menus",
                newName: "IX_Menus_RestaurantID");

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Menus",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MenuID = table.Column<int>(type: "INTEGER", nullable: false),
                    RestaurantID = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Restaurants_RestaurantID",
                        column: x => x.RestaurantID,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_MenuId",
                table: "Menus",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MenuID",
                table: "Orders",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RestaurantID",
                table: "Orders",
                column: "RestaurantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Menus_MenuId",
                table: "Menus",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Restaurants_RestaurantID",
                table: "Menus",
                column: "RestaurantID",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Menus_MenuId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Restaurants_RestaurantID",
                table: "Menus");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Menus_MenuId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Menus");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Restaurants",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RestaurantID",
                table: "Menus",
                newName: "Restaurantid");

            migrationBuilder.RenameIndex(
                name: "IX_Menus_RestaurantID",
                table: "Menus",
                newName: "IX_Menus_Restaurantid");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantsID",
                table: "Menus",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Restaurants_Restaurantid",
                table: "Menus",
                column: "Restaurantid",
                principalTable: "Restaurants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
