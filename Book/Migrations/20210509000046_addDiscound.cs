using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Book.Migrations
{
    public partial class addDiscound : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbDiscound",
                columns: table => new
                {
                    ItemDescountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    DiscountValue = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbDiscound", x => x.ItemDescountId);
                    table.ForeignKey(
                        name: "FK_TbDiscound_TbItems",
                        column: x => x.ItemId,
                        principalTable: "TbItems",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbDiscound_ItemId",
                table: "TbDiscound",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbDiscound");
        }
    }
}
