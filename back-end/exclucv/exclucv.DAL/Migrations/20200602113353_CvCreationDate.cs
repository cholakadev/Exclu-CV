using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace exclucv.DAL.Migrations
{
    public partial class CvCreationDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateOfCreation",
                table: "CVs",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfCreation",
                table: "CVs",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
