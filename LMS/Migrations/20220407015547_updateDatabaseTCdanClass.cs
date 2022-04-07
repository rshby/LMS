using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Migrations
{
    public partial class updateDatabaseTCdanClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Expired",
                table: "tb_tr_takenclass",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "tb_tr_takenclass",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OrderId",
                table: "tb_tr_takenclass",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UrlPic",
                table: "tb_m_class",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expired",
                table: "tb_tr_takenclass");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "tb_tr_takenclass");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "tb_tr_takenclass");

            migrationBuilder.DropColumn(
                name: "UrlPic",
                table: "tb_m_class");
        }
    }
}
