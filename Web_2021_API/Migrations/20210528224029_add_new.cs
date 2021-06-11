using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_2021_API.Migrations
{
    public partial class add_new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "quyens",
                columns: table => new
                {
                    QuyenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten_Quyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Txt_Quyen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quyens", x => x.QuyenId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuyenId = table.Column<int>(type: "int", nullable: false),
                    TenDangNhap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoLanDangNhapFail = table.Column<int>(type: "int", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path_img = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_users_quyens_QuyenId",
                        column: x => x.QuyenId,
                        principalTable: "quyens",
                        principalColumn: "QuyenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "baiViets",
                columns: table => new
                {
                    BaiVietId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayDang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Path_Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuyenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_baiViets", x => x.BaiVietId);
                    table.ForeignKey(
                        name: "FK_baiViets_quyens_QuyenId",
                        column: x => x.QuyenId,
                        principalTable: "quyens",
                        principalColumn: "QuyenId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_baiViets_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_baiViets_QuyenId",
                table: "baiViets",
                column: "QuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_baiViets_UserId",
                table: "baiViets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_users_QuyenId",
                table: "users",
                column: "QuyenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "baiViets");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "quyens");
        }
    }
}
