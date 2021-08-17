using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Book.Migrations
{
    public partial class AddCreationDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "TbItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "TbItems");
        }
    }
}
