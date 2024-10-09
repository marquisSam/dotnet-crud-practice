using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItemsApi.Migrations
{
    /// <inheritdoc />
    public partial class newBagContentAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BagId",
                table: "DndItemsAPI",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DndItemsAPI_BagId",
                table: "DndItemsAPI",
                column: "BagId");

            migrationBuilder.AddForeignKey(
                name: "FK_DndItemsAPI_BagsAPI_BagId",
                table: "DndItemsAPI",
                column: "BagId",
                principalTable: "BagsAPI",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DndItemsAPI_BagsAPI_BagId",
                table: "DndItemsAPI");

            migrationBuilder.DropIndex(
                name: "IX_DndItemsAPI_BagId",
                table: "DndItemsAPI");

            migrationBuilder.DropColumn(
                name: "BagId",
                table: "DndItemsAPI");
        }
    }
}
