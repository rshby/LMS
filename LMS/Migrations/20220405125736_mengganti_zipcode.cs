using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Migrations
{
    public partial class mengganti_zipcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "tb_m_district");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "tb_m_subdistrict",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "tb_m_subdistrict");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "tb_m_district",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
