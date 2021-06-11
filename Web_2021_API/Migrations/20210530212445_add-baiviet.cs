using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_2021_API.Migrations
{
    public partial class addbaiviet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "baiViets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gia",
                table: "baiViets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "GioiTinh",
                table: "baiViets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Giong",
                table: "baiViets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoaiSanPham",
                table: "baiViets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MauSac",
                table: "baiViets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SDTLienHe",
                table: "baiViets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ten",
                table: "baiViets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tuoi",
                table: "baiViets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "baiViets");

            migrationBuilder.DropColumn(
                name: "Gia",
                table: "baiViets");

            migrationBuilder.DropColumn(
                name: "GioiTinh",
                table: "baiViets");

            migrationBuilder.DropColumn(
                name: "Giong",
                table: "baiViets");

            migrationBuilder.DropColumn(
                name: "LoaiSanPham",
                table: "baiViets");

            migrationBuilder.DropColumn(
                name: "MauSac",
                table: "baiViets");

            migrationBuilder.DropColumn(
                name: "SDTLienHe",
                table: "baiViets");

            migrationBuilder.DropColumn(
                name: "Ten",
                table: "baiViets");

            migrationBuilder.DropColumn(
                name: "Tuoi",
                table: "baiViets");
        }
    }
}
