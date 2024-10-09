using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItemsApi.Migrations
{
    /// <inheritdoc />
    public partial class newBagContentAttributeChangeToGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "BagsAPI",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "BagsAPI");

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
    }
}
