﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nguyen_Duong_The_Vi.Data;

#nullable disable

namespace Nguyen_Duong_The_Vi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240213101023_dsgs")]
    partial class dsgs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Nguyen_Duong_The_Vi.Models.Category", b =>
                {
                    b.Property<int>("IDCATEGORY")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDCATEGORY"), 1L, 1);

                    b.Property<string>("CONTEXT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TITLE")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDCATEGORY");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("Nguyen_Duong_The_Vi.Models.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("COMMENT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IDBAIVIET")
                        .HasColumnType("int");

                    b.Property<int?>("IDUSER")
                        .HasColumnType("int");

                    b.Property<int?>("LIKE")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NGAYBINHLUAN")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TENUSER")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("XACMINH")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("Nguyen_Duong_The_Vi.Models.Contact", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayGui")
                        .HasColumnType("datetime2");

                    b.Property<string>("TieuDe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("contacts");
                });

            modelBuilder.Entity("Nguyen_Duong_The_Vi.Models.ContactAll", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayGui")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TieuDe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("contactalls");
                });

            modelBuilder.Entity("Nguyen_Duong_The_Vi.Models.Post", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("AUTHOR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CONTEXT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IDTAUTHOR")
                        .HasColumnType("int");

                    b.Property<int?>("LIKE")
                        .HasColumnType("int");

                    b.Property<DateTime>("PUBLISHED")
                        .HasColumnType("datetime2");

                    b.Property<string>("SUMMARY")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TITLE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VIEW")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("posts");
                });

            modelBuilder.Entity("Nguyen_Duong_The_Vi.Models.PostCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("IDCATEGORY")
                        .HasColumnType("int");

                    b.Property<int>("IDPOST")
                        .HasColumnType("int");

                    b.Property<int?>("PostTempID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("IDCATEGORY");

                    b.HasIndex("IDPOST");

                    b.HasIndex("PostTempID");

                    b.ToTable("postCategories");
                });

            modelBuilder.Entity("Nguyen_Duong_The_Vi.Models.PostCategoryTemp", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("IDCATEGORY")
                        .HasColumnType("int");

                    b.Property<int>("IDPOSTTEMP")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("postCategoryTemps");
                });

            modelBuilder.Entity("Nguyen_Duong_The_Vi.Models.PostTemp", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("AUTHOR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CONTEXT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IDTAUTHOR")
                        .HasColumnType("int");

                    b.Property<int?>("LIKE")
                        .HasColumnType("int");

                    b.Property<DateTime>("PUBLISHED")
                        .HasColumnType("datetime2");

                    b.Property<int?>("STATUS")
                        .HasColumnType("int");

                    b.Property<string>("SUMMARY")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TEMP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TITLE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VIEW")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("postTemps");
                });

            modelBuilder.Entity("Nguyen_Duong_The_Vi.Models.ThongTin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("ChaoMung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CongViec")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DieuKhoan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discord")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Facebook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Github")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Linkedin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTaAbout")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuyenRiengTu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TieuDe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TruongHoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Twitter")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("thongTins");
                });

            modelBuilder.Entity("Nguyen_Duong_The_Vi.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Facebook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Job")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastVisit")
                        .HasColumnType("datetime2");

                    b.Property<string>("Linkedln")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumberOfComment")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfPosts")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfVisits")
                        .HasColumnType("int");

                    b.Property<string>("Organization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Point")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Twitter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Youtube")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Nguyen_Duong_The_Vi.Models.PostCategory", b =>
                {
                    b.HasOne("Nguyen_Duong_The_Vi.Models.Category", "Category")
                        .WithMany("PostCategories")
                        .HasForeignKey("IDCATEGORY")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nguyen_Duong_The_Vi.Models.Post", "Post")
                        .WithMany("PostCategories")
                        .HasForeignKey("IDPOST")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nguyen_Duong_The_Vi.Models.PostTemp", null)
                        .WithMany("PostCategories")
                        .HasForeignKey("PostTempID");

                    b.Navigation("Category");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Nguyen_Duong_The_Vi.Models.Category", b =>
                {
                    b.Navigation("PostCategories");
                });

            modelBuilder.Entity("Nguyen_Duong_The_Vi.Models.Post", b =>
                {
                    b.Navigation("PostCategories");
                });

            modelBuilder.Entity("Nguyen_Duong_The_Vi.Models.PostTemp", b =>
                {
                    b.Navigation("PostCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
