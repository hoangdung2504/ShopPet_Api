﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using web_2021_API;

namespace Web_2021_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210528224029_add_new")]
    partial class add_new
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Web_2021_API.Entities.BaiViet", b =>
                {
                    b.Property<int>("BaiVietId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("NgayDang")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path_Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QuyenId")
                        .HasColumnType("int");

                    b.Property<string>("TieuDe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BaiVietId");

                    b.HasIndex("QuyenId");

                    b.HasIndex("UserId");

                    b.ToTable("baiViets");
                });

            modelBuilder.Entity("Web_2021_API.Entities.Quyen", b =>
                {
                    b.Property<int>("QuyenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ten_Quyen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Txt_Quyen")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuyenId");

                    b.ToTable("quyens");
                });

            modelBuilder.Entity("Web_2021_API.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Path_img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuyenId")
                        .HasColumnType("int");

                    b.Property<string>("SDT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoLanDangNhapFail")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenDangNhap")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("QuyenId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Web_2021_API.Entities.BaiViet", b =>
                {
                    b.HasOne("Web_2021_API.Entities.Quyen", null)
                        .WithMany("BaiViet")
                        .HasForeignKey("QuyenId");

                    b.HasOne("Web_2021_API.Entities.User", "User")
                        .WithMany("BaiViet")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Web_2021_API.Entities.User", b =>
                {
                    b.HasOne("Web_2021_API.Entities.Quyen", "Quyen")
                        .WithMany()
                        .HasForeignKey("QuyenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quyen");
                });

            modelBuilder.Entity("Web_2021_API.Entities.Quyen", b =>
                {
                    b.Navigation("BaiViet");
                });

            modelBuilder.Entity("Web_2021_API.Entities.User", b =>
                {
                    b.Navigation("BaiViet");
                });
#pragma warning restore 612, 618
        }
    }
}
