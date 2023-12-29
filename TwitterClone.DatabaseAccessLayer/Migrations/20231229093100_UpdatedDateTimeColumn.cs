using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitterClone.DatabaseAccessLayer.Migrations
{
    public partial class UpdatedDateTimeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Topics",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 29, 12, 32, 55, 984, DateTimeKind.Local).AddTicks(6723));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Topics",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 29, 12, 32, 55, 984, DateTimeKind.Local).AddTicks(6723),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
